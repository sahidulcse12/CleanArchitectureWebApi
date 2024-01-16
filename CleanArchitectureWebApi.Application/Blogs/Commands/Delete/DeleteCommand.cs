using MediatR;

namespace CleanArchitectureWebApi.Application.Blogs.Commands.Delete
{
    public class DeleteCommand : IRequest<string>
    {
        public int Id { get; set; } 
    }
}
