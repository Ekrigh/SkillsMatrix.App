using SkillsMatrix.Infrastructure.Models;

namespace SkillsMatrix.Infrastructure.Repositories

{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAllUsers();
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetById(int id);
    }
}

