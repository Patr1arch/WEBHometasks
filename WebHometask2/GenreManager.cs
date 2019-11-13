using System;
using System.Collections.Generic;
using System.Text;

namespace WebHometask2
{
    public class GenreManager
    {
        private List<Genre> genreList;
        public void MakeGenre(decimal id, string name)
        {
            Genre genre = new Genre(id, name);
            genreList.Add(genre);
        }

        public GenreManager()
        {
            genreList = new List<Genre>();
        }

        public void DeleteGenre(decimal id) => genreList.Remove(genreList.Find(g => g.id == id));

        public void EditGenre(decimal id, string editName) => genreList[genreList.FindIndex(0, genreList.Count,
            g => g.id == id)].name = editName;

        public Genre GetGenreById(decimal id)
        {
            return genreList.Find(g => g.id == id);
        }

        public List<Genre> GetAllGenres()
        {
            return genreList;
        }
    }
}
