using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourStore.WebUI.Entities;

namespace TourStore.WebUI.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Tour> Tours { get; set; }
        public DbSet<ShippingDetail> ShippingDetails { get; set; }
    }
}
