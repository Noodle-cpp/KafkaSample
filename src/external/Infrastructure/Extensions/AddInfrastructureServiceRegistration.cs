using Domain.Abstractions.Interfaces;
using Infrastructure.Abstractions.Interfaces;
using Infrastructure.Commons;
using Infrastructure.KafkaBroker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure.Extensions;

public static class AddInfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        
        services.AddSingleton<IKafkaProducer>(provider =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            var bootstrapServers = configuration["KafkaProducerConfig:bootstrapServers"];

            return new KafkaProducer(bootstrapServers);
        });

        services.AddSingleton<IKafkaConsumer>(provider =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            var bootstrapServers = configuration["KafkaConsumerConfig:BootstrapServers"];
            var groupId = configuration["KafkaConsumerConfig:GroupId"];
            var autoOffsetRest = configuration["KafkaConsumerConfig:AutoOffsetRest"];
            var enableAutoOffsetStore = configuration["KafkaConsumerConfig:EnableAutoOffsetStore"];

            return new KafkaConsumer(bootstrapServers, 
                                     groupId, 
                                     autoOffsetRest, 
                                     enableAutoOffsetStore);
        });
        
        return services;
    }
}