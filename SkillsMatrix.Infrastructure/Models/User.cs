using System.ComponentModel.DataAnnotations;

namespace SkillsMatrix.Infrastructure.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Skill> Skills { get; } = new();
        public List<UserSkillRating> UserSkillRatings { get; } = new();
    }
}
