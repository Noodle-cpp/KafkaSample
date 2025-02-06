using AutoMapper;

namespace Persistence.Commons;

public class RepositoryMappingProfile<TEntity, TModel> : Profile where TEntity : class
                                                            where TModel : class
{
    public RepositoryMappingProfile()
    {
        CreateMap(typeof(TEntity), typeof(TModel)).ReverseMap();
    }
}