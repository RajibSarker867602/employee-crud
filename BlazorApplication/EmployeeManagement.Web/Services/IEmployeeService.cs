using EmployeeManagement.Models;
using EmployeeManagement.Models.Entities;
using EmployeeManagement.Models.Enums;

namespace EmployeeManagement.Web.Services
{
    public interface IEmployeeService
    {
        Task<ResponseDto> GetEmployeesAsync();
        Task<ResponseDto> GetEmployeeByIdAsync(long id);
        Task<ResponseDto> AddAsync(Employee employee);
        Task<ResponseDto> UpdateAsync(Employee employee);
        Task<ResponseDto> DeleteAsync(long id);
        Task<ResponseDto> GetByEmailAsync(string email);
        Task<ResponseDto> SearchAsync(string name, GenderEnum? gender);
    }
}
