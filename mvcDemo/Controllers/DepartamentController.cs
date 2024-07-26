using mvcDemo.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcDemo.Controllers
{
    public class DepartamentController : Controller
    {
        private SampleContext db = new SampleContext();

        public ActionResult Index()
        {
            List<Departament> departaments = db.Departament.ToList();
            return View("DepartmentsList", departaments);
        } 
       



    }
}