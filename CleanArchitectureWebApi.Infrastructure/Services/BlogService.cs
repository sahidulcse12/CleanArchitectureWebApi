using Microsoft.EntityFrameworkCore;
using CleanArchitectureWebApi.Domain.Entities.Blog;
using CleanArchitectureWebApi.Infrastructure.Data.DbContexts;
using CleanArchitectureWebApi.Application.Common.Interfaces.Repositories;

namespace CleanArchitectureWebApi.Infrastructure.Services
{
    public class BlogService : IBlogService
    {
        private readonly BlogDbContext _blogDbContext;

        public BlogService(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }
        public async Task<Blog> AddAsync(Blog blog)
        {
            await _blogDbContext.Blogs.AddAsync(blog);
            await _blogDbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _blogDbContext.Blogs
                         .Where(model => model.Id == id)
                         .ExecuteDeleteAsync();
        }

        public async Task<IList<Blog>> GetAllAsync()
        {
            return await _blogDbContext.Blogs .ToListAsync();
        }

        public async Task<Blog?> GetByIdAsync(int id)
        {
            return await _blogDbContext.Blogs.AsNoTracking()
                        .FirstOrDefaultAsync(b=>b.Id==id);
        }

        public async Task<int> UpdateAsync(int id, Blog blog)
        {
            return await _blogDbContext.Blogs
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, blog.Id)
                    .SetProperty(m => m.Name, blog.Name)
                    .SetProperty(m => m.Description, blog.Description)
                    .SetProperty(m => m.Author, blog.Author)
                  );
        }
    }
}
