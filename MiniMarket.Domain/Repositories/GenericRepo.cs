using Microsoft.EntityFrameworkCore;
using MiniMarket.Domain.Context;
using MiniMarket.Domain.Entity;
using MiniMarket.Domain.Repositories.Contract;

namespace MiniMarket.Domain.Repositories
{
    internal abstract class GenericRepo<TEntity> : IGenericRepo<TEntity>
        where TEntity : BaseEntity, new()
    {
        protected readonly MiniMarketDbContext _context;
        public GenericRepo(MiniMarketDbContext context)
        {
            _context = context;
        }
        public virtual async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var obj = await _context.Set<TEntity>().FindAsync(id);
            if (obj == null)
                throw new Exception($"Unable find {nameof(TEntity)} with id {id}");
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            var obj = await _context.Set<TEntity>().FindAsync(id);
            if (obj == null)
                throw new Exception($"{nameof(TEntity)} with {id} not found");
            return obj;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            // чекаем есть ли объект объект в БД
            var isPresent = await _context.Set<TEntity>().AnyAsync(x => x.Id == entity.Id);
            if (!isPresent)
                throw new Exception($"Unable to update {nameof(TEntity)} with id={entity.Id}. Entity not found.");
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
