using Confluent.Kafka;
using Domain.Abstractions.Interfaces;
using Infrastructure.Abstractions.Interfaces;

namespace Infrastructure.KafkaBroker;

public class KafkaConsumer : IKafkaConsumer, IDisposable
{
    private readonly IConsumer<string, string> _kafkaConsumer;

    public KafkaConsumer(string bootstrapServers, 
                         string groupId, 
                         string autoOffsetRest, 
                         string enableAutoOffsetStore)
    {
        var consumerConfig = new ConsumerConfig
        {
            BootstrapServers = bootstrapServers,
            GroupId = groupId,
            AutoOffsetReset = ConvertToAutoOffsetReset(autoOffsetRest),
            EnableAutoOffsetStore = Convert.ToBoolean(enableAutoOffsetStore),
        };

        _kafkaConsumer = new ConsumerBuilder<string, string>(consumerConfig).Build();
    }

    static AutoOffsetReset ConvertToAutoOffsetReset(string value)
    {
        return value.ToLower() switch
        {
            "earliest" => AutoOffsetReset.Earliest,
            "latest" => AutoOffsetReset.Latest,
            "error" => AutoOffsetReset.Error,
            _ => throw new ArgumentException($"Invalid AutoOffsetReset value: {value}")
        };
    }

    public void SubscribeConsumer(string topic) => _kafkaConsumer.Subscribe(topic);

    public void StartConsuming()
    {
        try
        {
            var consumeResult = _kafkaConsumer.Consume(CancellationToken.None);

            Console.WriteLine($"Received message: {consumeResult.Offset} \n");
            Console.WriteLine($"Received message: {consumeResult.Message.Key} \n");
            Console.WriteLine($"Received message: {consumeResult.Message.Value} \n\n\n");
        }
        catch (ConsumeException ex)
        {
            Console.WriteLine($"Error consuming message: {ex.Error.Reason}");
        }
    }

    public void Dispose()
    {
        _kafkaConsumer?.Dispose();
    }
}