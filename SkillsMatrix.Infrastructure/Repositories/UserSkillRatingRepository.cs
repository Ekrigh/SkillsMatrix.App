using Microsoft.EntityFrameworkCore;
using SkillsMatrix.Infrastructure.Models;

namespace SkillsMatrix.Infrastructure.Repositories
{
    public class UserSkillRatingRepository(SMContext _smContext) : Repository<UserSkillRating>(_smContext), IUserSkillRatingRepository
    {
        public async Task<IEnumerable<UserSkillRating>> GetAllByUserId(int userId)
        {
            return await _smContext.UserSkillRatings.Where(usr => usr.UserId == userId)
            .ToListAsync();
        }

        public async Task<UserSkillRating> GetByUserIdAndSkillId(int userId, int skillId)
        {
            return await _smContext.UserSkillRatings
            .FirstOrDefaultAsync(usr => usr.UserId == userId && usr.SkillId == skillId);
        }
    }
}
