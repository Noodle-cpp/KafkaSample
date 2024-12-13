namespace Domain.Abstractions.Interfaces;

public interface IKafkaProducer
{
    public void SendMessage<T>(string topic, string key, T message);
}