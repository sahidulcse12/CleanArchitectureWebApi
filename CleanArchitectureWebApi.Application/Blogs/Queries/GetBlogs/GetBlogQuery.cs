using MediatR;
using CleanArchitectureWebApi.Domain.Entities.Blog;

namespace CleanArchitectureWebApi.Application.Blogs.Queries.GetBlogs
{
    //old approach

    public class GetBlogQuery : IRequest<List<Blog>>
    {
    }

    //new approach
    //public record GetBlogQuery : IRequest<IList<Blog>>;
}
