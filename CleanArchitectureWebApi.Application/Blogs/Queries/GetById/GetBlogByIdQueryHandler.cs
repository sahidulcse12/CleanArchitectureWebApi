using AutoMapper;
using CleanArchitectureWebApi.Application.Blogs.Queries.GetBlogs;
using CleanArchitectureWebApi.Application.Common.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWebApi.Application.Blogs.Queries.GetById
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogVm>
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

        public GetBlogByIdQueryHandler(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }
        public async Task<BlogVm> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _blogService.GetById(request.BlogId);
            return _mapper.Map<BlogVm>(blog);
        }
    }
}
