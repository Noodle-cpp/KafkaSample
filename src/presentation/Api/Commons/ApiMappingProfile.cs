using System.Linq.Expressions;
using Api.ViewModels.Responses;
using AutoMapper;
using Domain.Models;
using Persistence.Entity;

namespace Api.Commons;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        CreateMap<BookModel, BookResponse>();
        CreateMap<AuthorModel, AuthorResponse>();
    }
}