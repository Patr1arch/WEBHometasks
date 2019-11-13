using System;
using System.Collections.Generic;
using System.Text;

namespace WebHometask2
{
    public class Film
    {
        public decimal id;
        public string name;
        public string ageRate;
        public List<Genre> genres;
        public Company company;
        public decimal duration;
        public double filmaRatio;

        public Film(decimal id, string name, string ageRate, List<Genre> genres, Company company,
            decimal duration, double filmaRatio)
        {
            this.id = id;
            this.name = name;
            this.ageRate = ageRate;
            this.genres = genres;
            this.company = company;
            this.duration = duration;
            this.filmaRatio = filmaRatio;
        }


    }

}
