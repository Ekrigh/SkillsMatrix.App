using SkillsMatrix.Infrastructure.Repositories;
using SkillsMatrix.Infrastructure.Models;
using Microsoft.Extensions.Caching.Memory;

namespace SkillsMatrix.Infrastructure.Services.UserService
{
    public class UserService(IUserRepository _userRepository, IMemoryCache _memoryCache) : IUserService
    {

        public async Task<User> GetById(int id)
        {
            var users = await GetAll();
            return users.FirstOrDefault(user => user.Id == id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _memoryCache.GetOrCreateAsync("users", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
                return await _userRepository.GetAll();
            });
            return users;
        }

        public async Task Add(User user)
        {
            _memoryCache.Remove("users");
            await _userRepository.Add(user);
        }

        public async Task Delete(User user)
        {
            _memoryCache.Remove("users");
            await _userRepository.Remove(user);
            
        }

        public async Task Update(User user)
        {
            _memoryCache.Remove("users");
            await _userRepository.Update(user);
        }

        public async Task UpdateAll(IEnumerable<User> users)
        {
            await _userRepository.UpdateAll(users);
            _memoryCache.Remove("users");
        }
    }
}
