using EmployeeManagement.Models.Entities;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

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
            Departments = await DepartmentService.GetDepartmentsAsync();
        }

        protected async Task OnSubmit()
        {
            var response = await EmployeeService.AddAsync(Employee);
            if (response != null && response.IsSuccess)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
