using System;
using System.Collections.Generic;
using System.Text;

namespace WebHometask2
{
    class FilmManager
    {
        private List<Film> filmsList;

        public FilmManager()
        {
            filmsList = new List<Film>();
        }

        public void MakeFilm(decimal id, string name, string ageRate, List<Genre> genres, Company company,
            decimal duration, double filmRatio)
        {
            Film film = new Film(id, name, ageRate, genres, company, duration, filmRatio);
            filmsList.Add(film);
        }

        public List<Film> GetAllFilms() { return filmsList;  }

        public void DeleteFilm(decimal id) => filmsList.Remove(filmsList.Find(g => g.id == id));

        public Film GetFilmById(decimal id)
        {
            return filmsList.Find(f => f.id == id);
        }

        public void EditFilm(decimal id, string name, string ageRate, List<Genre> genres,
            Company company, decimal duration, double filmRatio)
        {
            filmsList.Find(f => f.id == id).name = name;
            filmsList.Find(f => f.id == id).ageRate = ageRate;
            filmsList.Find(f => f.id == id).genres = genres;
            filmsList.Find(f => f.id == id).company = company;
            filmsList.Find(f => f.id == id).duration = duration;
            filmsList.Find(f => f.id == id).filmaRatio = filmRatio;
        }
    }
}
