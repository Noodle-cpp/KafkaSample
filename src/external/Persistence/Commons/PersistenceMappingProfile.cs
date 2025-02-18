using System.Linq.Expressions;
using AutoMapper;
using Domain.Models;
using Persistence.Abstractions;
using Persistence.Entity;

namespace Persistence.Commons;

public class PersistenceMappingProfile : Profile
{
    public PersistenceMappingProfile()
    {
        CreateMap<BookModel, Book>().ReverseMap();
        CreateMap<AuthorModel, Author>().ReverseMap();
        
        CreateMap<Expression<Func<BookModel, bool>>, Expression<Func<Book, bool>>>();
    }
}