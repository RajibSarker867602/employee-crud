using EmployeeManagement.API.Data;
using EmployeeManagement.Models.Entities;

namespace EmployeeManagement.API.Repositories.Contracts
{
    public interface IDepartmentRepository
    {
        Task<ICollection<Department>> GetDepartmentsAsync();
        Task<Department> GetDepartmentByIdAsync(int id);
    }
}
