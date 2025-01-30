using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class AddApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }
}