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

//public class SkillService(ISkillRepository _skillRepository, IMemoryCache _memoryCache) : ISkillService
//{
//    public async Task<Skill> GetById(int id)
//    {
//        var skills = await GetAll();
//        return skills.FirstOrDefault(skill => skill.Id == id);
//    }

//    //public async Task<IEnumerable<Skill>> GetAll()
//    //{
//    //    var skills = await _memoryCache.GetOrCreateAsync("skills", async entry =>
//    //    {
//    //        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
//    //        return await _skillRepository.GetAll();
//    //    });
//    //        _skillRepository.AttachEntities(skills);
//    //        return skills;
//    //}
//    public async Task<IEnumerable<Skill>> GetAll()
//    {
//        if (_memoryCache.TryGetValue("skills", out IEnumerable<Skill> skills))
//        {
//            _skillRepository.AttachEntities(skills);
//            return skills;
//        }

//        skills = await _skillRepository.GetAll();

//        _memoryCache.Set("skills", skills, new MemoryCacheEntryOptions
//        {
//            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
//        });

//        return skills;
//    }

//    public async Task Add(Skill skill)
//    {
//        _memoryCache.Remove("skills");
//        await _skillRepository.Add(skill);
//    }

//    public async Task Delete(Skill skill)
//    {
//        _memoryCache.Remove("skills");
//        await _skillRepository.Remove(skill);
//    }
//}
//}
