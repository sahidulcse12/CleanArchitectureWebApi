using CleanArchitectureWebApi.Application.Common.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWebApi.Application.Blogs.Commands.Delete
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, string>
    {
        private readonly IBlogRepository _blogRepository;

        public DeleteCommandHandler(IBlogRepository blogService)
        {
            _blogRepository = blogService;
        }
        public async Task<string> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var result = await _blogRepository.GetByIdAsync(request.Id);
            if(result == null)
            {
                throw new Exception("Blog is not found");
            }
            await _blogRepository.DeleteAsync(request.Id);
            return "Blog is successfully deleted";
        }
    }
}
