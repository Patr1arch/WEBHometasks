using System;
using System.Collections.Generic;
using System.Text;

namespace WebHometask2
{
    class Cashier
    {
        public List<Seat> getAllValidSeats(Session session)
        {
            List <Seat> validSeats = new List<Seat>();
            var tmp = session.seatBusy.FindAll(s => s.Item2 == false);
            foreach (var i in tmp)
            {
                validSeats.Add(session.hall.seats.Find(y => y.row == i.Item1.Item1
                && y.placeCol == i.Item1.Item2));
            }

            return validSeats;
        }

        public decimal CountCost(Session session, decimal row, decimal col)
        {
            double cost = 250;
            cost *= session.sessionRatio * session.hall.hallRatio * session.film.filmaRatio
            * session.hall.seats.Find(s => s.row == row && s.placeCol == col).seatRatio;

            return Convert.ToDecimal(cost);
        }

        public void SellTicket(Session session, decimal row, decimal col)
        {          
            session.seatBusy.Remove(session.seatBusy.Find(sb => sb.Item1.Item1 == row && sb.Item1.Item2 == col)); // Костыль, да
            session.seatBusy.Add(new Tuple<Tuple<decimal, decimal>, bool>(new Tuple<decimal, decimal>
                (row, col), true));  
        }
    }
}
