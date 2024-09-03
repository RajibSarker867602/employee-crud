using EmployeeManagement.API.Data;
using EmployeeManagement.API.Repositories.Contracts;
using EmployeeManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _db;

        public DepartmentRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Department> AddAsync(Department department)
        {
            await _db.Departments.AddAsync(department);
            await _db.SaveChangesAsync();
            return department;
        }

        public async Task<Department> DeleteAsync(long id)
        {
            if (id == 0) return null;

            var existingDepartment = await _db.Departments.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDepartment is null) return null;

            _db.Departments.Remove(existingDepartment);
            await _db.SaveChangesAsync();
            return existingDepartment;
        }

        public async Task<Department> GetDepartmentByIdAsync(long id)
            => await _db.Departments.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Department> GetDepartmentByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) return null;

            return await _db.Departments.FirstOrDefaultAsync(c => c.DepartmentName.ToLower() == name.ToLower().Trim());
        }

        public async Task<ICollection<Department>> GetDepartmentsAsync()
            => await _db.Departments.AsNoTracking().ToListAsync();

        public async Task<Department> UpdateAsync(Department department)
        {
            if (department is null) return null;

            var existingDepartment = await _db.Departments.FirstOrDefaultAsync(x => x.Id == department.Id);
            if (existingDepartment is null) return null;

            existingDepartment.DepartmentName = department.DepartmentName;
            await _db.SaveChangesAsync();
            return existingDepartment;
        }
    }
}
