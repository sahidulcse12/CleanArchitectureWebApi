using CleanArchitectureWebApi.Domain.Entities.Blog;

namespace CleanArchitectureWebApi.Application.Common.Interfaces.Repositories
{
    public interface IBlogService
    {
        Task<IList<Blog>> GetAllAsync();
        Task<Blog?> GetByIdAsync(int id);
        Task<Blog> AddAsync(Blog blog);
        Task<int> DeleteAsync(int id);
        Task<int> UpdateAsync(int id,Blog blog);
    }
}
