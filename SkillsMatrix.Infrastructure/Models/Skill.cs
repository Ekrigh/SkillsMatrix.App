﻿using System.ComponentModel.DataAnnotations;

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
        public virtual Category Category { get; set; }
        public virtual List<User> Users { get; set; } = new();
        public virtual List<UserSkillRating> UserSkillRatings { get; set; } = new();
    }
}
