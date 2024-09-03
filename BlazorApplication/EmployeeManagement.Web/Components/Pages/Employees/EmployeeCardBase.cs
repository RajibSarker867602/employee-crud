using EmployeeManagement.Models.Entities;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace EmployeeManagement.Web.Components.Pages.Employees
{
    public class EmployeeCardBase : ComponentBase
    {
        [Parameter]
        public Employee? Employee { get; set; }

        [Parameter]
        public bool IsShowViewBtn { get; set; } = true;

        [Parameter]
        public bool IsShowDetails { get; set; } = true;

        [Parameter]
        public string CssStyle { get; set; }

        [Parameter]
        public string CssClass { get; set; }

        [Parameter]
        public EventCallback<long> EmployeeDeletedEvent { get; set; }


        protected async void OnDeleted(long id)
        {
            await EmployeeDeletedEvent.InvokeAsync(id);
        }
    }
}
