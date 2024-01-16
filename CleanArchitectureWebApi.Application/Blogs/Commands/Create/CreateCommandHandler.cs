using MediatR;
using AutoMapper;
using CleanArchitectureWebApi.Application.DTOs;
using CleanArchitectureWebApi.Domain.Entities.Blog;
using CleanArchitectureWebApi.Application.Common.Interfaces.Repositories;


namespace CleanArchitectureWebApi.Application.Blogs.Commands.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, string>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<string> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var blogEntity = new Blog()
            {
                Name = request.Name,
                Description = request.Description,
                Author = request.Author,
            };

            // Perform data operations within the unit of work
            await _unitOfWork.Blogs.AddAsync(blogEntity);
            _mapper.Map<BlogDto>(blogEntity);

            return "Blog is created successfully";
        }
    }
}
