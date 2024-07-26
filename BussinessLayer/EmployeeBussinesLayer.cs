using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BussinessLayer
{
    public  class EmployeeBussinesLayer
    {

        public IEnumerable<Employee1> Employee {
            get {
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
                        employee1.Id = Convert.ToInt32(rdr["Id"]);

                        employee1.Name = rdr["Name"].ToString();
                        employee1.Gender = rdr["Gender"].ToString();
                        employee1.City = rdr["City"].ToString();
                        employee1.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);

                        employeelist .Add(employee1);
                    }
                }



                return employeelist ;
            }
        
        }
    }
}
