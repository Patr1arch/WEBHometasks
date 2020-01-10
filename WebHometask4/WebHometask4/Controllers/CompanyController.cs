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
    public class CompanyController : Controller
    {
        FilmingContext _context;
        public CompanyController(FilmingContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CompanyNames(string? pattern)
        {
            ViewBag.Genres = new List<Genre>(_context.Genres.ToList());
            if (pattern == null)
            {
                return View(_context.Companies.ToList());
            }
            List<Company> companies = _context.Companies.Where(elem => elem.Id.ToString().Contains(pattern)
            || elem.Name.Contains(pattern)).ToList();          

            //List<CompanyModel> companyModels = new List<CompanyModel>();
            //foreach (var com in companies)
            //{
            //    var date = com.CreationDate.Subtract(DateTime.Now);
            //    string lifetime = "";
            //    if (date.TotalDays > 0) lifetime += date.TotalDays.ToString() + "дня ";
            //    if (date.TotalHours > 0) lifetime += date.TotalHours.ToString() + "часа ";
            //    if (date.TotalMinutes > 0) lifetime += date.TotalMinutes.ToString() + "минут(ы)";
            //    companyModels.Add(new CompanyModel { Id = com.Id, Name = com.Name, Lifetime = lifetime });
            //}

            return View(companies);
    }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            Company com = _context.Companies.ToList().Find(c => c.Id == id);
            ViewBag.Genres = new List<Genre>(_context.Genres.ToList());
            if (com != null)
            {
                var date = DateTime.Now.Subtract(com.CreationDate);
                string lifetime = "";
                if (Math.Floor(date.TotalDays) > 0) lifetime += Math.Floor(date.TotalDays).ToString() + "дня ";
                if (Math.Floor(date.TotalHours) > 0) lifetime += (Math.Floor(date.TotalHours) % 24).ToString() + "часа ";
                if (Math.Floor(date.TotalMinutes) > 0) lifetime += (Math.Floor(date.TotalMinutes) % 60).ToString() + "минут(ы)";

                CompanyModel model = new CompanyModel { Id = com.Id, Name = com.Name, Lifetime = lifetime };
                return View(model);
            }
            else return NotFound();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var obj = _context.Companies.ToList().Find(c => c.Id == id);
            ViewBag.Genres = new List<Genre>(_context.Genres.ToList());
            if (obj != null)
            {
                return View(obj);
            }
            else return NotFound();
        }

        [AcceptVerbs("POST", "PUT")]
        public IActionResult Edit(Company company, DateTime CreationDate)
        {
            if (company == null || company.Name == null) return BadRequest();

            company.CreationDate = CreationDate;
            _context.Companies.Update(company); // Не работает
            _context.SaveChanges();
            ViewBag.Genres = new List<Company>(_context.Companies.ToList());
            return Redirect("~/Company/CompanyNames");

            //_context.Companies.Remove(_context.Companies.ToList().Find(c=> c.Id == oldId));
            //_context.SaveChanges();
            //if (_context.Companies.ToList().Find(c => c.Name == company.Name) == null &&
            //   _context.Companies.ToList().Find(c => c.Id == company.Id) == null)
            //{
                                
            //    //_context.Companies.Add(company);
            //    _context.SaveChanges();
            //    return Redirect("~/Company/CompanyNames");
            //}
            //else
            //{
            //    _context.Add(new Company { Id = oldId, Name = oldName, CreationDate = DateTime.Now });
            //    _context.SaveChanges();
            //    return BadRequest();
            //}
        }

        [AcceptVerbs("POST", "DELETE", "GET")]
        public IActionResult Delete(int? id)
        {
            if (id == null) return BadRequest();
            var company = _context.Companies.ToList().Find(c => c.Id == id);
            if (company == null) return BadRequest();

            _context.Companies.Remove(company);
            _context.SaveChanges();
            ViewBag.Genres = new List<Genre>(_context.Genres.ToList());
            return Redirect("~/Company/CompanyNames");
        }

        [HttpGet]
        public IActionResult Make()
        {
            ViewBag.Genres = new List<Genre>(_context.Genres.ToList());
            return View();
        }

        [HttpPost]
        public IActionResult Make(Company company)
        {
            if (company == null) return BadRequest();
            if (company.Name == null) return BadRequest();

            if (_context.Companies.ToList().Find(c => c.Id == company.Id) != null ||
                _context.Companies.ToList().Find(c => c.Name == company.Name) != null) return BadRequest();

            int defaultId = _context.Companies.ToList().Count + 1;
            for (int i = 1; i < defaultId; i++)
            {
                if (_context.Companies.ToList().Find(c => c.Id == i) == null)
                {
                    defaultId = i;
                    break;
                }
            }
            company.Id = defaultId;
            company.CreationDate = DateTime.Now;
            _context.Add(company);
            _context.SaveChanges();
            ViewBag.Genres = new List<Genre>(_context.Genres.ToList());
            return Redirect("~/Company/CompanyNames");
        }
    }
}
