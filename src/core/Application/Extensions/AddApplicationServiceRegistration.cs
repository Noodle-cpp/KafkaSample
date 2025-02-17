using Application.Services;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class AddApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        return services;
    }
}