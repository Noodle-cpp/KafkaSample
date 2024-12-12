using Confluent.Kafka;

namespace Domain.Abstractions.Interfaces;

public interface IMessageBus
{
    public void ConsumeMessages(IConsumer<Null, string> consumer);
    public IConsumer<Null, string> SubscribeConsumer(string topic);
    public Task SendMessageAsync(string topic, string message);
}