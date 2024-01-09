using MediatR;
using AutoMapper;
using CleanArchitectureWebApi.Domain.Entities.Blog;
using CleanArchitectureWebApi.Application.Common.Interfaces.Repositories;


namespace CleanArchitectureWebApi.Application.Blogs.Queries.GetById
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, Blog>
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

        public GetBlogByIdQueryHandler(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }
        public async Task<Blog> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _blogService.GetByIdAsync(request.BlogId);
            return _mapper.Map<Blog>(blog);
        }
    }
}
