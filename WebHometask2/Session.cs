using System;
using System.Collections.Generic;
using System.Text;

namespace WebHometask2
{
    class Session
    {
        public decimal id;
        public string name;
        public string dateStart;
        public string timeStart;
        public Hall hall;
        public Film film;
        public List<Tuple<Tuple<decimal, decimal>, bool>> seatBusy;
        public double sessionRatio;

        public Session(decimal id, string name, string dateStart, string timeStart, Hall hall,
            Film film, double sessionRatio)
        {
            this.id = id;
            this.name = name;
            this.timeStart = timeStart;
            this.hall = hall;
            this.dateStart = dateStart;
            seatBusy = new List<Tuple<Tuple<decimal, decimal>, bool>>();
            foreach(var i in this.hall.seats)
            {
                seatBusy.Add(new Tuple<Tuple<decimal, decimal>, bool>(new Tuple<decimal, decimal>
                    (i.row, i.placeCol), false));
            }
            this.sessionRatio = sessionRatio;
        }
    }
}
