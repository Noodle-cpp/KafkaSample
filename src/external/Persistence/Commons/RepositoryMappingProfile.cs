using AutoMapper;
using Domain.Models;

namespace Persistence.Commons;

public class RepositoryMappingProfile<TEntity, TModel> : Profile where TEntity : class
                                                            where TModel : class
{
    public RepositoryMappingProfile()
    {
        CreateMap<BookModel, Book>().ReverseMap();
    }
}