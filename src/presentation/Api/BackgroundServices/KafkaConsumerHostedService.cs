using Confluent.Kafka;
using Infrastructure.Abstractions.Interfaces;

namespace Api.BackgroundServices;

public class KafkaConsumerHostedService : BackgroundService
{
    private readonly IKafkaConsumer _consumer;
    private readonly IHostApplicationLifetime _lifetime;

    public KafkaConsumerHostedService(IKafkaConsumer consumer, IHostApplicationLifetime lifetime)
    {
        _consumer = consumer;
        _lifetime = lifetime;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (!await WaitForAppStartup(_lifetime, stoppingToken))
            return;
        
        _consumer.SubscribeConsumer("test_topic");
        
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _consumer.StartConsuming();
            }
            catch (Exception ex)
            {
                // обработка ошибки однократного неуспешного выполнения фоновой задачи
            }
        }
    }
    
    static async Task<bool> WaitForAppStartup(IHostApplicationLifetime lifetime, CancellationToken stoppingToken)
    {
        var startedSource = new TaskCompletionSource();
        await using var reg1 = lifetime.ApplicationStarted.Register(() => startedSource.SetResult());
 
        var cancelledSource = new TaskCompletionSource();
        await using var reg2 = stoppingToken.Register(() => cancelledSource.SetResult());
 
        var completedTask = await Task.WhenAny(startedSource.Task, cancelledSource.Task).ConfigureAwait(false);
 
        return completedTask == startedSource.Task;
    }
}