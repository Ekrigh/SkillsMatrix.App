using SkillsMatrix.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace SkillsMatrix.Infrastructure.Repositories
{
    public class UserRepository(SMContext _smContext) : Repository<User>(_smContext), IUserRepository
    {
        public new async Task<User> GetById(int id)
        {
            return await _smContext.Users.Include(user => user.UserSkillRatings).ThenInclude(user => user.Skill).FirstOrDefaultAsync(user => user.Id == id);
                

            /*
            var user = await _smContext.Users.FindAsync(id);
            if (user != null)
            {
                await _smContext.Entry(user).Collection(u => u.UserSkillRatings).LoadAsync();
            }
        return user;
            */
        }
    }
}