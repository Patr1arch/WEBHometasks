using System;
using System.Collections.Generic;

namespace WebHometask7.Models
{
    public partial class GenreFilms
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public int FilmId { get; set; }
    }
}
