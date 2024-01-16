using Microsoft.EntityFrameworkCore;
using CleanArchitectureWebApi.Infrastructure.Data.DbContexts;
using CleanArchitectureWebApi.Application.Common.Interfaces.Repositories;

namespace CleanArchitectureWebApi.Infrastructure.Data.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private readonly BlogDbContext _blogDbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
            _dbSet = _blogDbContext.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _blogDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TKey id)
        {
            var result = await GetByIdAsync(id);
            if(result is null)
            {
                return;
            }
             _dbSet.Remove(result);
            await _blogDbContext.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await _dbSet.FindAsync(id);       
        }

        public async Task UpdateAsync(TKey id, TEntity entity)
        {
            _dbSet.Attach(entity);
            _blogDbContext.Entry(entity).State = EntityState.Modified;
            await _blogDbContext.SaveChangesAsync();
        }
    }
}
