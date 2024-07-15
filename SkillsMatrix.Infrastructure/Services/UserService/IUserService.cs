using SkillsMatrix.Infrastructure.Models;
namespace SkillsMatrix.Infrastructure.Services.UserService
{
    public interface IUserService
    {
        Task<User> GetUser(int userId);
        Task AddUser(User user);
    
    }
}
