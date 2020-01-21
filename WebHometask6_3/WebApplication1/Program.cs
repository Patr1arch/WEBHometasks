using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            //var context_ = new cinemadbContext();
            //var unP = new Companies { Id = 3, Name = "Universal Pictures" };
            //context_.Genres.AddRange(
            //    new Genres { Id = 3, Name = "Drama"},
            //    new Genres { Id = 4, Name = "Comedy"},
            //    new Genres { Id = 5, Name = "Thriller"}
            //    );
            //context_.Companies.AddRange(
            //    unP
            //    );
            //context_.Films.AddRange(
            //    new Films { Id = 2, CompanyId = 3, Name = "King Kong", Company = unP}
            //    );

            //for (int i = 1; i <= 20; i++)
            //{
            //    context_.Seats.Add(new Seat
            //    {
            //        Id = i,
            //        Column = i % 10 == 0 ? 10 : i % 10,
            //        Row = i % 10 == 0 ? i / 10 : i / 10 + 1,
            //        HallId = 1,
            //        Hall = context_.Halls.FirstOrDefault()
            //    });
            //}
            //context_.GenreFilms.AddRange(
            //    new GenreFilm
            //    {
            //        Id = 1,
            //        FilmId = 1,
            //        GenreId = 3,
            //        //Genre = context_.Genres.ToList().Find(g => g.Id == 3),
            //        Film = context_.Films.ToList().Find(f => f.Id == 1)
            //    },
            //    new GenreFilm
            //    {
            //        Id = 2,
            //        FilmId = 1,
            //        GenreId = 5,
            //        //Genre = context_.Genres.ToList().Find(g => g.Id == 5),
            //        Film = context_.Films.ToList().Find(f => f.Id == 1)
            //    },
            //    new GenreFilm
            //    {
            //        Id = 3,
            //        FilmId = 2,
            //        GenreId = 1,
            //        //Genre = context_.Genres.ToList().Find(g => g.Id == 1),
            //        Film = context_.Films.ToList().Find(f => f.Id == 2)
            //    },
            //    new GenreFilm
            //    {
            //        Id = 4,
            //        FilmId = 2,
            //        GenreId = 3,
            //        //Genre = context_.Genres.ToList().Find(g => g.Id == 3),
            //        Film = context_.Films.ToList().Find(f => f.Id == 2)
            //    },
            //    new GenreFilm
            //    {
            //        Id = 5,
            //        FilmId = 2,
            //        GenreId = 5,
            //        //Genre = context_.Genres.ToList().Find(g => g.Id == 5),
            //        Film = context_.Films.ToList().Find(f => f.Id == 2)
            //    });
            ////context_.GenreFilms.Add(new GenreFilm
            //{
            //    Id = 1,
            //    GenreId = 3,
            //    //Genre = context_.Genres.ToList().Find(g => g.Id == 3),
            //    FilmId = 1,
            //    Film = context_.Films.ToList().Find(f => f.Id == 1)
            //}
            //);
            //context_.Halls.Add(new Halls { Id = 2, Name = "Severniy", HallRatio = 1.0 });
            //context_.Seats.Add(new Seat { Id = 21, Column = 42, Row = 42, HallId = 2 });

            //var seatList = context_.Seats.ToList();

            //context_.Halls.Remove(context_.Halls.FirstOrDefault());
            //context_.Halls.Add(new Halls { Id = 1, Seats = seatList, Name = "Yuzhniy", HallRatio = 0.8 });

            //context_.SaveChanges();
            //var t = context_.Genres.ToList().Find(g => g.Id == 3);
            //var deb = 4;
            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;

            //    try
            //    {
            //        var context = new cinemadbContext();
            //        SampleData.Initialize(context);
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex, "An error occurred seeding the DB.");
            //    }
            //}
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
