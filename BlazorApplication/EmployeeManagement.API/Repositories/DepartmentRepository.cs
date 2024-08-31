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
        public async Task<Department> GetDepartmentByIdAsync(int id)
            => await _db.Departments.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<ICollection<Department>> GetDepartmentsAsync()
            => await _db.Departments.AsNoTracking().ToListAsync();
    }
}
