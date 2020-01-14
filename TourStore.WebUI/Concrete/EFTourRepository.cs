using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourStore.WebUI.Abstract;
using TourStore.WebUI.Entities;

namespace TourStore.WebUI.Concrete
{
    public class EFTourRepository : ITourRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Tour> Tours
        {
            get { return context.Tours; }
        }

        public IEnumerable<ShippingDetail> ShippingDetails
        {
            get
            {
                return context.ShippingDetails;
            }
        }

        public void SaveTour(Tour tour)
        {
            if (tour.TourId == 0)
                context.Tours.Add(tour);
            else
            {
                Tour dbEntry = context.Tours.Find(tour.TourId);
                if (dbEntry != null)
                {
                    dbEntry.Name = tour.Name;
                    dbEntry.Description = tour.Description;
                    dbEntry.Price = tour.Price;
                    dbEntry.Category = tour.Category;
                }
            }
            context.SaveChanges();
        }

        public Tour DeleteTour(int tourId)
        {
            Tour dbEntry = context.Tours.Find(tourId);
            if (dbEntry != null)
            {
                context.Tours.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveOrder(ShippingDetail shippingDetail)
        {
            if (shippingDetail.OrderId == 0)
                context.ShippingDetails.Add(shippingDetail);
            else
            {
                ShippingDetail dbEntry = context.ShippingDetails.Find(shippingDetail.OrderId);
                if (dbEntry != null)
                {
                    dbEntry.Name = shippingDetail.Name;
                    dbEntry.Line1 = shippingDetail.Line1;
                    dbEntry.Line2 = shippingDetail.Line2;
                    dbEntry.Line3 = shippingDetail.Line3;
                    dbEntry.City = shippingDetail.City;
                    dbEntry.Country = shippingDetail.Country;
                    dbEntry.GiftWrap = shippingDetail.GiftWrap;
                }
            }
            context.SaveChanges();
        }

        public ShippingDetail DeleteOrder(int orderId)
        {
            ShippingDetail dbEntry = context.ShippingDetails.Find(orderId);
            if (dbEntry != null)
            {
                context.ShippingDetails.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
