using Domain.Abstractions.Interfaces;
using LinqToDB;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Extensions;

public static class AddPersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var dbConfiguration = configuration.GetConnectionString("Postgres") ?? throw new ArgumentNullException(nameof(configuration));
        
        services.AddLinqToDBContext<TestDbContext>((provider, options)
            => options.UsePostgreSQL(dbConfiguration).UseDefaultLogging(provider));

        return services;
    }
}