using MediatR;
using CleanArchitectureWebApi.Application.DTOs;

namespace CleanArchitectureWebApi.Application.Blogs.Commands.Create
{
    public class CreateCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
