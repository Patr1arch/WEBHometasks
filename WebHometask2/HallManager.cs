using System;
using System.Collections.Generic;
using System.Text;

namespace WebHometask2
{
    class HallManager
    {
        private List<Hall> halls;

        public HallManager()
        {
            halls = new List<Hall>();
        }

        public List<Hall> GetAllHalls()
        {
            return halls;
        }

        public void MakeHall(decimal id, string name, List<Seat> seats, double hallRatio) =>
         halls.Add(new Hall(id, name, seats, hallRatio));
        
        public void EditHall(decimal id, string newName, List<Seat> newSeats, double newHallRatio)
        {
            halls[halls.FindIndex(h => h.id == id)].name = newName;
            halls[halls.FindIndex(h => h.id == id)].seats = newSeats;
            halls[halls.FindIndex(h => h.id == id)].hallRatio = newHallRatio;
        }

        public Hall GetHallById(decimal id)
        {
            return halls.Find(h => h.id == id);
        }

        public void DeleteHall(decimal id) => halls.Remove(GetHallById(id));

    }
}
