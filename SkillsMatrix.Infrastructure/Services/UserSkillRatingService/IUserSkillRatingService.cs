using SkillsMatrix.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsMatrix.Infrastructure.Services.UserSkillRatingService
{
    public interface IUserSkillRatingService
    {
        Task<UserSkillRating> Get(int id);
        Task<UserSkillRating> GetByUserIdAndSkillId(int userId, int skillId);
        Task<IEnumerable<UserSkillRating>> GetAllByUserId(int id);
        Task<IEnumerable<UserSkillRating>> GetAll();
        Task Add(UserSkillRating userSkillRating);
    }
}
