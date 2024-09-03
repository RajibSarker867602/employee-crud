using EmployeeManagement.Models.Entities;
using Microsoft.AspNetCore.Components;

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
    }
}
