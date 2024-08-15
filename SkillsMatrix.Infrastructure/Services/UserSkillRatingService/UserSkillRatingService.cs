using Microsoft.Extensions.Caching.Memory;
using SkillsMatrix.Infrastructure.Models;
using SkillsMatrix.Infrastructure.Repositories;

namespace SkillsMatrix.Infrastructure.Services.UserSkillRatingService
{
    public class UserSkillRatingService(IUserSkillRatingRepository _userSkillRatingRepository) : IUserSkillRatingService
    {
        public async Task<UserSkillRating> GetById(int id)
        {
            try
            {
                return await _userSkillRatingRepository.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserSkillRating> GetByUserIdAndSkillId(int userId, int skillId)
        {
            return _userSkillRatingRepository.GetByUserIdAndSkillId(userId, skillId);
        }

        public async Task<List<UserSkillRating>> GetAllByUserId(int id)
        {
            try
            {
                return await _userSkillRatingRepository.GetAllByUserId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<UserSkillRating>> GetAll()
        {
            return await _userSkillRatingRepository.GetAll();
        }

        public async Task Add(UserSkillRating userSkillRating)
        {
            await _userSkillRatingRepository.Add(userSkillRating);
        }

        public async Task AddAll(List<UserSkillRating> userSkillRatings)
        {
            await _userSkillRatingRepository.AddAll(userSkillRatings);
        }

        public async Task<int> GetRating(int userId, int skillId)
        {
            var userSkillRating = _userSkillRatingRepository.GetByUserIdAndSkillId(userId, skillId);
            return userSkillRating?.Rating ?? 0;
        }

        public async Task<int> GetDesiredRating(int userId, int skillId)
        {
            var userSkillRating = _userSkillRatingRepository.GetByUserIdAndSkillId(userId, skillId);
            return userSkillRating?.DesiredRating ?? 0;
        }

        public int GetDiscrepancy(User user, Skill skill)
        {
            var rating = _userSkillRatingRepository.GetByUserIdAndSkillId(user.Id, skill.Id)?.Rating ?? 0;
            var desiredRating = _userSkillRatingRepository.GetByUserIdAndSkillId(user.Id, skill.Id)?.DesiredRating ?? 0;
            var discrepancy = rating - desiredRating;
            return discrepancy < 0 ? discrepancy : 0;
        }
    }
}