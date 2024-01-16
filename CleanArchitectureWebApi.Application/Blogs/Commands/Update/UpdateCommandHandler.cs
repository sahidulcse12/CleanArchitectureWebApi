using MediatR;
using CleanArchitectureWebApi.Domain.Entities.Blog;
using CleanArchitectureWebApi.Application.Common.Interfaces.Repositories;

namespace CleanArchitectureWebApi.Application.Blogs.Commands.Update
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, string>
    {
        private readonly IBlogRepository _blogRepository;

        public UpdateCommandHandler(IBlogRepository blogService)
        {
            _blogRepository = blogService;
        }
        public async Task<string> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var UdateblogEntity = new Blog()
            {
                Id = request.Id,
                Author = request.Author,
                Description = request.Description,
                Name = request.Name,
            };

            await _blogRepository.UpdateAsync(request.Id, UdateblogEntity);
            return "Blog is updated successfully";
        }
    }
}
