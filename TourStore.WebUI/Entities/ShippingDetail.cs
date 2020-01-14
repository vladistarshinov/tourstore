using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TourStore.WebUI.Entities
{
    public class ShippingDetail
    {
        [Display(Name = "Данное поле и последнее оставьте пустыми!")]
        [Key]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Укажите как вас зовут (*обязательное поле)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Вставьте адрес доставки")]
        [Display(Name = "Адрес (*обязательное поле)")]
        public string Line1 { get; set; }

        [Display(Name = "Индекс")]
        public string Line2 { get; set; }

        [Display(Name = "Квартира")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Укажите город")]
        [Display(Name = "Город (*обязательное поле)")]
        public string City { get; set; }

        [Required(ErrorMessage = "Укажите страну")]
        [Display(Name = "Страна (*обязательное поле)")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }

    }

    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public  ShippingDetail ShippingDetail { get; set; }
        public  Tour Tour { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
    }
}

