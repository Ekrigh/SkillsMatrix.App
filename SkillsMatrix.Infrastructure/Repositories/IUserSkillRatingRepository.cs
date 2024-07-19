using SkillsMatrix.Infrastructure.Models;

namespace SkillsMatrix.Infrastructure.Repositories
{
    public interface IUserSkillRatingRepository : IRepository<UserSkillRating>
    {
        Task<IEnumerable<UserSkillRating>> GetAllByUserId(int userId);
        Task<UserSkillRating> GetByUserIdAndSkillId(int userId, int skillId);
    }
}

