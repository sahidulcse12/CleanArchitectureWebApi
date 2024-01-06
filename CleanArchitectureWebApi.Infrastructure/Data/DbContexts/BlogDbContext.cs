using CleanArchitectureWebApi.Domain.Entities.Blog;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureWebApi.Infrastructure.Data.DbContexts
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }
        public DbSet<Blog> Blogs { get; set; }
    }
}
