using System.Linq;
using System.Web.Mvc;
using TourStore.WebUI.Entities;
using TourStore.WebUI.Abstract;
using TourStore.WebUI.Models;
using TourStore.WebUI.Concrete;


namespace TourStore.WebUI.Controllers
{
   
    public class CartController : Controller
    {
        private ITourRepository repository;
        private IOrderProcessor orderProcessor;
        public CartController(ITourRepository repo, IOrderProcessor processor)
        {
            repository = repo;
            orderProcessor = processor;
        }

     
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        
        public RedirectToRouteResult AddToCart(Cart cart, int tourId, string returnUrl)
        {
            Tour tour = repository.Tours
                .FirstOrDefault(g => g.TourId == tourId);

            if (tour != null)
            {
                cart.AddItem(tour, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        
        public RedirectToRouteResult RemoveFromCart(Cart cart, int tourId, string returnUrl)
        {
            Tour tour = repository.Tours
                .FirstOrDefault(g => g.TourId == tourId);

            if (tour != null)
            {
                cart.RemoveLine(tour);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

     
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        
        public ViewResult Checkout()
        {
            return View(new ShippingDetail());
        }

        [HttpPost]
      public ViewResult Checkout(Cart cart, ShippingDetail shippingDetail)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetail);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetail);
            }
        }

    }
}