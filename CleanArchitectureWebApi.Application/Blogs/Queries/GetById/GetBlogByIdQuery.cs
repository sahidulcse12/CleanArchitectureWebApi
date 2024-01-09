using MediatR;
using CleanArchitectureWebApi.Domain.Entities.Blog;

namespace CleanArchitectureWebApi.Application.Blogs.Queries.GetById
{
    public class GetBlogByIdQuery : IRequest<Blog>
    {
        public int BlogId { get; set; }
    }
}
