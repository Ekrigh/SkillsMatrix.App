using SkillsMatrix.Infrastructure.Repositories;
using SkillsMatrix.Infrastructure.Models;
using Microsoft.Extensions.Caching.Memory;

namespace SkillsMatrix.Infrastructure.Services.UserService
{
    public class UserService(IUserRepository _userRepository) : IUserService
    {

        public async Task<User> GetById(int userId)
        {
            try
            {
                return await _userRepository.GetById(userId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task Add(User user)
        {
            await _userRepository.Add(user);
        }
        public async Task Delete(User user)
        {
            await _userRepository.Remove(user);
        }

        public async Task Update(User user)
        {
            await _userRepository.Update(user);
        }

        public async Task UpdateAll(IEnumerable<User> users)
        {
            await _userRepository.UpdateAll(users);
        }
    }
}
//public class UserService(IUserRepository _userRepository, IMemoryCache _memoryCache) : IUserService
//{

//    public async Task<User> GetById(int id)
//    {
//        var users = await GetAll();
//        return users.FirstOrDefault(user => user.Id == id);
//    }

//        //public async Task<IEnumerable<User>> GetAll()
//        //{
//        //    var users = await _memoryCache.GetOrCreateAsync("users", async entry =>
//        //    {
//        //        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
//        //        return await _userRepository.GetAll();
//        //    });
//        //        _userRepository.AttachEntities(users);
//        //        return users;
//        //}
//        public async Task<IEnumerable<User>> GetAll()
//        {
//            if (_memoryCache.TryGetValue("users", out IEnumerable<User> users))
//            {
//                _userRepository.AttachEntities(users);
//                return users;
//            }

//            users = await _userRepository.GetAll();

//            _memoryCache.Set("users", users, new MemoryCacheEntryOptions
//            {
//                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
//            });

//            return users;
//        }

//        public async Task Add(User user)
//        {
//            _memoryCache.Remove("users");
//            await _userRepository.Add(user);
//        }

//        public async Task Delete(User user)
//        {
//            _memoryCache.Remove("users");
//            await _userRepository.Remove(user);

//        }

//        public async Task Update(User user)
//        {
//            _memoryCache.Remove("users");
//            await _userRepository.Update(user);
//        }

//        public async Task UpdateAll(IEnumerable<User> users)
//        {
//            _memoryCache.Remove("users");
//            await _userRepository.UpdateAll(users);
//        }
//    }
//}
