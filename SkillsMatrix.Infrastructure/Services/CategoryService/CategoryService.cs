using Microsoft.Extensions.Caching.Memory;
using SkillsMatrix.Infrastructure.Models;
using SkillsMatrix.Infrastructure.Repositories;

namespace SkillsMatrix.Infrastructure.Services.CategoryService
{
    public class CategoryService(IRepository<Category> _categoryRepository, IMemoryCache _memoryCache) : ICategoryService
    {
        public async Task<Category> GetById(int id)
        {
            var categories = await GetAll();
            return categories.FirstOrDefault(category => category.Id == id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var categories = await _memoryCache.GetOrCreateAsync("categories", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
                return await _categoryRepository.GetAll();
            });
            return categories;
        }

        public async Task Add(Category category)
        {
            await _categoryRepository.Add(category);
            _memoryCache.Remove("categories");
        }

        public async Task Delete(Category category)
        {
            await _categoryRepository.Remove(category);
            _memoryCache.Remove("categories");
        }
    }
}
