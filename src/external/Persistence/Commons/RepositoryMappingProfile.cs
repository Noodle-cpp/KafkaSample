using Application.Abstractions;
using Application.Abstractions.Interfaces;
using AutoMapper;
using Domain.Models;
using Persistence.Entity;

namespace Persistence.Commons;

public class RepositoryMappingProfile : Profile
{
    public RepositoryMappingProfile()
    {
        CreateMap<BookModel, Book>().ReverseMap();
        CreateMap<BaseSpecification<BookModel>, BaseSpecification<Book>>();
    }
}