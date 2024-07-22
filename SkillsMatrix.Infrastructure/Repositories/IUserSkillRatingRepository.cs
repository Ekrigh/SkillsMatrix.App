using SkillsMatrix.Infrastructure.Models;

namespace SkillsMatrix.Infrastructure.Repositories
{
    public interface IUserSkillRatingRepository : IRepository<UserSkillRating>
    {
        Task<List<UserSkillRating>> GetAllByUserId(int userId);
        UserSkillRating GetByUserIdAndSkillId(int userId, int skillId);
        Task SaveAll(List<UserSkillRating> userSkillRatings);
    }
}

