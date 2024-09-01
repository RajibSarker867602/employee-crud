using EmployeeManagement.API.Repositories.Contracts;
using EmployeeManagement.Models.Entities;
using EmployeeManagement.Models.Enums;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string name, GenderEnum? gender)
        {
            try
            {
                return Ok(await _employeeRepository.SearchAsync(name, gender));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   "Employees data not found! Please try again later.");
            }
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _employeeRepository.GetAllAsync());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, 
                    "Employees data not found! Please try again later.");
            }
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _employeeRepository.GetByIdAsync(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Employees data not found! Please try again later.");
            }
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee value)
        {
            try
            {
                if (value is null) return BadRequest("Invalid input request.");

                var isExist = await _employeeRepository.GetByEmailAsync(value.Email);
                if (isExist != null) return BadRequest("Email is already exist.");

                return Ok(await _employeeRepository.AddAsync(value));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Employees data could not be saved! Please try again later.");
            }
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Employee value)
        {
            try
            {
                return Ok(await _employeeRepository.UpdateAsync(value));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Employees data could not be updated! Please try again later.");
            }
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _employeeRepository.DeleteAsync(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Employees data could not be deleted! Please try again later.");
            }
        }
    }
}
