using EmployeeManagement.Models.Entities;
using EmployeeManagement.Models.Enums;
using EmployeeManagement.Web.Services;
using EmployeeManagement.Web.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace EmployeeManagement.Web.Components.Pages.Employees
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        IEmployeeService EmployeeService { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        [Inject]
        public IJSRuntime JsRunTime { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadEmployees();   
        }

        private async Task LoadEmployees()
        {
            var data = await EmployeeService.GetEmployeesAsync();
            Employees = Utility.MapToResponse<IEnumerable<Employee>>(data.Result);
        }

        protected async void OnDeleted(long id)
        {
            var confirm = await JsRunTime.InvokeAsync<bool>("showConfirmAlert", "Are you sure to delete this employee information?");
            if (confirm)
            {
                var isDeleted = await EmployeeService.DeleteAsync(id);
                if(isDeleted != null && isDeleted.IsSuccess)
                {
                    await LoadEmployees();
                    StateHasChanged();
                }
            }
        }
    }
}
