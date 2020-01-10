using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebHometask4.Models;
using Microsoft.EntityFrameworkCore;
using WebHometask4.ViewModels;


namespace WebHometask4.Controllers
{
    public class GenreController : Controller
    {
        FilmingContext _context;
        public GenreController(FilmingContext context) => _context = context;

        [HttpGet]
        public IActionResult GenreNames(string? pattern)
        {
            if (pattern == null)
            {
                return View(_context.Genres.ToList());
            }
            List<Genre> genres = _context.Genres.Where(elem => elem.Id.ToString().Contains(pattern)
           || elem.Name.Contains(pattern)).ToList();
            return View(genres);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            Genre gnr = _context.Genres.ToList().Find(g => g.Id == id);
            if (gnr != null)
            {
                var date = DateTime.Now.Subtract(gnr.CreationDate);
                string lifetime = "";
                if (Math.Floor(date.TotalDays) > 0) lifetime += Math.Floor(date.TotalDays).ToString() + "дня ";
                if (Math.Floor(date.TotalHours) > 0) lifetime += Math.Floor(date.TotalHours).ToString() + "часа ";
                if (Math.Floor(date.TotalMinutes) > 0) lifetime += Math.Floor(date.TotalMinutes).ToString() + "минут(ы)";

                GenreModel model = new GenreModel { Id = gnr.Id, Name = gnr.Name, Lifetime = lifetime };
                return View(model);
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
        public IActionResult Edit(Genre genre, DateTime CreationDate)
        {
            if (genre == null || genre.Name == null) return BadRequest();

            genre.CreationDate = CreationDate;
            _context.Update(genre);
            _context.SaveChanges();
            return Redirect("~/Genre/GenreNames");

            //_context.Genres.Remove(_context.Genres.ToList().Find(g => g.Id == oldId));
            //_context.SaveChanges();
            //if (_context.Genres.ToList().Find(g => g.Name == genre.Name) == null &&
            //   _context.Genres.ToList().Find(g => g.Id == genre.Id) == null)
            //{
            //    //_context.Companies.Update(company); // Не работает                
            //    _context.Genres.Add(genre);
            //    _context.SaveChanges();
            //    return Redirect("~/Genre/GenreNames");
            //}
            //else
            //{
            //    _context.Add(new Genre { Id = oldId, Name = oldName });
            //    _context.SaveChanges();
            //    return BadRequest();
            //}
        }

        [AcceptVerbs("POST", "DELETE", "GET")]
        public IActionResult Delete(int? id)
        {         
            if (id == null) return BadRequest();
            var genre = _context.Genres.ToList().Find(g => g.Id == id);
            if (genre == null) return BadRequest();

            _context.Remove(genre);
            _context.SaveChanges();
            return Redirect("~/Genre/GenreNames");
        }

        [HttpGet] 
        public IActionResult Make()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Make(Genre genre)
        {
            if (genre == null) return BadRequest();
            if (genre.Name == null) return BadRequest();

            if (_context.Genres.ToList().Find(g => g.Id == genre.Id) != null ||
                _context.Genres.ToList().Find(g => g.Name == genre.Name) != null) return BadRequest();
            int defaultId = _context.Genres.ToList().Count + 1;
            for (int i = 1; i < defaultId; i++)
            {
                if (_context.Genres.ToList().Find(g => g.Id == i) == null)
                {
                    defaultId = i;
                    break;
                }
            }
            genre.Id = defaultId;
            genre.CreationDate = DateTime.Now;
            _context.Add(genre);
            _context.SaveChanges();
            return Redirect("~/Genre/GenreNames");
        }
    }
}
