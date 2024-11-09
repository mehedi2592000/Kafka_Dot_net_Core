using Latest_v2_Crud_Kafka.Model;
using Latest_v2_Crud_Kafka.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Latest_v2_Crud_Kafka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CrudService<Customer> _customerCrudService;

        public CustomerController(CrudService<Customer> customerCrudService)
        {
            _customerCrudService = customerCrudService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            await _customerCrudService.CreateAsync(customer);
            return Ok("customer created successfully.");
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _customerCrudService.ReadAll();
            return Ok(students);
        }
    }
}
