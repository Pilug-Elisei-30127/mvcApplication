using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using mvcAPP.Models;
using System.Data.Entity;


namespace mvcAPP.Controllers
{
    public class EmployeeController : Controller
    {
        public Models.AppDbContext db = new Models.AppDbContext();

        public ActionResult Index()
        {
            AppDbContext db = new AppDbContext();
            List<Employee> employees = db.Employees.ToList();
            return View(employees);
        }
        public ActionResult Details(int id)
        {
            AppDbContext db = new AppDbContext();
            Employee employee = db.Employees.Single(x => x.Id == id);
            return View(employee);
        }
        public ActionResult ListOfEmployees()
        {
           return View(db.Employees.ToList());
        }
        [HttpPost]
        public ActionResult DeleteMultipleEmployees (IEnumerable<int> employeesIdsToDelete)
        {
            if (employeesIdsToDelete == null || !employeesIdsToDelete.Any())
            {
                TempData["ErrorMessage"] = "You didn't select any employee.";
                return RedirectToAction("ListOfEmployees");
            }
            var employeesToDelete = db.Employees.Where(x => employeesIdsToDelete.Contains(x.Id)).ToList();
            db.Employees.RemoveRange(employeesToDelete);
            db.SaveChanges();
            return RedirectToAction("ListOfEmployees");
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            AppDbContext db = new AppDbContext();
            Employee employee = db.Employees.Single(x => x.Id == id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (!ModelState.IsValid)
            {
               
                AppDbContext db = new AppDbContext();
                Employee employeeFromDatabase = db.Employees.Single(x => x.Id == employee.Id);

                employeeFromDatabase.FullName = employee.FullName;
                employeeFromDatabase.Gender = employee.Gender;
                employeeFromDatabase.Age = employee.Age;
                employeeFromDatabase.HireDate = employee.HireDate;
                employeeFromDatabase.Email = employee.Email;
                employeeFromDatabase.Salary = employee.Salary;
                employeeFromDatabase.PersonalWebSite = employee.PersonalWebSite;

                db.SaveChanges();
                return RedirectToAction("Details", new { id = employee.Id});
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
