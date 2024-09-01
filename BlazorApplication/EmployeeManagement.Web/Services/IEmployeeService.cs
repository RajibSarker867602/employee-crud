using EmployeeManagement.Models.Entities;

namespace EmployeeManagement.Web.Services
{
    public interface IEmployeeService
    {
        Task<ICollection<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
    }
}
