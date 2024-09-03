using EmployeeManagement.Models.Entities;
using EmployeeManagement.Models.Enums;
using EmployeeManagement.Web.Services;
using EmployeeManagement.Web.Utilities;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace EmployeeManagement.Web.Components.Pages.Employees
{
    public class EmployeeSetupBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        public ICollection<Department> Departments { get; set; } = new List<Department>();

        public Employee Employee { get; set; } = new Employee();

        public long EmployeeId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            // parse the url id parameter
            long.TryParse(Id, out long employeeId);

            // load departments
            var depts = await DepartmentService.GetDepartmentsAsync();
            Departments = Utility.MapToResponse <ICollection<Department>>(depts.Result);

            if (employeeId > 0)
            {
                var existingEmpData = await EmployeeService.GetEmployeeByIdAsync(employeeId);
                if (existingEmpData != null)
                {
                    Employee = Utility.MapToResponse<Employee>(existingEmpData.Result);
                }
            }
            else
            {
                Employee = new()
                {
                    DateOfBrith = DateTime.Now,
                    Gender = GenderEnum.Male,
                    PhotoPath = "images/man3.jpeg"
                };
            }
        }

        protected async Task OnSubmit()
        {
            if (string.IsNullOrEmpty(Id))
            {
                var response = await EmployeeService.AddAsync(Employee);
                if (response != null && response.IsSuccess)
                {
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    throw new Exception("Save operation failed!");
                }
            }
            else
            {
                var response = await EmployeeService.UpdateAsync(Employee);
                if (response != null && response.IsSuccess)
                {
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    throw new Exception("Update operation failed!");
                }
            }
        }
    }
}
