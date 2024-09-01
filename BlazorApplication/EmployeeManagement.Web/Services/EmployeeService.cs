using EmployeeManagement.Models.Entities;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Employee>($"{id}");
        }

        public async Task<ICollection<Employee>> GetEmployeesAsync()
        {
            return await _httpClient.GetFromJsonAsync<Employee[]>("");
        }
    }
}
