﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmpId { get; set; }
        
        public string EmployeeName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }        
        public string Email { get; set; }
        public string DepartmentName { get; set; }

        public int DepartmentId { get; set; }



    }
}
