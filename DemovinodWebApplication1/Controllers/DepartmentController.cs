using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Models;


namespace DemovinodWebApplication1.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        DataBaseconnection db = new DataBaseconnection();
        public ActionResult Department()
        {
            List<Department> dep = new List<Department>();
            dep = db.departments.Select(x => x).ToList();
            return View(dep);

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department dep)
        {
            db.departments.Add(dep);
            db.SaveChanges();
            return RedirectToAction("Department");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Department dep = new Department();
            dep = db.departments.Where(x => x.DepartmentId == id).FirstOrDefault();
            return View(dep);
        }

        [HttpPost]
        public ActionResult Edit(Department dep)
        {
            db.Entry(dep).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Department");

        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeleteGet(int id)
        {
            Department dep = new Department();
            dep = db.departments.Where(x => x.DepartmentId == id).FirstOrDefault();
            return View(dep);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            Department dep = db.departments.Find(id);
            db.departments.Remove(dep);
            db.SaveChanges();
            return RedirectToAction("Department");

        }


    }
}