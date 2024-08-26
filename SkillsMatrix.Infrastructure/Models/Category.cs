using System.ComponentModel.DataAnnotations;

namespace SkillsMatrix.Infrastructure.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public List<Category> SubCategories { get; set; } = new();
    }
}
