using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class GenreFilm
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        //public virtual Genres Genre { get; set; }
        public int FilmId { get; set; }
        public virtual Films Film { get; set; }
    }
}
