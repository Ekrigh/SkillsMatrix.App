
using SkillsMatrix.Infrastructure.Models;

namespace Skillsmatrix.Domain
{
    public class SkillRating
    {
        
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public int Rating { get; set; }
        public int DesiredRating { get; set; }
    }
}

