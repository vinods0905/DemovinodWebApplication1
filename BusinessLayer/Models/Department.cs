using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    [Table("Department")]

    public class Department
    {
       
            [Key]
            public int DepartmentId { get; set; }

            [Display(Name = "Department Name")]

            public string DepartmentName { get; set; }

            public string Remarks { get; set; }
       
    }


   
}

