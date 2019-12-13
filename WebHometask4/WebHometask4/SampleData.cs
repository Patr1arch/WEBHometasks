using System.Linq;
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
                        Name = "Warner Brothers"
                    },
                    new Company
                    {
                        Id = 2,
                        Name = "Disney"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
