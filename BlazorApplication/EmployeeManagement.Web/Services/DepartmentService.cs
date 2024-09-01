using EmployeeManagement.Models.Entities;

namespace EmployeeManagement.Web.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _httpClient;

        public DepartmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Department>($"{id}");
        }

        public async Task<ICollection<Department>> GetDepartmentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<Department>>("");
        }
    }
}
