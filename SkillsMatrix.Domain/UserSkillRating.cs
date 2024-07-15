using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsMatrix.Domain
{
    public class UserSkillRating
    {
        public User User { get; set; }
        public Skill Skill { get; set; }
        public int Rating { get; set; }
        public int DesiredRating { get; set; }
    }
}
