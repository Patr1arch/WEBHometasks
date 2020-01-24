using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using WebHometask7.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebHometask7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {

        cinemadbContext context;
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genres>>> Get()
        {
            return await context.Genres.ToListAsync();
        }

        public GenresController(cinemadbContext context_)
        {
            context = context_;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genres>> Get(int id)
        {
            Genres genres = await context.Genres.FirstOrDefaultAsync(x => x.Id == id);
            if (genres == null) return NotFound();
            else return genres; // return new ObjectResult(genres);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<Genres>> Post(Genres genre)
        {
            if (genre == null) return BadRequest();
            genre.CreationDate = DateTime.Now;
            genre.Id = -1;
            var gL = await context.Genres.ToListAsync();
            for (int i = 0; i < gL.Count(); i++)
            {
                if (gL[i].Id != i + 1)
                {
                    genre.Id = i + 1;
                    break;
                }
            }
            if (genre.Id == -1) genre.Id = gL.Count + 1;
            context.Genres.Add(genre);
            await context.SaveChangesAsync();
            return Ok(genre);
        }

        // PUT api/<controller>
        [HttpPut]
        public async Task<ActionResult<Genres>> Put(Genres genre)
        {
            if (genre == null) return BadRequest();
            if (!context.Genres.Any(g => g.Id == genre.Id)) return NotFound();
            genre.CreationDate = DateTime.Now;
            context.Genres.Update(genre);
            await context.SaveChangesAsync();
            return Ok(genre);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Genres>> Delete(int id)
        {
            Genres genre = context.Genres.FirstOrDefault(g => g.Id == id);
            if (genre == null) return NotFound();
            context.Genres.Remove(genre);
            await context.SaveChangesAsync();
            return Ok(genre);
        }
    }
}
