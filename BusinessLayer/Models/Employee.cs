using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusinessLayer.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        [Display(Name ="Employee Name")]
        public string EmployeeName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public int DepartmentId { get; set; }
    }
}