﻿namespace SkillsMatrix.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task AddAll(IEnumerable<T> entities);
        Task Update(T entity);
        Task UpdateAll(IEnumerable<T> entities);
        Task Remove(T entity);
        void AttachEntities(IEnumerable<T> entities);
    }
}
