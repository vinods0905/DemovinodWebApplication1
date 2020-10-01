using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.Models;
using BusinessLayer.Repository;
using BusinessLayer.ViewModels;

namespace DemovinodWebApplication1.Controllers
{
    //[HandleError]
    public class HomeController : Controller
    {
        DataBaseconnection db = new DataBaseconnection();

        EmployeeRepository empRepository = new EmployeeRepository();
        public ActionResult Index()
        {
            
            return View();
        }
        
        public ActionResult List(string search,string searchby,int ? Page,string Sort)
        {
           List<EmployeeViewModel> emp = new List<EmployeeViewModel>();

            //throw new Exception("error occured while executing");

            // ViewBag.Sorting.IsNullOrEmpty(Sort) ? Descending:"";


            if (string.IsNullOrEmpty(Sort))
            {
                ViewBag.Sorting = "Descending";
            }
            else
            {
                ViewBag.Sorting = "";
            }
            
            


            if (string.IsNullOrEmpty(search) && string.IsNullOrEmpty(searchby))
            {
                emp = empRepository.GetAllEmployees();
            }
            else if(searchby=="name")
            {
                emp= empRepository.GetAllEmployees();
                // emp = db.employees.Where(x => x.EmployeeName.Contains(search)).ToList();

            }
            else if(searchby=="gender")
            {
                emp = empRepository.GetAllEmployees();

                // emp = db.employees.Where(x => x.Gender==search).ToList();
            }
            if (Sort == "Descending")
            {
                emp = emp.OrderByDescending(x => x.EmployeeName).ToList();    
            }
            else
            {
                emp = emp.OrderBy(x => x.EmployeeName).ToList();
            }
            return View(emp.ToPagedList(Page ?? 1,3));
            
        }
        [HttpGet]  //action verb
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]

        public ActionResult Create(Employee emp)
        {
            db.employees.Add(emp);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeViewModel emp = new EmployeeViewModel();

            emp = empRepository.GetSingleEmployee(id);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            EmployeeViewModel emp = new EmployeeViewModel();
               emp = empRepository.GetSingleEmployee(id);
            return View(emp);

            
        }
        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeleteGet(int id)
        {
            EmployeeViewModel emp = new EmployeeViewModel();
            emp = empRepository.GetSingleEmployee(id);
            return View(emp);
            
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            Employee emp = new Employee();
            emp = db.employees.Find(id);
            db.employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("List");

        }
        [HttpPost]
        
        public ActionResult MultiDelete(IEnumerable<int> empid)
        {
            var emp = db.employees.Where(x => empid.Contains(x.EmpId)).ToList();
            db.employees.RemoveRange(emp);
            db.SaveChanges();
            return RedirectToAction("List");

        }


        [NonAction]
        public string method()
        {
            return ("hello");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       [ChildActionOnly]//it can be called as action method(https://localhost:44376/home/lists) only but not through url
        public ActionResult Districts(List<string> dist)
        {
            return View(dist);

        }
        public JsonResult GetEmployee(string term)
        {
            //List<Employee> employee = new List<Employee>();
            List<string> employee = db.employees.Where(x => x.EmployeeName.StartsWith(term)).Select(x => x.EmployeeName).ToList();

            return Json(employee, JsonRequestBehavior.AllowGet);
        }
    }
}