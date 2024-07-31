using SkillsMatrix.Infrastructure.Models;


namespace SkillsMatrix.Infrastructure.Repositories
{
    public interface ISkillRepository : IRepository<Skill>
    {
        Task<IEnumerable<Skill>> GetAll();
    }
}
