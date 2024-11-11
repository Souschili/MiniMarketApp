using MiniMarket.Domain.Entity;


namespace MiniMarket.Domain.Repositories.Contract
{
    public interface IGenericRepo<TEntity> where TEntity : BaseEntity,new()
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task CreateAsync(TEntity entity);
    }
}
