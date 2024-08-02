
namespace SkillsMatrix.Infrastructure.Models
{
    public class UserSkillRating
    {
        public int Id { get; set; }
        public int Rating { get; set; } = new();
        public int DesiredRating { get; set; } = new();
        public DateTime LastUpdated { get; set; }
        public int UserId { get; set; }
        public int SkillId { get; set; }
        public virtual User User { get; set; } 
        public virtual Skill Skill { get; set; } 

    }
}
