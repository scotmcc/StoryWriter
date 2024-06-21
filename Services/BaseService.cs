using Microsoft.EntityFrameworkCore;
using StoryWriter.Data;
using StoryWriter.Data.Entities;

namespace StoryWriter.Services
{
    public abstract class BaseService<T>(StoryWriterContext context) where T : BaseEntity
    {
        protected readonly StoryWriterContext _context = context;
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id) ?? throw new KeyNotFoundException();
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id) ?? throw new KeyNotFoundException();
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
