using Microsoft.EntityFrameworkCore;
using MiniMarket.Domain.Context;
using MiniMarket.Domain.Entity;
using MiniMarket.Domain.Repositories.Contract;

namespace MiniMarket.Domain.Repositories
{
    internal class GenericRepo<TEntity> : IGenericRepo<TEntity>
        where TEntity : BaseEntity, new()
    {
        protected readonly MiniMarketDbContext _context;
        public GenericRepo(MiniMarketDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var obj = await _context.Set<TEntity>().FindAsync(id);
            if (obj == null)
                throw new Exception($"Unable find {nameof(TEntity)} with id {id}");
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
           return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var obj=await _context.Set<TEntity>().FindAsync(id);
            if (obj==null)
            throw new Exception($"{nameof(TEntity)} with {id} not found");
            return obj;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var obj = await _context.Set<TEntity>().FindAsync(entity.Id);
            if (obj == null)
                throw new Exception($"Unable to update {nameof(TEntity)} with {entity.Id} not exists");
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
