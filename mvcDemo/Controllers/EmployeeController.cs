using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//using BussinessLayer;
using mvcDemo.Models;

namespace mvcDemo.Controllers
{
    //[RoutePrefix("Emp")] impunerea unei rute
    public class EmployeeController : Controller
    {
         private SampleContext db = new SampleContext();
        public ActionResult Details(int id)
        {
            Employee employee = db.Employee.SingleOrDefault(emp => emp.EmployeeId == id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        public ActionResult Index(int departmentid)
        {
            List<Employee> employees = db.Employee.Where(emp=> emp.DepartamentId == departmentid).ToList();

            return View(employees);
        }


        public ActionResult Index2()
        {
            List<Employee1> employees = new List<Employee1>();

            return View(employees);
        }

    }
}