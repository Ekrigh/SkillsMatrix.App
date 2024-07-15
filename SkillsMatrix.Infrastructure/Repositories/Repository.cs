using Microsoft.EntityFrameworkCore;


namespace SkillsMatrix.Infrastructure.Repositories
{
    public class Repository<T>(SMContext _smContext) : IRepository<T> where T : class
    {
        
        public async Task<T> GetById(int id)
        {
            return await _smContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _smContext.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _smContext.Set<T>().AddAsync(entity);
            await _smContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _smContext.Set<T>().Update(entity);
            await _smContext.SaveChangesAsync();
        }

        public async Task Remove(T entity)
        {
             _smContext.Set<T>().Remove(entity);

        }
    }
}
