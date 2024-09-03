using EmployeeManagement.API.Repositories.Contracts;
using EmployeeManagement.Models;
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
        private readonly ResponseDto _response;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
             _response = new ResponseDto();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string name, GenderEnum? gender)
        {
            try
            {
                var response = await _employeeRepository.SearchAsync(name, gender);
                _response.Result = response;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
                //return StatusCode(StatusCodes.Status500InternalServerError,
                //                   "Employees data not found! Please try again later.");
            }

            return Ok(_response);
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                _response.Result = await _employeeRepository.GetAllAsync();
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;

                //return StatusCode(StatusCodes.Status500InternalServerError, 
                //    "Employees data not found! Please try again later.");
            }

            return Ok(_response);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                _response.Result = await _employeeRepository.GetByIdAsync(id);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
                //return StatusCode(StatusCodes.Status500InternalServerError,
                //    "Employees data not found! Please try again later.");
            }

            return Ok(_response);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee value)
        {
            try
            {
                if (value is null) throw new Exception("Invalid input request.");

                var isExist = await _employeeRepository.GetByEmailAsync(value.Email);
                if (isExist != null) throw new Exception("Email is already exist.");
 
                _response.Result = await _employeeRepository.AddAsync(value);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;

                //return StatusCode(StatusCodes.Status500InternalServerError,
                //    "Employees data could not be saved! Please try again later.");
            }

            return Ok(_response);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Employee value)
        {
            try
            {
                _response.Result = await _employeeRepository.UpdateAsync(value);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
                //return StatusCode(StatusCodes.Status500InternalServerError,
                //    "Employees data could not be updated! Please try again later.");
            }

            return Ok(_response);
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _response.Result = await _employeeRepository.DeleteAsync(id);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
                //return StatusCode(StatusCodes.Status500InternalServerError,
                //    "Employees data could not be deleted! Please try again later.");
            }

            return Ok(_response);
        }
    }
}
