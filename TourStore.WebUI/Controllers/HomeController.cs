using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourStore.WebUI.Abstract;
using TourStore.WebUI.Models;

namespace TourStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private ITourRepository repository;
        public int pageSize = 4;
        public HomeController(ITourRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult List(string category, int page = 1)
        {
            ToursListViewModel model = new ToursListViewModel
            {
                Tours = repository.Tours
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(tour => tour.TourId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
                    repository.Tours.Count() :
                    repository.Tours.Where(tour => tour.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

    }
}