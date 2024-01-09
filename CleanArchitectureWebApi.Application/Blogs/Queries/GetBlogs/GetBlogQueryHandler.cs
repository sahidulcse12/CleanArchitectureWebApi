using AutoMapper;
using MediatR;
using CleanArchitectureWebApi.Application.Common.Interfaces.Repositories;
using CleanArchitectureWebApi.Domain.Entities.Blog;

namespace CleanArchitectureWebApi.Application.Blogs.Queries.GetBlogs
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<Blog>>
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

        public GetBlogQueryHandler(IBlogService blogService , IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }
        public async Task<List<Blog>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogService.GetAllAsync();
            var blogList = _mapper.Map<List<Blog>>(blogs);
            return blogList;
        }
    }
}
