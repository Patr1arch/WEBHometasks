using System;
using System.Collections.Generic;
using System.Text;

namespace WebHometask2
{
    class SessionManager
    {
        public List<Session> sessionsList;

        public SessionManager()
        {
            sessionsList = new List<Session>();
        }

        public void MakeSession(decimal id, string name, string dateStart, string timeStartm, Hall hall, Film film,
            double sessionRation)
        {
            sessionsList.Add(new Session(id, name,dateStart ,timeStartm, hall, film, sessionRation));
        }

        public List<Session> GetAllSessionsInList()
        {
            return sessionsList;
        }

        public Session GetSessionById(decimal id)
        {
            return sessionsList.Find(s => s.id == id);
        }

        public void EditSession(decimal id, string newName, string newDateStart, string newTimeStart,
            Hall newHall, Film newFilm, double newRatio)
        {
            sessionsList.Find(s => s.id == id).name = newName;
            sessionsList.Find(s => s.id == id).dateStart = newDateStart;
            sessionsList.Find(s => s.id == id).timeStart = newTimeStart;
            sessionsList.Find(s => s.id == id).hall = newHall;
            sessionsList.Find(s => s.id == id).film = newFilm;
            var newSeatBusy = new List<Tuple<Tuple<decimal, decimal>, bool>>();
            foreach (var i in sessionsList.Find(s => s.id == id).hall.seats)
            {
                newSeatBusy.Add(new Tuple<Tuple<decimal, decimal>, bool>(new Tuple<decimal, decimal>
                    (i.row, i.placeCol), false));
            }
            sessionsList.Find(s => s.id == id).seatBusy = newSeatBusy;
            sessionsList.Find(s => s.id == id).sessionRatio = newRatio;
        }

        public void DeleteSession(decimal id)
        {
            sessionsList.Remove(sessionsList.Find(s => s.id == id));
        }
    }
}
