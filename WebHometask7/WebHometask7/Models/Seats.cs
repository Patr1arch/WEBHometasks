using System;
using System.Collections.Generic;

namespace WebHometask7.Models
{
    public partial class Seats
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int HallId { get; set; }

        public virtual Halls Hall { get; set; }
    }
}
