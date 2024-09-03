using EmployeeManagement.Models.Entities;
using EmployeeManagement.Web.Services;
using EmployeeManagement.Web.Utilities;
using Microsoft.AspNetCore.Components;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeManagement.Web.Components.Pages.Employees
{
    public class EmployeeDetailsBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public Employee Employee { get; set; } = new Employee();

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            var data = await EmployeeService.GetEmployeeByIdAsync(int.Parse(Id));
            Employee = Utility.MapToResponse<Employee>(data.Result); 
        }
    }
}
