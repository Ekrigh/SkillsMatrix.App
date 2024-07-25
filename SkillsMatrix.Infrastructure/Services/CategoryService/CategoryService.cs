using SkillsMatrix.Infrastructure.Models;
using SkillsMatrix.Infrastructure.Repositories;

namespace SkillsMatrix.Infrastructure.Services.CategoryService
{
    public class CategoryService(IRepository<Category> _categoryRepository) : ICategoryService
    {
        public async Task<Category> GetById(int id)
        {
            try
            {
                return await _categoryRepository.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }


        public async Task Add(Category category)
        {
            await _categoryRepository.Add(category);
        }

        public async Task Delete(Category category)
        {
            await _categoryRepository.Remove(category);
        }




    }
}
