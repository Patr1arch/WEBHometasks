using System;
using System.Collections.Generic;

namespace WebHometask7.Models
{
    public partial class Halls
    {
        public Halls()
        {
            Seats = new HashSet<Seats>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double HallRatio { get; set; }

        public virtual ICollection<Seats> Seats { get; set; }
    }
}
