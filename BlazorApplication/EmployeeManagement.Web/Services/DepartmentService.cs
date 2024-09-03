using EmployeeManagement.Models;
using EmployeeManagement.Models.Entities;

namespace EmployeeManagement.Web.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _httpClient;
        private readonly IBaseService _baseService;
        private readonly string BaseDeptUrl = "https://localhost:7093/api/departments";

        public DepartmentService(HttpClient httpClient, IBaseService baseService)
        {
            _httpClient = httpClient;
            _baseService = baseService;
        }

        public async Task<ResponseDto> AddAsync(Department department)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Url = BaseDeptUrl,
                APIType = APIType.POST,
                Data = department
            });
        }

        public async Task<ResponseDto> DeleteAsync(long id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Url = BaseDeptUrl + $"/{id}",
                APIType = APIType.DELETE,
            });
        }

        public async Task<ResponseDto> GetDepartmentByIdAsync(long id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Url = BaseDeptUrl + "/" + id,
                APIType = APIType.GET
            });
        }

        public async Task<ResponseDto> GetDepartmentByNameAsync(string name)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Url = BaseDeptUrl,
                APIType = APIType.GET,
                Data = name
            });
        }

        public async Task<ResponseDto> GetDepartmentsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Url = BaseDeptUrl,
                APIType = APIType.GET
            });
        }

        public async Task<ResponseDto> UpdateAsync(Department department)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Url = BaseDeptUrl,
                APIType = APIType.PUT,
                Data = department
            });
        }
        //public async Task<ResponseDto> GetDepartmentByIdAsync(int id)
        //{
        //    return await _httpClient.GetFromJsonAsync<Department>($"{id}");
        //}

        //public async Task<ResponseDto> GetDepartmentsAsync()
        //{
        //    return await _httpClient.GetFromJsonAsync<ICollection<Department>>("");
        //}
    }
}
