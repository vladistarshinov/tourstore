using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourStore.WebUI.Abstract;
using TourStore.WebUI.Entities;

namespace TourStore.WebUI.Controllers
{
    public class AdminvsController : Controller
    {
        ITourRepository repository;

        public AdminvsController(ITourRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Tours);
        }

        public ViewResult First()
        {
            return View();
        }

        public ViewResult Edit(int tourId)
        {
            Tour tour = repository.Tours
                .FirstOrDefault(g => g.TourId == tourId);
            return View(tour);
        }

        // Перегруженная версия Edit() для сохранения изменений
        [HttpPost]
        public ActionResult Edit(Tour tour)
        {
            if (ModelState.IsValid)
            {
                repository.SaveTour(tour);
                TempData["message"] = string.Format("Изменения в туре \"{0}\" были сохранены", tour.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(tour);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Tour());
        }

        [HttpPost]
        public ActionResult Delete(int tourId)
        {
            Tour deletedTour = repository.DeleteTour(tourId);
            if (deletedTour != null)
            {
                TempData["message"] = string.Format("Тур \"{0}\" был удален",
                    deletedTour.Name);
            }
            return RedirectToAction("Index");
        }

        public ActionResult AdminOrder()
        {
            return View(repository.ShippingDetails);
        }    

        [HttpPost]
        public ActionResult DeleteOrder(int orderId)
        {
            ShippingDetail deletedOrder = repository.DeleteOrder(orderId);
            if (deletedOrder != null)
            {
                TempData["message"] = string.Format("Заказ \"{0}\" был удален",
                    deletedOrder.Name);
            }
            return RedirectToAction("AdminOrder");
        }

    }
}