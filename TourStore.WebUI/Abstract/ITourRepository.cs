using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourStore.WebUI.Entities;

namespace TourStore.WebUI.Abstract
{
    public interface ITourRepository
    {
        IEnumerable<Tour> Tours { get; }
        IEnumerable<ShippingDetail> ShippingDetails { get; }
        void SaveOrder(ShippingDetail shippingDetail);
        ShippingDetail DeleteOrder(int orderId);
        void SaveTour(Tour tour);
        Tour DeleteTour(int tourId);

    }
}
