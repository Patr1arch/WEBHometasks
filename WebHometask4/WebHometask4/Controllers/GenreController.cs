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
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var obj = _context.Genres.ToList().Find(g => g.Id == id);
            if (obj != null)
            {
                return View(obj);
            }
            else return NotFound();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var obj = _context.Genres.ToList().Find(g => g.Id == id);
            if (obj != null)
            {
                return View(obj);
            }
            else return NotFound();
        }

        [AcceptVerbs("POST", "PUT")]
        public IActionResult Edit(Genre genre)
        {
            if (genre == null) return BadRequest();

            if (_context.Genres.ToList().Find(g => g.Name == genre.Name) == null && 
               _context.Genres.ToList().FindAll(g => g.Id == genre.Id).Count <= 1) 
            {
                //_context.Update(genre); // Не работает
                _context.Remove(_context.Genres.ToList().Find(g => g.Id == genre.Id));
                _context.Add(genre);
                _context.SaveChanges();
                return Redirect("~/Genre/GenreNames");
            }
            else return BadRequest();
        }
    }
}
