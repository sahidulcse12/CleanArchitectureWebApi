
using CleanArchitectureWebApi.Application.Common.Mapping;
using CleanArchitectureWebApi.Domain.Entities.Blog;

namespace CleanArchitectureWebApi.Application.Blogs.Queries.GetBlogs
{
    public class BlogVm : IMapFrom<Blog>
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Author { get; set; } = default!;
    }
}
