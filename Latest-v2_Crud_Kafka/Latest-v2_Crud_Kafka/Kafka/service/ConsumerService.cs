using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Latest_v2_Crud_Kafka.Kafka.service
{
    public class ConsumerService<T>
    {
        
        private readonly IConsumer<string, string> _consumer;
        private readonly string _topicName;

        public ConsumerService(IOptions<KafkaSettingModel> kafkaSettings)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = kafkaSettings.Value.BootstrapServers,
                GroupId = kafkaSettings.Value.GroupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _consumer = new ConsumerBuilder<string, string>(config).Build();

            // Determine the topic name based on the entity type
            _topicName = kafkaSettings.Value.Topics[typeof(T).Name];
            _consumer.Subscribe(_topicName);
        }

        public List<T> ConsumeAll()
        {
            var results = new List<T>();

            try
            {
                while (true)
                {
                    var consumeResult = _consumer.Consume(TimeSpan.FromSeconds(5));
                    if (consumeResult != null)
                    {
                        var data = JsonConvert.DeserializeObject<T>(consumeResult.Message.Value);
                        results.Add(data);
                        Console.WriteLine($"Consumed from {_topicName}: {consumeResult.Message.Value}");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Consumption canceled.");
            }
            

            return results;
        }
        
    }
}
