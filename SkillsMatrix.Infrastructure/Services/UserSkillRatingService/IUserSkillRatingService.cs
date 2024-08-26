using SkillsMatrix.Infrastructure.Models;

namespace SkillsMatrix.Infrastructure.Services.UserSkillRatingService
{
    public interface IUserSkillRatingService
    {
        Task<UserSkillRating> GetById(int id);
        Task<UserSkillRating> GetByUserIdAndSkillId(int userId, int skillId);
        Task<List<UserSkillRating>> GetAllByUserId(int id);
        Task<IEnumerable<UserSkillRating>> GetAll();
        Task Add(UserSkillRating userSkillRating);
        Task AddAll(List<UserSkillRating> userSkillRatings);
        int GetRating(int userId, int skillId);
        int GetDesiredRating(int userId, int skillId);
        int GetDiscrepancy(User user, Skill skill);
    }
}
