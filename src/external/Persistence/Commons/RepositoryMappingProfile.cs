using AutoMapper;
using Domain.Models;
using Persistence.Entity;

namespace Persistence.Commons;

public class RepositoryMappingProfile<TEntity, TModel> : Profile where TEntity : class
                                                            where TModel : class
{
    public RepositoryMappingProfile()
    {
        CreateMap<BookModel, Book>().ReverseMap();
    }
}