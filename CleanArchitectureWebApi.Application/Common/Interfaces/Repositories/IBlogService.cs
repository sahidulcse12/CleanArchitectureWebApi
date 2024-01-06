using CleanArchitectureWebApi.Application.DTOs;

namespace CleanArchitectureWebApi.Application.Common.Interfaces.Repositories
{
    public interface IBlogService
    {
        Task<IList<BlogDto>> GetAll();
        Task<BlogDto?> GetById(int id);
        Task Add(BlogDto blog);
        Task Delete(int id);
        Task Update(int id, BlogDto blog);
    }
}
