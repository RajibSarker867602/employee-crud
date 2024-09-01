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

        public Task<ResponseDto> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> GetEmployeeByIdAsync(int id)
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

        public Task<ResponseDto> SearchAsync(string name, GenderEnum? gender)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> UpdateAsync(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
