using EmployeeManagement.Models;
using EmployeeManagement.Models.Entities;
using EmployeeManagement.Models.Enums;
using Newtonsoft.Json;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly string BaseEmpUrl = "https://localhost:7093/api/employees";
        private readonly IBaseService _baseService;
        private readonly HttpClient _httpClient;

        public EmployeeService(IBaseService baseService, HttpClient httpClient)
        {
            _baseService = baseService;
            _httpClient = httpClient;
        }

        public async Task<ResponseDto> AddAsync(Employee employee)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Url = BaseEmpUrl,
                APIType = APIType.POST,
                Data = employee
            });
        }

        public async Task<ResponseDto> DeleteAsync(long id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Url = BaseEmpUrl + $"/{id}",
                APIType = APIType.DELETE,
            });
        }

        public async Task<ResponseDto> GetByEmailAsync(string email)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Url = BaseEmpUrl,
                APIType = APIType.GET,
                Data = email
            });
        }

        public async Task<ResponseDto> GetEmployeeByIdAsync(long id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Url = BaseEmpUrl + "/" + id,
                APIType = APIType.GET
            });
        }

        public async Task<ResponseDto> GetEmployeesAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Url = BaseEmpUrl,
                APIType = APIType.GET
            });
        }

        public async Task<ResponseDto> SearchAsync(string name, GenderEnum? gender)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Url = BaseEmpUrl + $"?name={name}&gender/{gender}",
                APIType = APIType.GET,
            });
        }

        public async Task<ResponseDto> UpdateAsync(Employee employee)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Url = BaseEmpUrl,
                APIType = APIType.PUT,
                Data = employee
            });
        }
    }
}
