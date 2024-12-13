using Application.Extensions;
using Infrastructure.Commons;
using Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Persistence.Extensions;

namespace DependencyResolver;

public static class DependencyContainer
{
    public static IServiceCollection RegisterDependencies(this IServiceCollection services, 
                                                          IConfiguration configuration)
    {
        services.AddInfrastructureServices();
        services.AddPersistenceServices(configuration);
        services.AddApplicationServices();

        return services;
    }
}