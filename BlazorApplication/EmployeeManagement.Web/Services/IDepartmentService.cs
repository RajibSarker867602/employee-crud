using EmployeeManagement.Models;
using EmployeeManagement.Models.Entities;

namespace EmployeeManagement.Web.Services
{
    public interface IDepartmentService
    {
        Task<ResponseDto> GetDepartmentsAsync();
        Task<ResponseDto> GetDepartmentByIdAsync(long id);
        Task<ResponseDto> GetDepartmentByNameAsync(string name);
        Task<ResponseDto> AddAsync(Department department);
        Task<ResponseDto> UpdateAsync(Department department);
        Task<ResponseDto> DeleteAsync(long id);
    }
}
