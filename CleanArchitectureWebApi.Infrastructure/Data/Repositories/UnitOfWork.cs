using CleanArchitectureWebApi.Application.Common.Interfaces.Repositories;
using CleanArchitectureWebApi.Infrastructure.Data.DbContexts;

namespace CleanArchitectureWebApi.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogDbContext _blogDbContext;
        public IBlogRepository Blogs { get; private set; }

        public UnitOfWork(BlogDbContext blogDbContext,IBlogRepository blogs)
        {
            _blogDbContext = blogDbContext;
            Blogs = blogs;
        }

        public void Dispose()
        {
            _blogDbContext.Dispose();
        }

        public void Save()
        {
            _blogDbContext.SaveChanges();
        }
    }
}
