using SkillsMatrix.Infrastructure.Models;

namespace SkillsMatrix.App.ViewModels
{
    public class PeopleFinderFilter
    {
        public Skill? Skill { get; set; }
        public int Rating { get; set; } = 1;
    }
}
