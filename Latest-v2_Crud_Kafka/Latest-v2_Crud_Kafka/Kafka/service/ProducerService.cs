using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Latest_v2_Crud_Kafka.Kafka.service
{
    public class ProducerService<T>
    {
        private readonly IProducer<string, string> _producer;
        private readonly string _topicName;

        public ProducerService(IOptions<KafkaSettingModel> kafkaSettings)
        {
            var config = new ProducerConfig { BootstrapServers = kafkaSettings.Value.BootstrapServers };
            _producer = new ProducerBuilder<string, string>(config).Build();

            // Determine the topic name based on the entity type
            _topicName = kafkaSettings.Value.Topics[typeof(T).Name];
        }

        public async Task ProduceAsync(T data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            await _producer.ProduceAsync(_topicName, new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = jsonData });
            Console.WriteLine($"Produced to {_topicName}: {jsonData}");
        }
    }
}
