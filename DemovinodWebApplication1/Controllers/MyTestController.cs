using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemovinodWebApplication1.Controllers
{
    public class MyTestController : Controller
    {
        // GET: MyTest
        public ActionResult Method()
        {
           ViewBag.Name = "hello world";
            ViewData["Name"] = "vinod";
            return View();
        }
    }
}