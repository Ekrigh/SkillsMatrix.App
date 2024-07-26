﻿namespace SkillsMatrix.Infrastructure.Models
{
    public class UserSkillRating
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SkillId { get; set; }
        public User User { get; set; }
        public Skill Skill { get; set; }
        public int Rating { get; set; } = new();
        public int DesiredRating { get; set; } = new();
    }
}
