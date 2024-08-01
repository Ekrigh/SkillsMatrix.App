using Microsoft.Extensions.Caching.Memory;
using SkillsMatrix.Infrastructure.Models;
using SkillsMatrix.Infrastructure.Repositories;

namespace SkillsMatrix.Infrastructure.Services.SkillService
{
    public class SkillService(IRepository<Skill> _skillRepository) : ISkillService
    {
        public async Task<Skill> GetById(int id)
        {
            try
            {
                return await _skillRepository.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Skill>> GetAll()
        {
            return await _skillRepository.GetAll();
        }


        public async Task Add(Skill skill)
        {
            await _skillRepository.Add(skill);
        }

        public async Task Delete(Skill skill)
        {
            await _skillRepository.Remove(skill);
        }




    }
}
