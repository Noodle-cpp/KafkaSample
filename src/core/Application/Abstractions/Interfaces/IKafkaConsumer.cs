namespace Application.Abstractions.Interfaces;

public interface IKafkaConsumer
{
    public void StartConsuming();
    public void SubscribeConsumer(string topic);
}