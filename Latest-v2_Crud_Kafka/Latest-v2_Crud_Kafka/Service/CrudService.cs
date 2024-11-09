using Latest_v2_Crud_Kafka.Kafka.service;

namespace Latest_v2_Crud_Kafka.Service
{
    public class CrudService<T>
    {
        private readonly ProducerService<T> _producer;
        private readonly ConsumerService<T> _consumer;

        public CrudService(ProducerService<T> producer, ConsumerService<T> consumer)
        {
            _producer = producer;
            _consumer = consumer;
        }

        public async Task CreateAsync(T data)
        {
            await _producer.ProduceAsync(data);
        }

        public List<T> ReadAll()
        {
            return _consumer.ConsumeAll();
        }
    }
}
