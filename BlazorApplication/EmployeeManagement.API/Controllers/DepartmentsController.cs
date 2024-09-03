using EmployeeManagement.API.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        // GET: api/<DepartmentsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _departmentRepository.GetDepartmentsAsync());
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _departmentRepository.GetDepartmentByIdAsync(id));
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
