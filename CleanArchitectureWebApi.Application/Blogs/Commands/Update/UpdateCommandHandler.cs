using MediatR;
using CleanArchitectureWebApi.Domain.Entities.Blog;
using CleanArchitectureWebApi.Application.Common.Interfaces.Repositories;

namespace CleanArchitectureWebApi.Application.Blogs.Commands.Update
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, int>
    {
        private readonly IBlogService _blogService;

        public UpdateCommandHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task<int> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var UdateblogEntity = new Blog()
            {
                Id = request.Id,
                Author = request.Author,
                Description = request.Description,
                Name = request.Name,
            };

            return await _blogService.UpdateAsync(request.Id, UdateblogEntity);
        }
    }
}
