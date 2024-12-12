namespace Infrastructure.Commons;

public class ConfigurationOptions
{
    public KafkaConfigurationOptions Kafka { get; set; }
}

public class KafkaConfigurationOptions
{
    public string Host { get; set; }
    public string Port { get; set; }
    public string[] Topics { get; set; }
}