using EmployeeManagement.Models.Entities;
using EmployeeManagement.Models.Enums;
using EmployeeManagement.Web.Services;
using EmployeeManagement.Web.Utilities;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Components.Pages.Employees
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        IEmployeeService EmployeeService { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var data = await EmployeeService.GetEmployeesAsync();
            Employees = Utility.MapToResponse<IEnumerable<Employee>>(data.Result);
        }

        //private void LoadEmployees()
        //{
        //    // make 3 seconds delayed...
        //    System.Threading.Thread.Sleep(3000);

        //    Employees = new List<Employee>()
        //    {
        //        new Employee()
        //        {
        //            Id = 1,
        //            FirstName = "Rajib",
        //            LastName = "Sarker",
        //            Email = "RajibSarker320@gmail.com",
        //            Address = "Dhaka",
        //            DateOfBrith = new DateTime(1980, 10, 5),
        //            DepartmentId = 1,
        //            Gender = GenderEnum.Male,
        //            PhotoPath = "images/man1.jpeg"
        //        },
        //        new Employee()
        //        {
        //            Id = 2,
        //            FirstName = "Raju",
        //            LastName = "Sarker",
        //            Email = "RajuSarker320@gmail.com",
        //            Address = "Dhaka",
        //            DateOfBrith = new DateTime(1980, 10, 5),
        //            DepartmentId = 1,
        //            Gender = GenderEnum.Male,
        //            PhotoPath = "images/man2.jpeg"
        //        },
        //        new Employee()
        //        {
        //            Id = 2,
        //            FirstName = "Sajib",
        //            LastName = "Sarker",
        //            Email = "SajibSarker320@gmail.com",
        //            Address = "Dhaka",
        //            DateOfBrith = new DateTime(1980, 10, 5),
        //            DepartmentId = 2,
        //            Gender = GenderEnum.Male,
        //            PhotoPath = "images/man3.jpeg"
        //        },
        //    };
        //}
    }
}
