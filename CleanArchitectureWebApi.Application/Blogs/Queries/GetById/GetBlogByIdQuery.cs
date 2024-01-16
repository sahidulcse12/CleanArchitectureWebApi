using MediatR;
using CleanArchitectureWebApi.Application.DTOs;

namespace CleanArchitectureWebApi.Application.Blogs.Queries.GetById
{
    public class GetBlogByIdQuery : IRequest<BlogDto>
    {
        public int BlogId { get; set; }
    }
}
