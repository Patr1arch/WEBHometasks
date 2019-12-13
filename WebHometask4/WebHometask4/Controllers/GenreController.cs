using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebHometask4.Models;
using Microsoft.EntityFrameworkCore;


namespace WebHometask4.Controllers
{
    public class GenreController : Controller
    {
        FilmingContext _context;
        public GenreController(FilmingContext context) => _context = context;

        [HttpGet]
        public IActionResult GenreNames(string? pattern)
        {
            //if (pattern == null)
            //{
                return View(_context.Genres.ToList());
            //}
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var obj = _context.Genres.ToList().Find(g => g.Id == id);
            if (obj != null)
            {
                return View(obj);
            }
            else return NotFound();
        }
    }
}
