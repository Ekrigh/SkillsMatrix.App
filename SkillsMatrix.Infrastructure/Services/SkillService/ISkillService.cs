using SkillsMatrix.Infrastructure.Models;

namespace SkillsMatrix.Infrastructure.Services.SkillService
{
    public interface ISkillService
    {
        Task<Skill> GetById(int Id);
        Task Add(Skill skill);
        Task<IEnumerable<Skill>> GetAll();


    }
}
