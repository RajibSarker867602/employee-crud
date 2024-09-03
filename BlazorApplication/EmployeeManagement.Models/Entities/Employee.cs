using EmployeeManagement.Models.Entities.Base;
using EmployeeManagement.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.Entities
{
    public class Employee : Entity
    {
        [Required]
        [MaxLength(5, ErrorMessage = "First name can not be more than 5 digit!")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBrith { get; set; }
        public GenderEnum Gender { get; set; }
        public long DepartmentId { get; set; }
        public Department? Department { get; set; }
        public string PhotoPath { get; set; }

        //[NotMapped]
        //public string FullName => FirstName + " " + LastName;

        //public string GetFullName()
        //{
        //    return FirstName + " " + LastName;
        //}
    }
}
