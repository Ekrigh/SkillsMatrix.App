using Microsoft.Extensions.Caching.Memory;
using SkillsMatrix.Infrastructure.Models;
using SkillsMatrix.Infrastructure.Repositories;

namespace SkillsMatrix.Infrastructure.Services.UserSkillRatingService
{
    public class UserSkillRatingService(IUserSkillRatingRepository _userSkillRatingRepository, IMemoryCache _memoryCache) : IUserSkillRatingService
    {

        public async Task<UserSkillRating> GetById(int id)
        {
            var userSkillRatings = await GetAll();
            return userSkillRatings.FirstOrDefault(usr => usr.Id == id);
        }

        public async Task<UserSkillRating> GetByUserIdAndSkillId(int userId, int skillId)
        {
            var userSkillRatings = await GetAll();
            return userSkillRatings.FirstOrDefault(usr => usr.User.Id == userId && usr.Skill.Id == skillId);
        }

        public async Task<List<UserSkillRating>> GetAllByUserId(int id)
        {
                var userSkillRatings = await GetAll();
                return userSkillRatings.Where(usr => usr.User.Id == id).ToList();
        }

        public async Task<IEnumerable<UserSkillRating>> GetAll()
        {
            var userSkillRatings = await _memoryCache.GetOrCreateAsync("userSkillRatings", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
                return await _userSkillRatingRepository.GetAll();
            });
            return userSkillRatings;
        }

        public async Task Add(UserSkillRating userSkillRating)
        {
            await _userSkillRatingRepository.Add(userSkillRating);
            _memoryCache.Remove("userSkillRatings");
            _memoryCache.Remove("users");
        }

        public async Task AddAll(List<UserSkillRating> userSkillRatings)
        {
            await _userSkillRatingRepository.AddAll(userSkillRatings);
            _memoryCache.Remove("userSkillRatings");
            _memoryCache.Remove("users");

        }
    }
}
