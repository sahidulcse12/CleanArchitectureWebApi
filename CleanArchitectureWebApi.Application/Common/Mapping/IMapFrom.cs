using AutoMapper;

namespace CleanArchitectureWebApi.Application.Common.Mapping
{
    public interface IMapFrom<TEntity> where TEntity : class
    {
        void Mapping(Profile profile)=>profile.CreateMap(typeof(TEntity),GetType());
    }
}
