using SkillsMatrix.Infrastructure.Models;
namespace SkillsMatrix.Infrastructure.Services.UserService
{
    public interface IUserService
    {
        Task<User> GetById(int userId);
        Task<IEnumerable<User>> GetAll();
        Task Add(User user);
        Task Delete(User user);
        Task Update(User user);
        Task UpdateAll(IEnumerable<User> users);

    }
}
