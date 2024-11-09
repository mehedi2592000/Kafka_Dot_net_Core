using Latest_v2_Crud_Kafka.Model;
using Latest_v2_Crud_Kafka.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Latest_v2_Crud_Kafka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly CrudService<Student> _studentCrudService;

        public StudentController(CrudService<Student> studentCrudService)
        {
            _studentCrudService = studentCrudService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] Student student)
        {
            await _studentCrudService.CreateAsync(student);
            return Ok("Student created successfully.");
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _studentCrudService.ReadAll();
            return Ok(students);
        }
    }
}
