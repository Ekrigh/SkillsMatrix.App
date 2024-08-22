using Azure.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using SkillsMatrix.Infrastructure.Services.UserService;

namespace SkillsMatrix.Infrastructure.Services.GraphService;

public class GraphUserService : IGraphUserService
{
    private readonly GraphServiceClient _graphClient;
    private IUserService _userService;

    public GraphUserService(IOptions<GraphSettings> graphSettings, IUserService userService)
    {
        GraphSettings settings = graphSettings.Value;
        _userService = userService;
        //_mailSettings = mailSettings.Value;
        //_logger = logger;

        var options = new TokenCredentialOptions
        {
            AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
        };
        var scopes = new[] { "https://graph.microsoft.com/.default" };

        var clientSecretCredential = new ClientSecretCredential(settings.TenantId, settings.ClientId, settings.ClientSecret, options);
        _graphClient = new GraphServiceClient(clientSecretCredential, scopes);
    }

    private async Task<int?> GetUserCountAsync()
    {
        //zie https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/feature/5.0/docs/upgrade-to-v5.md
        var count = await _graphClient
            .Users
            .Count
            .GetAsync(requestConfiguration => requestConfiguration.Headers.Add("ConsistencyLevel", "eventual"));
        return count;
    }

    public async Task<List<User>> GetUsersAsyc()
    {
        try
        {
            var count = await GetUserCountAsync();

            if (count > 0)
            {
                var result = await _graphClient.Users.GetAsync(requestConfiguration =>
                {
                    // .Count = true en Headers.Add("ConsistencyLevel", "eventual") moeten erbij, anders geven deze queries niets terug
                    // zie https://learn.microsoft.com/en-us/graph/aad-advanced-queries?tabs=http
                    requestConfiguration.QueryParameters.Count = true;
                    requestConfiguration.Headers.Add("ConsistencyLevel", "eventual");

                    // dit zijn de velden die je wilt ophalen: moet je specifiek opgeven in de beta versie van Graph
                    requestConfiguration.QueryParameters.Select = new string[] { "customSecurityAttributes", "id", "displayName", "givenname", "surname", "officelocation", "mail", "signInActivity" };

                    //Top meegeven, anders krijg je er max 100
                    requestConfiguration.QueryParameters.Top = count.Value;

                    // alleen Rotterdam en Heemskerk, en geen Vergaderzalen, Focusruimtes en TrainingruimteS
                    requestConfiguration.QueryParameters.Filter = "not(startsWith(displayName,'Vergaderzaal')) and not(startsWith(displayName,'Focusruimte')) and not(startsWith(displayName,'Trainingruimte')) and not(startsWith(displayName,'Trainingsruimte'))";
                });
                var users = result?.Value;

                return users;
            }

            return new List<User>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task MapUsers()
    {
        var users = _userService.GetAllUsers();
        var adUsers = await GetUsersAsyc();
        if(adUsers == null) return;
        var usersToAdd = new List<SkillsMatrix.Infrastructure.Models.User>();
        var usersToUpdate = new List<SkillsMatrix.Infrastructure.Models.User>();

        foreach (var adUser in adUsers)
        {
            var matchedUser = users.FirstOrDefault(u => u.ActiveDirectoryId == adUser.Id);

            if (matchedUser != null)
            {
                matchedUser.Name = adUser.DisplayName;
                matchedUser.Email = adUser.Mail;
                usersToUpdate.Add(matchedUser);
            }
            else
            {
                var newUser = new SkillsMatrix.Infrastructure.Models.User
                {
                    ActiveDirectoryId = adUser.Id,
                    Name = adUser.DisplayName,
                    //Email = adUser.Mail
                    Email = string.Empty
                };
                usersToAdd.Add(newUser);
            }
        }

        if (usersToUpdate.Any())
        {
            await _userService.UpdateAll(usersToUpdate);
        }

        if (usersToAdd.Any())
        {
            await _userService.AddAll(usersToAdd);
        }
    }
}

