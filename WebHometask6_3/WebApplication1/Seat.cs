using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int HallId { get; set; }
        public virtual Halls Hall { get; set; }

    }
}
