using EmployeeManagement.Models.Entities;
using EmployeeManagement.Web.Services;
using EmployeeManagement.Web.Utilities;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Components.Pages.Departments.Create
{
    public class CreateDepartmentBase : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Department Department { get; set; } = new Department();

        protected override async Task OnInitializedAsync()
        {
            long.TryParse(Id, out long departmentId);
            if (departmentId > 0)
            {
                var existingDepartment = await DepartmentService.GetDepartmentByIdAsync(departmentId);
                if (existingDepartment != null && existingDepartment.IsSuccess)
                {
                    Department = Utility.MapToResponse<Department>(existingDepartment.Result);
                }
            }
        }

        public async Task OnSubmit()
        {
            if (string.IsNullOrEmpty(Id))
            {
                var isSaved = await DepartmentService.AddAsync(Department);
                if (isSaved != null && isSaved.IsSuccess)
                {
                    NavigationManager.NavigateTo("/department-list");
                }
            }
            else
            {
                var isUpdated = await DepartmentService.UpdateAsync(Department);
                if (isUpdated != null && isUpdated.IsSuccess)
                {
                    NavigationManager.NavigateTo("/department-list");
                }
            }
        }
    }
}