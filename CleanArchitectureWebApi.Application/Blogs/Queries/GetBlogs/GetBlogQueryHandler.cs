using AutoMapper;
using CleanArchitectureWebApi.Application.Common.Interfaces.Repositories;
using MediatR;
using System.Collections.Generic;

namespace CleanArchitectureWebApi.Application.Blogs.Queries.GetBlogs
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, IList<BlogVm>>
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

        public GetBlogQueryHandler(IBlogService blogService , IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }
        public async Task<IList<BlogVm>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogService.GetAllAsync();

            //var blogList = blogs.Select(x => new BlogVm
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Description = x.Description,
            //    Author = x.Author,
            //}).ToList();

            var blogList = _mapper.Map<IList<BlogVm>>(blogs);
            return blogList;
        }
    }
}
