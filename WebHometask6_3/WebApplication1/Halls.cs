using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Halls
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double HallRatio { get; set; }
        public virtual List<Seat> Seats { get; set; }

    }
}
