using SkillsMatrix.Infrastructure.Models;

namespace SkillsMatrix.Infrastructure.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<Category> GetById(int Id);
        Task<IEnumerable<Category>> GetAll();
        Task Add(Category category);



    }
}


