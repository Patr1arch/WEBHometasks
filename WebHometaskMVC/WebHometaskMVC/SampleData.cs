using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHometaskMVC.Models;

namespace WebHometaskMVC
{
    public class SampleData
    {
        public static void Initialize(LaptopContext context)
        {
            if (!context.Laptops.Any())
            {
                context.Laptops.AddRange(
                    new Laptop
                    {
                        Name = "MacBook Pro",
                        Company = "Apple",
                        Price = 1599
                    },
                    new Laptop
                    {
                        Name = "Ideapad 330",
                        Company = "Lenovo",
                        Price = 699
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
