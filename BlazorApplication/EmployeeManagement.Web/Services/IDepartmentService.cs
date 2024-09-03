using EmployeeManagement.Models.Entities;

namespace EmployeeManagement.Web.Services
{
    public interface IDepartmentService
    {
        Task<ICollection<Department>> GetDepartmentsAsync();
        Task<Department> GetDepartmentByIdAsync(int id);
    }
}
