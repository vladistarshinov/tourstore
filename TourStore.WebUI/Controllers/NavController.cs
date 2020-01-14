using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourStore.WebUI.Abstract;

namespace TourStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private ITourRepository repository;

        public NavController(ITourRepository repo)
        {
            repository = repo;
        }
        // GET: Nav
        public PartialViewResult Menu(string category = null, bool horizontalNav = false)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Tours
                .Select(tour => tour.Category)
                .Distinct()
                .OrderBy(x => x);

            string viewName = horizontalNav ? "MenuHorizontal" : "Menu";
            return PartialView(viewName, categories);
        }
    }
}