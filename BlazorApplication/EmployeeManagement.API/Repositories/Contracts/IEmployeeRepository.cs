using EmployeeManagement.Models.Entities;
using System.Runtime.CompilerServices;

namespace EmployeeManagement.API.Repositories.Contracts
{
    public interface IEmployeeRepository
    {
        Task<Employee> AddAsync(Employee employee);
        Task<Employee> UpdateAsync(Employee employee);
        Task<bool> DeleteAsync(long id);
        Task<Employee> GetByIdAsync(long id);
        Task<ICollection<Employee>> GetAllAsync();
    }
}
