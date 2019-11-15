using System;
using System.Collections.Generic;
using System.Text;

namespace WebHometask2
{
    class Seat
    {
        public decimal row;
        public decimal placeCol;
        
        public double seatRatio;

        public Seat(decimal row, decimal placeCol, double seatRatio) 
        {
            this.row = row;
            this.placeCol = placeCol;
            this.seatRatio = seatRatio;
        }

    }
}
