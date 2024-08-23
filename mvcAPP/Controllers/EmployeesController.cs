using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcAPP.Models;
using PagedList;
using PagedList.Mvc;
using mvcAPP.Common;

namespace mvcAPP.Controllers
{
    [TrackExecutionTime]
    public class EmployeesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // sortare si cautare dupa parametru 
        public ActionResult Index(string searchBy, string Search, int? page, string sortBy)
        {
            ViewBag.SortNameParameter = string.IsNullOrEmpty(sortBy) ? "Name desc" : "";
            ViewBag.SortGenderParameter = sortBy == "Gender" ? "Gender  desc" : "Gender ";
            var employees = db.Employees.AsQueryable();
            if (searchBy == "Gender")
            {
                //return View(db.Employees.Where(x => x.Gender == Search || Search == null).ToList().ToPagedList(page ?? 1, 3));
                employees = employees.Where(x => x.Gender == Search || Search == null);
            }
            else
            {
                //return View(db.Employees.Where(x => x.FullName.StartsWith(Search)|| Search == null).ToList().ToPagedList(page ?? 1, 3));
                employees = employees.Where(x => x.FullName == Search || Search == null);

            }
            switch (sortBy)
            {
                case "Name desc":
                    employees = employees.OrderByDescending(x => x.FullName);
                    break;
                case "Gender desc":
                    employees = employees.OrderByDescending(x => x.Gender);
                    break;
                case "Gender ":
                    employees = employees.OrderBy(x => x.Gender);
                    break;
                    default:
                    employees = employees.OrderByDescending(x => x.FullName);
                    break;

            }
            return View(employees.ToPagedList(page ?? 1, 3));
        }

        //informatii de logare salvate in data 
        [TrackExecutionTime]
        public string SaveLogData()
        {
               return "SaveLogData action invoked";
        }
        [TrackExecutionTime] 
        public string Welcome()
        {
            throw new Exception ("Exception Occured ");
        }
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Employee employee = db.Employees.Find(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }

            // GET: Employees/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: Employees/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "Id,FullName,Gender,Age,HireDate,Email,Salary,PersonalWebSite,Photo,AlternateText")] Employee employee)
            {
                if (ModelState.IsValid)
                {
                    db.Employees.Add(employee);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(employee);
            }

            // GET: Employees/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Employee employee = db.Employees.Find(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }

            // POST: Employees/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "Id,FullName,Gender,Age,HireDate,Email,Salary,PersonalWebSite,Photo,AlternateText")] Employee employee)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(employee).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(employee);
            }

            // GET: Employees/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Employee employee = db.Employees.Find(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }

            // POST: Employees/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                Employee employee = db.Employees.Find(id);
                db.Employees.Remove(employee);
                db.SaveChanges();
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
