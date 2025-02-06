using System.Reflection;
using DbUp;
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

        Migrate(dbConfiguration);

        services.AddLinqToDBContext<TestDbdb>((provider, options)
            => options.UsePostgreSQL(dbConfiguration).UseDefaultLogging(provider));
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }

    private static void Migrate(string connectionString)
    {
        // Проверяем и создаем базу данных, если она не существует
        EnsureDatabase.For.PostgresqlDatabase(connectionString);

        // Настройка DbUp
        var upgrader =
            DeployChanges.To
                .PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly()) // Используем скрипты из сборки
                .LogToConsole() // Логируем в консоль
                .Build();

        // Применяем миграции
        var result = upgrader.PerformUpgrade();

        // Обработка результата
        if (!result.Successful)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(result.Error);
            Console.ResetColor();
            throw result.Error;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Миграции успешно применены!");
        Console.ResetColor();
    }
}