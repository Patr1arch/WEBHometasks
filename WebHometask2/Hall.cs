using System;
using System.Collections.Generic;
using System.Text;

namespace WebHometask2
{
    class Hall
    {
        public decimal id;
        public string name;
        public List<Seat> seats;
        public double hallRatio;

        public Hall(decimal id, string name, List<Seat> seats, double hallRatio) 
        {
            this.id = id;
            this.name = name;
            this.seats = seats;
            this.hallRatio = hallRatio;
        }
    }
}
