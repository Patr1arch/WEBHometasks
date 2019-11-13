using System;
using System.Collections.Generic;
using Stream = System.Console;

namespace WebHometask2
{
    class Program
    {
        static void Main(string[] args)
        {
            string separator = "-----------------------------------------------------------------------------------------";
            //FilmManager.Film test1 = new FilmManager.Film(0, "Ababa");
            //FilmManager.Film test2 = new FilmManager.Film(1, "hhh");

            // Initialization all Managers

            GenreManager myGenreManager = new GenreManager();
            CompanyManager myCompanyManager = new CompanyManager();
            FilmManager myfilmManager = new FilmManager();

            // DEBUG: Some Genres and Companies in their lists
            {
                myGenreManager.MakeGenre(0, "Thriller");
                myGenreManager.MakeGenre(1, "Horror");
                myGenreManager.MakeGenre(2, "Comedy");
                myGenreManager.MakeGenre(3, "Drama");

                myCompanyManager.MakeCompany(0, "Warner Brothers");
                myCompanyManager.MakeCompany(1, "Disney");
                myCompanyManager.MakeCompany(2, "Universal Pictures");

                List<Genre> tmpGenres = new List<Genre>();
                tmpGenres.Add(myGenreManager.GetGenreById(1));
                tmpGenres.Add(myGenreManager.GetGenreById(2));
                tmpGenres.Add(myGenreManager.GetGenreById(3));
                myfilmManager.MakeFilm(0, "Joker", "18+", tmpGenres, myCompanyManager.GetCompanyById(0), 150, 1.5);
            }
            

            Stream.WriteLine("Welcome to Baranov's Cinema Model!");
            bool isExited = false;
            while (true)
            {
                Stream.WriteLine(separator);
                if (isExited) break;
                Stream.WriteLine("If you want to be Genre Manager input 'Genre'");
                Stream.WriteLine("If you want to be Company Manager input 'Company'");
                Stream.WriteLine("If you want to be Film Manager input 'Film'");

                Stream.WriteLine("If you want to exit input 'Exit'");

                string manager = Stream.ReadLine();
                Stream.WriteLine(separator);
                switch (manager)
                {
                    case "Genre":
                        Stream.WriteLine("Now you Genre Manager");
                        bool isLeaved = false;

                        while (true)
                        {
                            if (isLeaved) break;
                            PrintIdeas("Genre");
                            string action = Stream.ReadLine();
                            switch (action)
                            {
                                case "Add":
                                    bool isRepeated = true;
                                    do
                                    {
                                        Stream.WriteLine("Input id");
                                        int id = Convert.ToInt32(Stream.ReadLine());
                                        Stream.WriteLine("Input name of Genre");
                                        string name = Stream.ReadLine();
                                        myGenreManager.MakeGenre(id, name);
                                        Stream.WriteLine("Done! Would you like to add Genre Again? Y/N");
                                        if (Stream.ReadLine() == "N") isRepeated = false;
                                        else isRepeated = true;
                                    } while (isRepeated);
                                    break;

                                case "Edit":
                                    isRepeated = true;
                                    do
                                    {
                                        Stream.WriteLine("Input id");
                                        int id = Convert.ToInt32(Stream.ReadLine());
                                        Stream.WriteLine("Input edit name of Genre");
                                        string editName = Stream.ReadLine();
                                        myGenreManager.EditGenre(id, editName);
                                        Stream.WriteLine("Done! Would you like to edit genre again? Y/N");
                                        if (Stream.ReadLine() == "N") isRepeated = false;
                                        else isRepeated = true;
                                    } while (isRepeated);
                                    break;

                                case "GetAll":
                                    var genres = myGenreManager.GetAllGenres();
                                    foreach(var genre in genres)
                                    {
                                        Stream.WriteLine($"Id: {genre.id}, name: {genre.name}");
                                    }
                                    break;

                                case "Get":
                                    isRepeated = true;
                                    do
                                    {
                                        Stream.WriteLine("Input id");
                                        int id = Convert.ToInt32(Stream.ReadLine());
                                        Genre thisGenre = myGenreManager.GetGenreById(id);
                                        Stream.WriteLine($"Id: {thisGenre.id}, name: {thisGenre.name}");
                                        Stream.WriteLine("Done! Would you like to get genre again? Y/N");
                                        if (Stream.ReadLine() == "N") isRepeated = false;
                                        else isRepeated = true;
                                    } while (isRepeated);
                                    break;

                                case "Delete":
                                    isRepeated = true;
                                    do
                                    {
                                        Stream.WriteLine("Input id");
                                        int id = Convert.ToInt32(Stream.ReadLine());
                                        myGenreManager.DeleteGenre(id);
                                        Stream.WriteLine("Done! Would you line to delete Genre again? Y/N");
                                        if (Stream.ReadLine() == "N") isRepeated = false;
                                        else isRepeated = true;
                                    } while (isRepeated);
                                    break;

                                case "Leave":
                                    isLeaved = true;
                                    break;
                            }
                        }                       
                        break;

                    case "Company":
                        Stream.WriteLine("Now you Company manager");
                        isLeaved = false;

                        while (true)
                        {
                            if (isLeaved) break;
                            PrintIdeas("Company");
                            string action = Stream.ReadLine();
                            switch (action)
                            {
                                case "Add":
                                    bool isRepeated = true;
                                    do
                                    {                                      
                                        Stream.WriteLine("Input id");
                                        int id = Convert.ToInt32(Stream.ReadLine());
                                        Stream.WriteLine("Input name of Company");
                                        string name = Stream.ReadLine();
                                        myCompanyManager.MakeCompany(id, name);
                                        Stream.WriteLine("Done! Would you like to add Company Again? Y/N");
                                        if (Stream.ReadLine() == "N") isRepeated = false;
                                        else isRepeated = true;
                                    } while (isRepeated);                                   
                                    break;

                                case "Edit":
                                    isRepeated = true;
                                    do
                                    {
                                        Stream.WriteLine("Input id");
                                        int id = Convert.ToInt32(Stream.ReadLine());
                                        Stream.WriteLine("Input edit name of Company that you'd like to edit");
                                        string editName = Stream.ReadLine();
                                        myCompanyManager.EditCompany(id, editName);
                                        Stream.WriteLine("Done! Would you like to edit company again? Y/N");
                                        if (Stream.ReadLine() == "N") isRepeated = false;
                                        else isRepeated = true;
                                    } while (isRepeated);
                                    break;

                                case "Delete":
                                    isRepeated = true;
                                    do
                                    {
                                        Stream.WriteLine("input id");
                                        int id = Convert.ToInt32(Stream.ReadLine());
                                        myCompanyManager.DeleteCompany(id);
                                        Stream.WriteLine("Done! Would you like to delete another Company?Y/N");
                                        if (Stream.ReadLine() == "N") isRepeated = false;
                                        else isRepeated = true;
                                    } while (isRepeated);
                                    break;

                                case "GetAll":
                                    var companiesList = myCompanyManager.GetAllCompanies();
                                    foreach(var company in companiesList)
                                    {
                                        Stream.WriteLine($"id: {company.id}, name: {company.name}");
                                    }
                                    break;

                                case "Get":
                                    isRepeated = true;
                                    do
                                    {
                                        Stream.WriteLine("Input id");
                                        int id = Convert.ToInt32(Stream.ReadLine());
                                        Company thisCompany = myCompanyManager.GetCompanyById(id);
                                        Stream.WriteLine($"Id: {thisCompany.id}, name: {thisCompany.name}");
                                        Stream.WriteLine("Done! Would you like to get company again? Y/N");
                                        if (Stream.ReadLine() == "N") isRepeated = false;
                                        else isRepeated = true;
                                    } while (isRepeated);
                                    break;

                                case "Leave":
                                    isLeaved = true;
                                    break;

                            }
                        }
                        break;

                    case "Film":
                        Stream.WriteLine("Now you Film manager");
                        isLeaved = false;

                        while (true)
                        {
                            if (isLeaved) break;
                            PrintIdeas("Film");
                            string action = Stream.ReadLine();
                            switch (action)
                            {
                                case "Add":
                                    bool isRepeated = true;
                                    do
                                    {
                                        Stream.WriteLine("Input id");
                                        decimal id = Convert.ToInt32(Stream.ReadLine());

                                        Stream.WriteLine("Input name");
                                        string name = Stream.ReadLine();

                                        Stream.WriteLine("Input Age Rate");
                                        string ageRate = Stream.ReadLine();

                                        Stream.WriteLine("Input count of genres in film");
                                        decimal genresCount = Convert.ToInt32(Stream.ReadLine());
                                        List<Genre> genres = new List<Genre>();
                                        for (int i = 0; i < genresCount; i++)
                                        {
                                            Stream.WriteLine("Input id genre");
                                            decimal idGenre = Convert.ToInt32(Stream.ReadLine());
                                            genres.Add(myGenreManager.GetGenreById(idGenre));
                                        }

                                        Stream.WriteLine("Input company id");
                                        decimal idCompany = Convert.ToInt32(Stream.ReadLine());
                                        Company company = myCompanyManager.GetCompanyById(idCompany);

                                        Stream.WriteLine("Input a duration");
                                        decimal duration = Convert.ToInt32(Stream.ReadLine());

                                        Stream.WriteLine("Input filmRatio");
                                        double filmRartio = Convert.ToDouble(Stream.ReadLine());

                                        myfilmManager.MakeFilm(id, name, ageRate, genres, company, duration, filmRartio);

                                        Stream.WriteLine("Done! Would you like to add film again? Y/N");

                                        if (Stream.ReadLine() == "N") isRepeated = false;
                                        else isRepeated = true;
                                    } while (isRepeated);
                                    break;

                                case "GetAll":
                                    List <Film> films = myfilmManager.GetAllFilms();
                                    foreach(var film in films)
                                    {
                                        Stream.WriteLine($"id: {film.id}, name: {film.name}, age rate: {film.ageRate}, genres:");
                                        foreach(var genre in film.genres)
                                        {
                                            Stream.WriteLine($"{genre.name}");
                                        }

                                        Stream.WriteLine($"company: {film.company}, duration: {film.duration}, filmRatio: {film.filmaRatio}");
                                        Stream.WriteLine();
                                    }
                                    break;
                                case "Delete":
                                    isRepeated = true;
                                    do
                                    {
                                        Stream.WriteLine("input id");
                                        decimal id = Convert.ToInt32(Stream.ReadLine());
                                        myfilmManager.DeleteFilm(id);
                                        Stream.WriteLine("Done! Would you like to delete film agin? Y/N");

                                        if (Stream.ReadLine() == "N") isRepeated = false;
                                        else isRepeated = true;
                                    } while (isRepeated);
                                    break;

                                case "Leave":
                                    isLeaved = true;
                                    break;

                            }
                        }
                        break;

                    case "Exit":
                        isExited = true;
                        break;
                }
            }

            //Stream.WriteLine("Hello! Choose manager, please '\n' If you want to be Genre Manager input 'Genre'");

            

            ///DEBUG 
            {
                //GenreManager myGenreManager = new GenreManager();
                //myGenreManager.MakeGenre(0, "Alladin");
                //myGenreManager.MakeGenre(1, "Joker");
                //foreach (var i in myGenreManager.GetAllGenres())
                //{
                //    Stream.WriteLine(i.name);
                //}

                //myGenreManager.DeleteGenre(0);
                //foreach (var i in myGenreManager.GetAllGenres())
                //{
                //    Stream.WriteLine(i.name);
                //}

                //myGenreManager.EditGenre(1, "DarkKnight");
                //Stream.WriteLine('\n' + myGenreManager.GetGenreById(1));

                //Stream.ReadKey();
            }
            
        }

        static void PrintIdeas(string template)
        {
            Stream.WriteLine("-----------------------------------------------------------------------------------------");
            Stream.WriteLine($"If you want to add {template} input 'Add'");
            Stream.WriteLine($"If you want to edit {template} input 'Edit'");
            Stream.WriteLine($"If you want to delete {template} input 'Delete'");
            Stream.WriteLine($"If you want to get all {template}'s input 'GetAll'");
            Stream.WriteLine($"If you want to get {template} by id input 'Get'");
            Stream.WriteLine($"If you want to leave {template} Manager input 'Leave'");
        }
    }
}
