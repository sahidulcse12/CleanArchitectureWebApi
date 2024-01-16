using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureWebApi.Application.Common.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBlogRepository Blogs { get; }
        void Save();
    }
}
