using AutoMapper;
using MediatR;
using CleanArchitectureWebApi.Application.DTOs;
using CleanArchitectureWebApi.Application.Common.Interfaces.Repositories;

namespace CleanArchitectureWebApi.Application.Blogs.Queries.GetBlogs
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogDto>>
    {
        private readonly IBlogRepository _blogService;
        private readonly IMapper _mapper;

        public GetBlogQueryHandler(IBlogRepository blogService , IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }
        public async Task<List<BlogDto>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogService.GetAllAsync();
            var blogList = _mapper.Map<List<BlogDto>>(blogs);
            return blogList;
        }
    }
}
