using MediatR;
using CleanArchitectureWebApi.Application.Blogs.Queries.GetBlogs;

namespace CleanArchitectureWebApi.Application.Blogs.Queries.GetById
{
    public class GetBlogByIdQuery : IRequest<BlogVm>
    {
        public int BlogId { get; set; }
    }
}
