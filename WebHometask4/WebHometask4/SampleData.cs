using System.Linq;
using System;
using WebHometask4.Models;

namespace WebHometask4
{
    public class SampleData
    {
        public static void Initialize(FilmingContext context)
        {
            if (!context.Genres.Any())
            {
                context.Genres.AddRange(
                    new Genre
                    {
                        Id = 1,
                        Name = "Action"
                    },
                    new Genre
                    {
                        Id = 2,
                        Name = "Horror"
                    }
                    );
                context.SaveChanges();
            }
            if (!context.Companies.Any())
            {
                context.Companies.AddRange(
                    new Company
                    {
                        Id = 1,
                        Name = "Warner Brothers",
                        CreationDate = DateTime.Now
                    },
                    new Company
                    {
                        Id = 2,
                        Name = "Disney",
                        CreationDate = DateTime.Now
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
