using SkillsMatrix.Infrastructure.Models;

namespace SkillsMatrix.Infrastructure.Services.SkillService
{
    public interface ISkillService
    {
        Task<Skill> GetById(int Id);
        Task<IEnumerable<Skill>> GetAll();
        Task Add(Skill skill);
        Task Delete(Skill skill);
        Task Update(Skill skill);



    }
}
