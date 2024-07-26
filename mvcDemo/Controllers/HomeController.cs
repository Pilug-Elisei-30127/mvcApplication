using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcDemo.Controllers
{
    public class HomeController : Controller
    { 
        public ActionResult Index()
        {
            ViewData[" Countries"]= new List<string>()
             {
             "India",
            "Austria",
             "Australia"
             };

            return View();
        }
        public ActionResult IndexDemo()
        {
            return View();
        }

    }
}