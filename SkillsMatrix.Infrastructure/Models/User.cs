using System.ComponentModel.DataAnnotations;

namespace SkillsMatrix.Infrastructure.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public virtual List<Skill> Skills { get; set; } = new();
        public virtual List<UserSkillRating> UserSkillRatings { get; set; } = new();
    }
}
