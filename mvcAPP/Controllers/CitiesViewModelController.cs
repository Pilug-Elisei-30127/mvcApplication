using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.Mvc;
using mvcAPP.Models;
using System.Text;

namespace mvcAPP.Controllers
{
    public class CitiesViewModelController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Models.AppDbContext db = new Models.AppDbContext();
            List<SelectListItem> listSelectListItem = new List<SelectListItem>();

            foreach (City city in db.Cities)
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Text = city.Name,
                    Value = city.Name,
                    Selected = city.IsSelected
                };
                listSelectListItem.Add(selectListItem);
            }
            CitiesViewModel citiesViewModel = new CitiesViewModel();
            citiesViewModel.Cities = listSelectListItem;
            return View(citiesViewModel);
        }

        [HttpPost]
        public string  Index(IEnumerable<string> SelectedCity)
        {
            if (SelectedCity == null)
            {
                return "You did not select any city";
            }
           else 
                            {
                StringBuilder sb = new StringBuilder();
                sb.Append("You selected - "+ string.Join(",", SelectedCity));
                                return sb.ToString();
            }
        }
    }
}