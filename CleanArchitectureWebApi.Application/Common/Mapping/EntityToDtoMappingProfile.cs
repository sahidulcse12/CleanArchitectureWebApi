using AutoMapper;
using CleanArchitectureWebApi.Application.Blogs.Commands.Create;
using CleanArchitectureWebApi.Application.DTOs;
using CleanArchitectureWebApi.Domain.Entities.Blog;

namespace CleanArchitectureWebApi.Application.Common.Mapping
{
    internal class EntityToDtoMappingProfile : Profile
    {
        public EntityToDtoMappingProfile() 
        { 
            CreateMap<Blog,BlogDto>().ReverseMap();
            CreateMap<CreateCommand,Blog>().ReverseMap();
        }
    }
}
