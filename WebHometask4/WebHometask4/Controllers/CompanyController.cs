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
    public class CompanyController : Controller
    {
        FilmingContext _context;
        public CompanyController(FilmingContext context) => _context = context;

        [HttpGet]
        public IActionResult CompanyNames(string? pattern)
        {
            if (pattern == null)
            {
                return View(_context.Companies.ToList());
            }
            List<Company> companies = _context.Companies.Where(elem => elem.Id.ToString().Contains(pattern)
            || elem.Name.Contains(pattern)).ToList();
            return View(companies);
    }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var obj = _context.Companies.ToList().Find(c => c.Id == id);
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
            var obj = _context.Companies.ToList().Find(c => c.Id == id);
            if (obj != null)
            {
                return View(obj);
            }
            else return NotFound();
        }

        [AcceptVerbs("POST", "PUT")]
        public IActionResult Edit(Company company, int oldId, string oldName)
        {
            if (company == null || company.Name == null) return BadRequest();

            _context.Companies.Remove(_context.Companies.ToList().Find(c=> c.Id == oldId));
            _context.SaveChanges();
            if (_context.Companies.ToList().Find(c => c.Name == company.Name) == null &&
               _context.Companies.ToList().Find(c => c.Id == company.Id) == null)
            {
                //_context.Companies.Update(company); // Не работает                
                _context.Companies.Add(company);
                _context.SaveChanges();
                return Redirect("~/Company/CompanyNames");
            }
            else
            {
                _context.Add(new Company { Id = oldId, Name = oldName});
                _context.SaveChanges();
                return BadRequest();
            }
        }

        [AcceptVerbs("POST", "DELETE", "GET")]
        public IActionResult Delete(int? id)
        {
            if (id == null) return BadRequest();
            var company = _context.Companies.ToList().Find(c => c.Id == id);
            if (company == null) return BadRequest();

            _context.Companies.Remove(company);
            _context.SaveChanges();
            return Redirect("~/Company/CompanyNames");
        }

        [HttpGet]
        public IActionResult Make()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Make(Company company)
        {
            if (company == null) return BadRequest();
            if (company.Name == null) return BadRequest();

            if (_context.Companies.ToList().Find(c => c.Id == company.Id) != null ||
                _context.Companies.ToList().Find(c => c.Name == company.Name) != null) return BadRequest();
            _context.Add(company);
            _context.SaveChanges();
            return Redirect("~/Company/CompanyNames");
        }
    }
}
