using Confluent.Kafka;
using Kafka_Crud.Model;
using Microsoft.Extensions.Options;

namespace Kafka_Crud.KafkaService
{
    public class ProducerService
    {
        private readonly IProducer<string, string> _producer;
        private readonly KafkaSettings _kafkaSettings;

        public ProducerService(IOptions<KafkaSettings> kafkaSettings)
        {
            _kafkaSettings = kafkaSettings.Value;
            var config = new ProducerConfig { BootstrapServers = _kafkaSettings.BootstrapServers };
            _producer = new ProducerBuilder<string, string>(config).Build();
        }

        public async Task SendMessageAsync(string key, string message)
        {
            var kafkaMessage = new Message<string, string> { Key = key, Value = message };
            await _producer.ProduceAsync(_kafkaSettings.TopicName, kafkaMessage);
        }
    }
}
