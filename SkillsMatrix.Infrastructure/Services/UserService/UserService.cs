using SkillsMatrix.Infrastructure.Repositories;
using SkillsMatrix.Infrastructure.Models;

namespace SkillsMatrix.Infrastructure.Services.UserService
{
    public class UserService(IUserRepository _userRepository) : IUserService
    {

        public async Task<User> Get(int userId)
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
