using Kafka_Crud.KafkaService;
using Kafka_Crud.Model;
using Newtonsoft.Json;

namespace Kafka_Crud.Service
{
    public class CrudService
    {
        private readonly ProducerService _producer;
        private readonly ConsumerService _consumerService;

        public CrudService(ProducerService producer,ConsumerService consumerservice)
        {
            _producer = producer;
            _consumerService = consumerservice;
        }

        public async Task CreateAsync(EntityModel entity)
        {
            // Save to database
            await _producer.SendMessageAsync("create", JsonConvert.SerializeObject(entity));
        }

        public async Task UpdateAsync(EntityModel entity)
        {
            // Update database
            await _producer.SendMessageAsync("update", JsonConvert.SerializeObject(entity));
        }

        public async Task DeleteAsync(int id)
        {
            // Delete from database
            await _producer.SendMessageAsync("delete", id.ToString());
        }

        public async Task<List<EntityModel>> getStudentList()
        {
            var students = _consumerService.ConsumeAllStudents();
            return students.ToList();
        }
    }
}
