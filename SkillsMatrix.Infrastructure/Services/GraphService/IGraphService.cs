using Azure.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Graph.Models;

namespace SkillsMatrix.Infrastructure.Services.GraphService;

public interface IGraphUserService
{
    Task<List<User>> GetUsersAsyc();
    Task MapUsers();
}