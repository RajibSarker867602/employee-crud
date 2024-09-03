using EmployeeManagement.API.Repositories;
using EmployeeManagement.API.Repositories.Contracts;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ResponseDto _response;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
            _response = new ResponseDto();
        }


        // GET: api/<DepartmentsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                _response.Result = await _departmentRepository.GetDepartmentsAsync();
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }

            return Ok(_response);
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                _response.Result = await _departmentRepository.GetDepartmentByIdAsync(id);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }

            return Ok(_response);
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Department department)
        {
            try
            {
                if (department is null) throw new Exception("Invalid input request.");

                var isExist = await _departmentRepository.GetDepartmentByNameAsync(department.DepartmentName);
                if (isExist != null) throw new Exception("Department is already exist.");

                _response.Result = await _departmentRepository.AddAsync(department);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }

            return Ok(_response);
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Department department)
        {
            try
            {
                _response.Result = await _departmentRepository.UpdateAsync(department);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }

            return Ok(_response);
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                _response.Result = await _departmentRepository.DeleteAsync(id);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }

            return Ok(_response);
        }
    }
}
