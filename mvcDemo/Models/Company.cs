using mvcDemo.Controllers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcDemo.Models
{
    public class Company
    {
        public string SelectedDepartament { get; set; }
        public List<DepartamentController> Departaments
        {
            get
            {
                SampleEntities1 db = new SampleEntities1();
                return db.Departaments.ToList();
            }
        }


}
}