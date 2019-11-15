using System;
using System.Collections.Generic;
using System.Text;

namespace WebHometask2
{
    class SeatManager
    {
        public Seat MakeSeat(decimal row, decimal placeCol, double seatRatio)
        {
            return new Seat(row, placeCol, seatRatio);
        }

        public void EditSeat(Seat seat, decimal newRow, decimal newPlaceCol, double newSeatRatio)
        {
            seat.seatRatio = newSeatRatio;
            seat.row = newRow;
            seat.placeCol = newPlaceCol;
        }


    }
}
