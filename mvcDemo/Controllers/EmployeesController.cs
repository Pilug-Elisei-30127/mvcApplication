using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcDemo.Models;

namespace mvcDemo.Controllers
{
    public class EmployeesController : Controller
    {
        private SampleEntities db = new SampleEntities();

        // GET: Employees
        public async Task<ActionResult> Index()
        {
            List<mvcDemo.Models.Employee> employees = db.Employees.Include(x => x.Departament).ToList(); db.Employees.Include(e => e.Departament);
            return View(employees);
        }

        //public ActionResult DepartmentsByEmployee()
        //{
        //    List<DepartmentsTotal> employees = db.Employees.Include(e => e.Departament)
        //              .GroupBy(x=> x.Departament.Name)
        //              .Select(y=> new DepartmentsTotal
        //              {
        //                  Name=y.Key,
        //                  Total=y.Count()

        //              }).OrderBy(x=>x.Total).ToList();


        //    return View(employees.ToList());
        //}

        // GET: Employees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DepartamentId = new SelectList(db.Departaments, dataValueField: "DepartamentId", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EmployeeId,Name,Gender,City,DepartamentId")] Employee employee)
        {
            if (string.IsNullOrEmpty(employee.Name)){
                ModelState.AddModelError("Name", "The name field is required");     
            }


            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DepartamentId = new SelectList(db.Departaments, "DepartamentId", "Name", employee.DepartamentId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentId = new SelectList(db.Departaments, "DepartamentId", "Name", employee.DepartamentId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Exclude = "Name")] Employee employee)
        {
            Employee employeeFromDb = db.Employees.SingleOrDefault(x=> x.EmployeeId==employee.EmployeeId);
            employeeFromDb.Gender = employee.Gender;
            employeeFromDb.City = employee.City;
            employeeFromDb.DepartamentId= employee.DepartamentId;
            employee.Name = employeeFromDb.Name;

            if (ModelState.IsValid)
            {
                db.Entry(employeeFromDb).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentId = new SelectList(db.Departaments, "DepartamentId", "Name", employee.DepartamentId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }   

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
