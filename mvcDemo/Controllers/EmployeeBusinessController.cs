//using BussinessLayer;

using mvcDemo.Models;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcDemo.Controllers
{
    public class EmployeeBusinessController : Controller
    {
        public IEnumerable<Employee1> Employee
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["SampleContext"].ConnectionString;
                List<Employee1> employeelist = new List<Employee1>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Employee1 employee1 = new Employee1();
                        employee1.Id = Convert.ToInt32(rdr["Id"].ToString());
                        employee1.Name = rdr["Name"].ToString();
                        employee1.Gender = rdr["Gender"].ToString();
                        employee1.City = rdr["City"].ToString();
                        if (!(rdr["DateOfBirth"] is DBNull))
                        {
                            employee1.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                        }
                        employeelist.Add(employee1);
                    }
                }



                return employeelist;
            }


        }
        public void AddEmployee(Employee1 employee)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SampleContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = employee.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = employee.City;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = employee.DateOfBirth;
                cmd.Parameters.Add(paramDateOfBirth);

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }
        public void SaveEmployee(Employee1 employee)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SampleContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spSaveEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@Id";
                paramId.Value = employee.Id;
                cmd.Parameters.Add(paramId);

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = employee.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = employee.City;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = employee.DateOfBirth;
                cmd.Parameters.Add(paramDateOfBirth);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteEmployee(int Id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SampleContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@Id";
                paramId.Value = Id;
                cmd.Parameters.Add(paramId);

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }
            
        public ActionResult Index()
        {
            SampleContext employeeBussinesLayer = new SampleContext();
            List<Employee1> employees = employeeBussinesLayer.Employee1.ToList();
            return View(employees);

        }
        public ActionResult Details(int id)
        {
            return View();
        }


        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {

            return View();
        }
        // AFISARE IN WEB
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //foreach(string key in collection.AllKeys)
        //{
        //    Response.Write("Key=" + key + " ");
        //    Response.Write(collection[key]);
        //    Response.Write("</br>");
        //}

        ////MAPARE FOLOSIND FormCollection
        //    Employee1 employee1 = new Employee1();
        //    employee1.Name = collection["Name"];
        //    employee1.Gender = collection["Gender"];
        //    employee1.City = collection["City"];
        //    employee1.DateOfBirth = Convert.ToDateTime(collection["DateOfBirth"]);

        //    AddEmployee(employee1);
        //    return RedirectToAction("Index");

        //    //return View();

        //}

        //MAPARE FOLOSIND PARAMETRI STRING 
        //[HttpPost]
        //public ActionResult Create(string name, string gender, string city, DateTime dateOfBirth )
        //{
        //    Employee1 employee1 = new Employee1();
        //    employee1.Name = name;
        //    employee1.Gender = gender;
        //    employee1.City = city;
        //    employee1.DateOfBirth = dateOfBirth;

        //    AddEmployee(employee1);
        //    return RedirectToAction("Index");

        //    //return View();

        ////}

        //MAPARE FOLOSIND OBIECT CA PARAMETRU 
        //[HttpPost]
        //public ActionResult Create (Employee1 employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        EmployeeBusinessController emp = new EmployeeBusinessController();
        //        emp.AddEmployee(employee);
        //        return RedirectToAction("Index");
        //    }
        //    return View();  
        //}


        // UpdateModel SI TryUodateModel
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {

            Employee1 employee = new Employee1();
            TryUpdateModel(employee);

            if (ModelState.IsValid)
            {
                EmployeeBusinessController emp = new EmployeeBusinessController();
                emp.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View();
        }



        public ActionResult Edit(int id)
        {
            EmployeeBusinessController employeeBussinesController = new EmployeeBusinessController();
            Employee1 employee1 = employeeBussinesController.Employee.SingleOrDefault(emp => emp.Id == id);


            return View(employee1);
        }

        [HttpPost]
        [ActionName("Edit")]

        public ActionResult Edit_Post(int Id)
        {
            EmployeeBusinessController employeeBussinesController = new EmployeeBusinessController();
            Employee1 employee = employeeBussinesController.Employee.SingleOrDefault(x => x.Id == Id);
            UpdateModel<IEmployee>(employee);
            if (ModelState.IsValid)
            {
                employeeBussinesController.SaveEmployee(employee);
                return RedirectToAction("Index");
            }

            return View();

        }

        public ActionResult Delete()
        {
           return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmployeeBusinessController employeeBussinesController = new EmployeeBusinessController();
            employeeBussinesController.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
