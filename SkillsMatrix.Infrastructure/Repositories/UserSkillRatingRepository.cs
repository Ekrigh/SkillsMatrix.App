using Microsoft.EntityFrameworkCore;
using SkillsMatrix.Infrastructure.Models;

namespace SkillsMatrix.Infrastructure.Repositories
{
    public class UserSkillRatingRepository(SMContext _smContext) : Repository<UserSkillRating>(_smContext), IUserSkillRatingRepository
    {
        public async Task<List<UserSkillRating>> GetAllByUserId(int userId)
        {
            return await _smContext.UserSkillRatings.Where(usr => usr.UserId == userId)
            .ToListAsync();
        }

        public UserSkillRating GetByUserIdAndSkillId(int userId, int skillId)
        {
            return _smContext.UserSkillRatings
            .FirstOrDefault(usr => usr.UserId == userId && usr.SkillId == skillId);
        }

        public async Task SaveAll(List<UserSkillRating> userSkillRatings)
        {
            foreach (var userSkillRating in userSkillRatings)
            {
                var existingRating = await _smContext.UserSkillRatings
                    .FirstOrDefaultAsync(usr => usr.UserId == userSkillRating.UserId && usr.SkillId == userSkillRating.SkillId);

                if (existingRating != null)
                {
                    existingRating.Rating = userSkillRating.Rating;
                    existingRating.DesiredRating = userSkillRating.DesiredRating;
                    _smContext.UserSkillRatings.Update(existingRating);
                }
                else
                {
                    await _smContext.UserSkillRatings.AddAsync(userSkillRating);
                }
            }
            _smContext.SaveChangesAsync();
        }
    }
}
