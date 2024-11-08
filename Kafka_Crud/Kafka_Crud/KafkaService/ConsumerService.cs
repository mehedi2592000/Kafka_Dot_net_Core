using Confluent.Kafka;
using Kafka_Crud.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Kafka_Crud.KafkaService
{
    public class ConsumerService
    {
        private readonly IConsumer<string, string> _consumer;
        private readonly string _topicName;

        public ConsumerService(IOptions<KafkaSettings> kafkaSettings)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = kafkaSettings.Value.BootstrapServers,
                GroupId = kafkaSettings.Value.GroupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _consumer = new ConsumerBuilder<string, string>(config).Build();
            _topicName = kafkaSettings.Value.TopicName;
            _consumer.Subscribe(_topicName);
        }

        public List<EntityModel> ConsumeAllStudents()
        {
            var students = new List<EntityModel>();

            while (true)
            {
                var consumeResult = _consumer.Consume(TimeSpan.FromSeconds(15));
                if (consumeResult != null)
                {
                    var student = JsonConvert.DeserializeObject<EntityModel>(consumeResult.Message.Value);
                    students.Add(student);
                    Console.WriteLine($"Consumed student data: {consumeResult.Message.Value}");
                }
                else
                {
                    break; // No more messages available
                }
            }

            return students;
        }
    }
}
