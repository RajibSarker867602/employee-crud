using EmployeeManagement.Models.Entities;
using EmployeeManagement.Web.Services;
using EmployeeManagement.Web.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace EmployeeManagement.Web.Components.Pages.Departments.List
{
    public class DepartmentListBase : ComponentBase
    {
        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        [Inject]
        public IJSRuntime JsRunTime { get; set; }

        public ICollection<Department> Departments { get; set; }

        public int Index = 1;

        protected async override Task OnInitializedAsync()
        {
            await LoadDepartments();
        }

        private async Task LoadDepartments()
        {
            var depts = await DepartmentService.GetDepartmentsAsync();
            Departments = Utility.MapToResponse<ICollection<Department>>(depts.Result);
        }

        public async Task OnDeleted(long id)
        {
            var confirm = await JsRunTime.InvokeAsync<bool>("showConfirmAlert", "Are you sure to delete this department?");

            if (confirm)
            {
                var isDeleted = await DepartmentService.DeleteAsync(id);
                if (isDeleted != null && isDeleted.IsSuccess)
                {
                    await LoadDepartments();
                    StateHasChanged();      //TODO: need a better way to refresh the list
                }
            }
        }

        public void Increment()
        {
            Index++;
        }
    }
}
