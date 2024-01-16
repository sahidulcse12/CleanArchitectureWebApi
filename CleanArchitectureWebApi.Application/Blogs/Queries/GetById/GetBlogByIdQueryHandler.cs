using MediatR;
using AutoMapper;
using CleanArchitectureWebApi.Application.DTOs;
using CleanArchitectureWebApi.Application.Common.Interfaces.Repositories;


namespace CleanArchitectureWebApi.Application.Blogs.Queries.GetById
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogDto>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public GetBlogByIdQueryHandler(IBlogRepository blogService, IMapper mapper)
        {
            _blogRepository = blogService;
            _mapper = mapper;
        }
        public async Task<BlogDto> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _blogRepository.GetByIdAsync(request.BlogId);
            return _mapper.Map<BlogDto>(blog);
        }
    }
}
