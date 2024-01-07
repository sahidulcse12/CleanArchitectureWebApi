using CleanArchitectureWebApi.Application.Common.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWebApi.Application.Blogs.Commands.Delete
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, int>
    {
        private readonly IBlogService _blogService;

        public DeleteCommandHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task<int> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            return await _blogService.DeleteAsync(request.Id);
        }
    }
}
