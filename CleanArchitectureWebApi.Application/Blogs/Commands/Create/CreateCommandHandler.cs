using MediatR;
using AutoMapper;
using CleanArchitectureWebApi.Domain.Entities.Blog;
using CleanArchitectureWebApi.Application.Blogs.Queries.GetBlogs;
using CleanArchitectureWebApi.Application.Common.Interfaces.Repositories;


namespace CleanArchitectureWebApi.Application.Blogs.Commands.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, BlogVm>
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

        public CreateCommandHandler(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }
        public async Task<BlogVm> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            Blog blogEntity = new Blog()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Author = request.Author,
            };

            var result = await _blogService.AddAsync(blogEntity);
            return _mapper.Map<BlogVm>(result);
        }
    }
}
