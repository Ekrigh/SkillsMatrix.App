using SkillsMatrix.Infrastructure.Models;

namespace SkillsMatrix.Infrastructure.Repositories

{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetById(int id);
        Task<IEnumerable<User>> GetAll();
    }
}

