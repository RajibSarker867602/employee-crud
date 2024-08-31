using EmployeeManagement.Models.Entities.Base;
using EmployeeManagement.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.Entities
{
    public class Employee : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBrith { get; set; }
        public GenderEnum Gender { get; set; }
        public long DepartmentId { get; set; }
        public string PhotoPath { get; set; }
    }
}
