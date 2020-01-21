using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class EagerLoadingController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var context = new cinemadbContext();
            var films = context.Films.Include(f => f.Company).ToList();
            return View(films);
        }
    }
}
