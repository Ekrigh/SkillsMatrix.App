namespace SkillsMatrix.Domain
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public List<Skill> Skills { get; set; } = new List<Skill>();
    }
}
