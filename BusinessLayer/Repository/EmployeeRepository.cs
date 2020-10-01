using BusinessLayer.IRepository;
using BusinessLayer.Models;
using BusinessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        DataBaseconnection db = new DataBaseconnection();

        //List of Employee
        public List<EmployeeViewModel> GetAllEmployees()
        {
            //List <Employee>emp=new <Employee>();
            // var emp = db.employees.Select(x => x).ToList();
            //select e.EmployeeName,e.Age,e.Gender,e.Email,d.DepartmentName from Employee e
            //inner join Department d on e.DepartmentId = d.DepartmentId;

            List<EmployeeViewModel> employee = new List<EmployeeViewModel>();

            employee = db.employees.Join(db.departments, emp => emp.DepartmentId, dep => dep.DepartmentId, (emp, dep) => new EmployeeViewModel
            {
                EmpId = emp.EmpId,
                EmployeeName = emp.EmployeeName,
                Age = emp.Age,
                Gender = emp.Gender,
                Email = emp.Email,
                DepartmentName = dep.DepartmentName
            }).Select(x => x).ToList();

            return employee;
        }

        //single Employee
        public EmployeeViewModel GetSingleEmployee(int id)
        {
            var employeeviewmodel= db.employees.Join(db.departments, emp => emp.DepartmentId, dep => dep.DepartmentId, (emp, dep) => new EmployeeViewModel
            {
                EmpId = emp.EmpId,
                EmployeeName = emp.EmployeeName,
                Age = emp.Age,
                Gender = emp.Gender,
                Email = emp.Email,
                DepartmentName = dep.DepartmentName
            }).Where(x => x.EmpId == id).FirstOrDefault();
            return employeeviewmodel;

        }

        
    }
}
