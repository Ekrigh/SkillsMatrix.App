using System.ComponentModel.DataAnnotations;

namespace SkillsMatrix.Infrastructure.Models
{
    public class User
    {
        public int Id { get; set; }
        public string ActiveDirectoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime LastSurvey { get; set; }
        public List<Skill> Skills { get; set; } = new();
        public List<UserSkillRating> UserSkillRatings { get; set; } = new();
    }
}
