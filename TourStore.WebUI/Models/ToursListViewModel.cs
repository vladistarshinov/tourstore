using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourStore.WebUI.Entities;

namespace TourStore.WebUI.Models
{
    public class ToursListViewModel
    {
        public IEnumerable<Tour> Tours { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }

    }
}