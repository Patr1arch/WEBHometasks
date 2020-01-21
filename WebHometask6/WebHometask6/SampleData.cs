using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHometask6
{
    public class SampleData
    {
        public static void Initialize(cinemadbContext context)
        {
            if (!context.Genres.Any())
            {
                context.Genres.AddRange(
                    new Genres
                    {
                        Id = 1,
                        Name = "Action",
                        CreationDate = DateTime.Now
                    },
                    new Genres
                    {
                        Id = 2,
                        Name = "Horror",
                        CreationDate = DateTime.Now
                    }
                    );
                context.SaveChanges();
            }
            var warBr = new Companies
            {
                Id = 1,
                Name = "Warner Brothers",
                CreationDate = DateTime.Now
            };
            if (!context.Companies.Any())
            {
                context.Companies.AddRange(
                    warBr,
                    new Companies
                    {
                        Id = 2,
                        Name = "Disney",
                        CreationDate = DateTime.Now
                    }
                    );
                context.SaveChanges();
            }
            if (!context.Films.Any())
            {
                context.Films.Add(new Films { AgeRate = "18+", CompanyId = 1, Company = warBr, Id = 0, Name = "Joker" });
                context.SaveChanges();
            }
            if (!context.Halls.Any())
            {
                context.Halls.Add(new Hall { Id = 0, Name = "Yuzhniy", HallRatio = 0.8 });
                context.SaveChanges();
            }
        }
    }
}
