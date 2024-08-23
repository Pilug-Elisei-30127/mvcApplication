using mvcDemo.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcDemo.Models; 
using System.Text;
using Microsoft.Ajax.Utilities;

namespace mvcDemo.Controllers
{
    public class HomeController : Controller
    {
        public static  CityModelEntity db = new CityModelEntity();
        public ActionResult Index()
        {
            return View(db.Cities);
        }

       [HttpPost]
       [ActionName("Index")]
        public string Index(Company company)
        {
            if(string.IsNullOrEmpty(company.SelectedDepartament))
            {
                return  "Please select a departament";
            }
            else
            {
               StringBuilder sb = new StringBuilder();
                sb.Append("You select-");
                foreach (City city in db.Cities)
                {
                    if (city.IsSelected)
                    {
                        sb.Append(city.Name + ",");
                    }
                }
                sb.Remove(sb.ToString().LastIndexOf(","), 1);
                return sb.ToString() ;

            }
        }
        //public ActionResult IndexCheck()
        //{
        //    //CityModelEntity db = new CityModelEntity();
        //   // ViewBag.Message = "Your application description page.";
        //    return View(db.Cities);
        //}
        //[HttpPost]
        //[ActionName("IndexCheck")]
        //public string  IndexCheck_Post(IEnumerable<City> cities)
        //{
        //    if (cities.Count(x => x.IsSelected) == 0)
        //        return "You didn't select any    city";
        //    else
        //        return "You selected " + cities.Count(x => x.IsSelected) + " cities";
        //}
    }
}