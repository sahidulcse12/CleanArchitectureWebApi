using MediatR;
using CleanArchitectureWebApi.Domain.Entities.Blog;

namespace CleanArchitectureWebApi.Application.Blogs.Commands.Create
{
    public class CreateCommand : IRequest<Blog>
    {
        public string Name { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
