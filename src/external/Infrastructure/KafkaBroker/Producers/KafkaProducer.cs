using Application.Abstractions.Interfaces;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace Infrastructure.KafkaBroker.Producers;

public class KafkaProducer : IKafkaProducer, IDisposable
{
    private readonly IProducer<string, string> _kafkaProducer;

    public KafkaProducer(string bootstrapServers)
    {
        var producerConfig = new ProducerConfig
        {
            BootstrapServers = bootstrapServers,
        };

        _kafkaProducer = new ProducerBuilder<string, string>(producerConfig).Build();
    }

    public void SendMessage<T>(string topic, string key, T message)
    {
        var serializedMessage = JsonConvert.SerializeObject(message);
        _kafkaProducer.Produce(topic, new Message<string, string> { Key = key, Value = serializedMessage });
    }

    public void Dispose()
    {
        _kafkaProducer?.Dispose();
    }
}