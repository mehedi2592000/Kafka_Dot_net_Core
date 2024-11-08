using Kafka_Crud.Model;
using Kafka_Crud.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kafka_Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KafkaProducerController : ControllerBase
    {
        private readonly CrudService _crudService;


        public KafkaProducerController(CrudService crudService)
        {
            _crudService = crudService;
        }

        [HttpGet]
        public async Task<IActionResult> getStudentList()
        {
           var student= await _crudService.getStudentList();
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EntityModel entity)
        {
            await _crudService.CreateAsync(entity);
            return Ok("Entity created");
        }

        [HttpPut]
        public async Task<IActionResult> Update(EntityModel entity)
        {
            await _crudService.UpdateAsync(entity);
            return Ok("Entity updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _crudService.DeleteAsync(id);
            return Ok("Entity deleted");
        }
    }
}
