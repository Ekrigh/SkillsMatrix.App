namespace SkillsMatrix.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using SkillsMatrix.Infrastructure.Models;

    public class SMContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkillRating> UserSkillRatings { get; set; }
        public SMContext(DbContextOptions<SMContext> options) : base(options)
        {
        }
    }
}
