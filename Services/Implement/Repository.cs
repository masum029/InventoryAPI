using Microsoft.EntityFrameworkCore;
using RepoPatternAPI.Models;
using RepoPatternAPI.Services.Interface;
using System.Collections.Generic;

namespace RepoPatternAPI.Services.Implement
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly InventoryContext _context;
        private readonly DbSet<T> _entities;

        public Repository(InventoryContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _entities.FindAsync(id);
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

}
