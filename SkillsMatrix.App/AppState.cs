using Microsoft.AspNetCore.Components.Web;
using SkillsMatrix.Infrastructure.Models;
using SkillsMatrix.Infrastructure.Services.UserService;

namespace SkillsMatrix.App
{
    public class AppState
    {
        private IUserService _userService;
        public User? CurrentUser { get; private set; }

        public AppState(IUserService userService)
        {
            _userService = userService;
        }

        public async Task SetCurrentUser(Guid userId)
        {
            CurrentUser =  await _userService.GetByAdId(userId);
        }
    }
}
