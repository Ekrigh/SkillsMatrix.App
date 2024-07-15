using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsMatrix.Infrastructure.Models
{
    public class UserSkillRating
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public required User User { get; set; }
        public int SkillId { get; set; }
        [Required]
        public required Skill Skill { get; set; }
        public int Rating { get; set; }
        public int DesiredRating { get; set; }
    }
}
