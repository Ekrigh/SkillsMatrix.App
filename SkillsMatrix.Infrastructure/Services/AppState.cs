using SkillsMatrix.Infrastructure.Models;
using SkillsMatrix.Infrastructure.Services.SkillService;
using SkillsMatrix.Infrastructure.Services.UserService;


namespace SkillsMatrix.Infrastructure.Services
{
    public class AppState(IUserService _userService, ISkillService _skillService)
    {
        public IEnumerable<User> Users { get; set; } = new List<User>();
        public IEnumerable<Skill> Skills { get; set; } = new List<Skill>();
        public bool IsInitialized { get; set; }
        public async Task InitialiseState()
        {
            if (IsInitialized) return;
            Users = await _userService.GetAll();
            Skills = await _skillService.GetAll();
            await InitialiseUserSkillRatings();
            IsInitialized = true;
        }

        private async Task InitialiseUserSkillRatings()
        {
            var updatedUsers = Users.ToList();

            foreach (var user in updatedUsers)
            {
                foreach (var skill in Skills)
                {
                    if (!user.UserSkillRatings.Any(usr => usr.SkillId == skill.Id))
                    {
                        user.UserSkillRatings.Add(new UserSkillRating
                        {
                            UserId = user.Id,
                            SkillId = skill.Id,
                            Rating = 0
                        });
                    }
                }
            }

            await _userService.UpdateAll(updatedUsers);


        }
    }


}
