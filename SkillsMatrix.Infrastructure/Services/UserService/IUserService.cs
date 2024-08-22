using SkillsMatrix.Infrastructure.Models;
namespace SkillsMatrix.Infrastructure.Services.UserService
{
    public interface IUserService
    {
        Task<User> GetById(int userId);
        Task<IEnumerable<User>> GetAll();
        IEnumerable<User> GetAllUsers();
        Task Add(User user);
        Task AddAll(List<User> users);
        Task Delete(User user);
        Task Update(User user);
        Task UpdateAll(IEnumerable<User> users);

    }
}
