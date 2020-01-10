using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHometask4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHometask4.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebHometask4.Controllers
{
    public class FilmController : Controller
    {
        public FilmingContext _context;

        public FilmController(FilmingContext context)
        {
            _context = context;
            if (_context.Films.Count() == 0)
            {
                Film film1 = new Film { Id = 1, Name = "Alladin(Film)", CompanyId = 2, Company = _context.Companies.ToList().Find(c => c.Name == "Disney") };
                Film film2 = new Film { Id = 2, Name = "Alladin(Mult)", CompanyId = 2, Company = _context.Companies.ToList().Find(c => c.Name == "Disney") };
                Film film3 = new Film { Id = 3, Name = "Star Wars IV", CompanyId = 5, Company = _context.Companies.ToList().Find(c => c.Name == "LucasFilm") };
                Film film4 = new Film { Id = 4, Name = "Star Wars V", CompanyId = 5, Company = _context.Companies.ToList().Find(c => c.Name == "LucasFilm") };
                Film film5 = new Film { Id = 5, Name = "Star Wars VI", CompanyId = 5, Company = _context.Companies.ToList().Find(c => c.Name == "LucasFilm") };
                Film film6 = new Film { Id = 6, Name = "Star Wars VII", CompanyId = 2, Company = _context.Companies.ToList().Find(c => c.Name == "Disney") };
                Film film7 = new Film { Id = 7, Name = "The Diamond Arm", CompanyId = 3, Company = _context.Companies.ToList().Find(c => c.Name == "Mosfilm") };
                Film film8 = new Film { Id = 8, Name = "Striped Trip", CompanyId = 3, Company = _context.Companies.ToList().Find(c => c.Name == "Lenfilm") };
                _context.AddRange(film1, film2, film3, film4, film5, film6, film7, film8);
                _context.SaveChanges();
            }           
        }

        public async Task<IActionResult> FilmIndex(int? company, string name, int page = 1,
    SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = 3;

            //фильтрация
            IQueryable<Film> films = _context.Films.Include(x => x.Company);

            if (company != null && company != 0)
            {
                films = films.Where(p => p.CompanyId == company);
            }
            if (!String.IsNullOrEmpty(name))
            {
                films = films.Where(p => p.Name.Contains(name));
            }

            // сортировка
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    films = films.OrderByDescending(s => s.Name);
                    break;
                case SortState.CompanyAsc:
                    films = films.OrderBy(s => s.Company.Name);
                    break;
                case SortState.CompanyDesc:
                    films = films.OrderByDescending(s => s.Company.Name);
                    break;
                default:
                    films = films.OrderBy(s => s.Name);
                    break;
            }

            // пагинация
            var count = await films.CountAsync();
            var items = await films.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(_context.Companies.ToList(), company, name),
                Films = items
            };
            return View(viewModel);
        }

    }
}
