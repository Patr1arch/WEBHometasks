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
    }
}
