using System.ComponentModel.DataAnnotations;

namespace SkillsMatrix.Infrastructure.Models
{
    public class Skill
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public Category Category { get; set; }
        public List<User> Users { get; set; } = new();
        public List<UserSkillRating> UserSkillRatings { get; set; } = new();
    }
}
