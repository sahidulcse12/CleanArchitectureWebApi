namespace CleanArchitectureWebApi.Application.Common.Interfaces.Repositories
{
    public interface IRepository<TEntity,TKey> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(TKey id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TKey id, TEntity entity);
        Task DeleteAsync(TKey id);
    }
}
