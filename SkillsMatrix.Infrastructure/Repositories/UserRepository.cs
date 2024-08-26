using SkillsMatrix.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace SkillsMatrix.Infrastructure.Repositories
{
    public class UserRepository(SMContext _smContext) : Repository<User>(_smContext), IUserRepository
    {
        public new async Task<User> GetById(int id)
        {
            return await _smContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public new async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _smContext.Users.ToListAsync();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _smContext.Users;
        }

        public async Task<User> GetByAdId(Guid adId)
        {
            return await _smContext.Users.FirstOrDefaultAsync(user => user.ActiveDirectoryId == adId.ToString());
        }
    }
}