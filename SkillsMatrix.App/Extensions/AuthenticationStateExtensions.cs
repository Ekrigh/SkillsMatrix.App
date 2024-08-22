namespace Microsoft.AspNetCore.Components.Authorization;

public static class AuthenticationStateExtensions
{
    public static Guid GetUserId(this AuthenticationState authenticationState)
    {
        const string identityClaim = "http://schemas.microsoft.com/identity/claims/objectidentifier";
        string userIdAsString = authenticationState.User.Claims
            .Where(c => c.Type.Equals(identityClaim))
            .Select(c => c.Value)
            .FirstOrDefault() ?? string.Empty;

        Guid.TryParse(userIdAsString, out Guid userId);

        return userId;
    }
    public static string GetUserName(this AuthenticationState authenticationState)
    {
        const string nameClaim = "name";
        string username = authenticationState.User.Claims
            .Where(c => c.Type.Equals(nameClaim))
            .Select(c => c.Value)
            .FirstOrDefault() ?? string.Empty;

        return username;
    }
}