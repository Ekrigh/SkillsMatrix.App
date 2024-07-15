using System.ComponentModel.DataAnnotations;

namespace SkillsMatrix.Infrastructure.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Email { get; set; }
        public ICollection<UserSkillRating> UserSkillRatings { get; set; } = new List<UserSkillRating>();
    }
}
