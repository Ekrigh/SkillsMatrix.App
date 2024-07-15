namespace SkillsMatrix.Domain
{
    public class Skill
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int ProficiencyLevel { get; set; }
        public int AmbitionLevel { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        
    }
}
