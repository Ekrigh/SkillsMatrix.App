using Microsoft.EntityFrameworkCore;
using SkillsMatrix.Infrastructure.Models;
using SkillsMatrix.Infrastructure.Repositories;

namespace SkillsMatrix.Infrastructure.Services.UserSkillRatingService
{
    public class UserSkillRatingService(IUserSkillRatingRepository _userSkillRatingRepository) : IUserSkillRatingService
    {
        public async Task<UserSkillRating> Get(int id)
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

        public async Task SaveAll(List<UserSkillRating> userSkillRatings)
        {
             _userSkillRatingRepository.SaveAll(userSkillRatings);
        }
    }
}
