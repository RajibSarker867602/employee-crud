using EmployeeManagement.API.Data;
using EmployeeManagement.Models.Entities;

namespace EmployeeManagement.API.Repositories.Contracts
{
    public interface IDepartmentRepository
    {
        Task<ICollection<Department>> GetDepartmentsAsync();
        Task<Department> GetDepartmentByIdAsync(long id);
        Task<Department> GetDepartmentByNameAsync(string name);
        Task<Department> AddAsync(Department department);
        Task<Department> UpdateAsync(Department department);
        Task<Department> DeleteAsync(long id);
    }
}
