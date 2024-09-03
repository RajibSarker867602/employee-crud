using EmployeeManagement.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.Entities
{
    public class Department : Entity
    {
        [Required(ErrorMessage = "Department name is required.")]
        public string DepartmentName { get; set; }
    }
}
