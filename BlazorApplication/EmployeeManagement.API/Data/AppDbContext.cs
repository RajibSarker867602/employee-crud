using EmployeeManagement.Models.Entities;
using EmployeeManagement.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EmployeeManagement.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Departments Table
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, DepartmentName = "IT" });
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 2, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 3, DepartmentName = "Payroll" });
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 4, DepartmentName = "Admin" });

            // Seed Employee Table
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                FirstName = "John",
                LastName = "Hastings",
                Email = "David@pragimtech.com",
                DateOfBrith = new DateTime(1980, 10, 5),
                Gender = GenderEnum.Male,
                DepartmentId = 1,
                Address = "Dhaka",
                PhotoPath = "images/man1.jpeg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 2,
                FirstName = "Sam",
                LastName = "Galloway",
                Email = "Sam@pragimtech.com",
                Address = "Dhaka",
                DateOfBrith = new DateTime(1981, 12, 22),
                Gender = GenderEnum.Male,
                DepartmentId = 2,
                PhotoPath = "images/man2.jpeg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 3,
                FirstName = "Mary",
                LastName = "Smith",
                Address = "Dhaka",
                Email = "mary@pragimtech.com",
                DateOfBrith = new DateTime(1979, 11, 11),
                Gender = GenderEnum.Female,
                DepartmentId = 1,
                PhotoPath = "images/man3.jpeg"
            });
        }
    }
}
