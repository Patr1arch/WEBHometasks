using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHometaskMVC.Models;

namespace WebHometaskMVC.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string User { get; set; } // имя фамилия покупателя
        public string Address { get; set; } // адрес покупателя
        public string ContactPhone { get; set; } // контактный телефон покупателя

        public int LaptopId { get; set; } // ссылка на связанную модель Laptop
        public Laptop Laptop { get; set; }
    }
}
