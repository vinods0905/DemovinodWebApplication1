using BusinessLayer.Models;
using BusinessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IRepository
{
   public interface IEmployeeRepository
    {
        List<EmployeeViewModel> GetAllEmployees();
        EmployeeViewModel GetSingleEmployee(int id);

    }
}
