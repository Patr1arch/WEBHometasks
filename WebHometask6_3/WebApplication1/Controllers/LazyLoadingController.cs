﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class LazyLoadingController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var context = new cinemadbContext();
            var seats = context.Seats.ToList();
            return View(seats);
        }
    }
}
