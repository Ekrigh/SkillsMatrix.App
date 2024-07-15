using SkillsMatrix.Infrastructure.Repositories;
using SkillsMatrix.Infrastructure.Models;

namespace SkillsMatrix.Infrastructure.Services.UserService
{
    public class UserService(IRepository<User> _userRepository) : IUserService
    {
		
        public async Task<User> GetUser(int userId)
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


		public async Task AddUser(User user)
		{
			await _userRepository.Add(user);
		}
    }
}
