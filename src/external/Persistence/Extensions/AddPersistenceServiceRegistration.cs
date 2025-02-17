using System.Reflection;
using Application.Abstractions.Interfaces;
using DbUp;
using Domain.Models;
using LinqToDB;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Abstractions;
using Persistence.Entity;

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
        
        AddRepositories(services);
        
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

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IRepository<BookModel>, BaseRepository<BookModel, Book>>();
    }
}