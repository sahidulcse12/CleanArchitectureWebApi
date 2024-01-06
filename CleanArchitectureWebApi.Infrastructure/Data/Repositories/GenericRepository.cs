using CleanArchitectureWebApi.Application.Common.Interfaces.Repositories;
using CleanArchitectureWebApi.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureWebApi.Infrastructure.Data.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly BlogDbContext _blogDbContext;

        public GenericRepository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _blogDbContext.Set<TEntity>().AddAsync(entity);
            await _blogDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await GetByIdAsync(id);
            if(result is null)
            {
                return;
            }
            _blogDbContext.Set<TEntity>().Remove(result);
            await _blogDbContext.SaveChangesAsync();
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _blogDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _blogDbContext.Set<TEntity>().FindAsync(id);       
        }

        public async Task UpdateAsync(int id, TEntity entity)
        {
            _blogDbContext.Set<TEntity>().Update(entity);
            await _blogDbContext.SaveChangesAsync();
        }
    }
}
