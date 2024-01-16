using MediatR;
using CleanArchitectureWebApi.Application.DTOs;

namespace CleanArchitectureWebApi.Application.Blogs.Queries.GetBlogs
{
    //old approach

    public class GetBlogQuery : IRequest<List<BlogDto>>
    {
    }

    //new approach
    //public record GetBlogQuery : IRequest<IList<Blog>>;
}
