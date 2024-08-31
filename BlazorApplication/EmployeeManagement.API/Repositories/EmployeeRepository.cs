using EmployeeManagement.API.Data;
using EmployeeManagement.API.Repositories.Contracts;
using EmployeeManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _db;

        public EmployeeRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Employee> AddAsync(Employee employee)
        {
            var result = await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var dataToDelete = await _db.Employees.FirstOrDefaultAsync(c => c.Id == id);
            if (dataToDelete != null)
            {
                _db.Employees.Remove(dataToDelete);
                return await _db.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<ICollection<Employee>> GetAllAsync()
        {
            return await _db.Employees.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(long id)
            => await _db.Employees.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            var existingData = await _db.Employees.FirstOrDefaultAsync(c => c.Id == employee.Id);
            if (existingData != null)
            {
                existingData.FirstName = employee.FirstName;
                existingData.LastName = employee.LastName;
                existingData.Email = employee.Email;
                existingData.Address = employee.Address;
                existingData.DateOfBrith = employee.DateOfBrith;
                existingData.DepartmentId = employee.DepartmentId;
                existingData.PhotoPath = employee.PhotoPath;

                await _db.SaveChangesAsync();
                return existingData;
            }

            return null;
        }
    }
}
