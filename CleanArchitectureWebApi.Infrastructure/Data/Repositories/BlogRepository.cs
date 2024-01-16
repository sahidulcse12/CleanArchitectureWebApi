using CleanArchitectureWebApi.Domain.Entities.Blog;
using CleanArchitectureWebApi.Infrastructure.Data.DbContexts;
using CleanArchitectureWebApi.Application.Common.Interfaces.Repositories;

namespace CleanArchitectureWebApi.Infrastructure.Data.Repositories
{
    public class BlogRepository : Repository<Blog, int>, IBlogRepository
    {
        public BlogRepository(BlogDbContext dbContext) : base(dbContext)
        {

        }
    }
}
