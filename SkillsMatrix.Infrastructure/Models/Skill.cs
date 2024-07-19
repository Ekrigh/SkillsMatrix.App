using System.ComponentModel.DataAnnotations;

namespace SkillsMatrix.Infrastructure.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<User> Users { get; } = new();
        public List<UserSkillRating> UserSkillRatings { get; } = new();



    }
}
