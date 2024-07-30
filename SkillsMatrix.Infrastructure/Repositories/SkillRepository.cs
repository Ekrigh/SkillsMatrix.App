using Microsoft.EntityFrameworkCore;
using SkillsMatrix.Infrastructure.Models;

namespace SkillsMatrix.Infrastructure.Repositories
{
    public class SkillRepository(SMContext _smContext) : Repository<Skill>(_smContext), ISkillRepository
    {
        public new async Task<IEnumerable<Skill>> GetAll()
        {
            return await _smContext.Skills
                         .Include(skill => skill.Category)
                         .Include(skill => skill.Users)
                         .Include(skill => skill.UserSkillRatings)
                         .ToListAsync();
        }
    }
}
