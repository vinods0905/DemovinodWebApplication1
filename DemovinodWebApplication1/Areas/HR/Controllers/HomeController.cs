using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemovinodWebApplication1.Areas.HR.Controllers
{
    public class HomeController : Controller
    {
        // GET: HR/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}