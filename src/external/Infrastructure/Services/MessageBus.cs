using Confluent.Kafka;
using Domain.Abstractions.Interfaces;
using Infrastructure.Commons;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services;

public class MessageBus : IMessageBus
{
    private readonly IProducer<Null, string> _producer;
    private readonly string _host;
    private readonly string _port;

    public MessageBus(IOptions<ConfigurationOptions> configurationOptions)
    {
        _host = configurationOptions.Value.Kafka.Host;
        _port = configurationOptions.Value.Kafka.Port;
        
        var producerConfig = new ProducerConfig
        {
            BootstrapServers = $"{_host}:{_port}"
        };

        _producer = new ProducerBuilder<Null, string>(producerConfig).Build();
    }

    public async Task SendMessageAsync(string topic, string message)
    {
        try
        {
            await _producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
            Console.WriteLine($"Message '{message}' sent to topic '{topic}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending message to Kafka: {ex.Message}");
            throw;
        }
    }

    public IConsumer<Null, string> SubscribeConsumer(string topic)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = $"{_host}:{_port}",
            GroupId = "my-consumer-group", //??
            AutoOffsetReset = AutoOffsetReset.Earliest //??
        };

        var consumer = new ConsumerBuilder<Null, string>(config).Build();
        consumer.Subscribe(topic);
        
        return consumer;
    }

    public void ConsumeMessages(IConsumer<Null, string> consumer)
    {
        try
        {
            while (true)
            {
                var consumeResult = consumer.Consume();
                Console.WriteLine($"Consumed message: {consumeResult.Message.Value}");
            }
        }
        catch (ConsumeException e)
        {
            Console.WriteLine($"Error consuming message: {e.Error.Reason}");
        }
    }
}