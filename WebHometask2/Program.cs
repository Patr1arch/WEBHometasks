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
            FilmManager myFilmManager = new FilmManager();
            SeatManager mySeatManager = new SeatManager();
            HallManager myHallManager = new HallManager();
            SessionManager mySessionManager = new SessionManager();
            Cashier myCashier = new Cashier();

            // DEBUG: Some Genres and Companies in their lists, film and one hall
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
                myFilmManager.MakeFilm(0, "Joker", "18+", tmpGenres, myCompanyManager.GetCompanyById(0), 150, 1.5);

                List<Seat> tmpSeats = new List<Seat>();
                for (var i = 1; i < 6; i++)
                {
                    for (var j = 1; j < 6; j++)
                    {
                        tmpSeats.Add(new Seat(i, j, 1));
                    }
                }
                myHallManager.MakeHall(0, "Yuzniy", tmpSeats, 1);
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
                Stream.WriteLine("If you want to be Hall Manager input 'Hall'");
                Stream.WriteLine("If ypu want to be Session Manager input 'Session'");
                Stream.WriteLine("If you want to be Cashier input 'Cashier'");
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
                                        if (thisCompany == null) break;
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

                                        myFilmManager.MakeFilm(id, name, ageRate, genres, company, duration, filmRartio);

                                        Stream.WriteLine("Done! Would you like to add film again? Y/N");

                                        if (Stream.ReadLine() == "N") isRepeated = false;
                                        else isRepeated = true;
                                    } while (isRepeated);
                                    break;

                                case "GetAll":
                                    List <Film> films = myFilmManager.GetAllFilms();
                                    foreach(var film in films)
                                    {
                                        Stream.WriteLine($"id: {film.id}, name: {film.name}, age rate: {film.ageRate}, genres:");
                                        foreach(var genre in film.genres)
                                        {
                                            Stream.WriteLine($"{genre.name}");
                                        }

                                        Stream.WriteLine($"company: {film.company.name}, duration: {film.duration}, filmRatio: {film.filmaRatio}");
                                        Stream.WriteLine();
                                    }
                                    break;

                                case "Delete":
                                    isRepeated = true;
                                    do
                                    {
                                        Stream.WriteLine("input id");
                                        decimal id = Convert.ToInt32(Stream.ReadLine());
                                        myFilmManager.DeleteFilm(id);
                                        Stream.WriteLine("Done! Would you like to delete film agin? Y/N");

                                        if (Stream.ReadLine() == "N") isRepeated = false;
                                        else isRepeated = true;
                                    } while (isRepeated);
                                    break;

                                case "Get":
                                    isRepeated = true;
                                    do
                                    {
                                        Stream.WriteLine("input id");
                                        Film film = myFilmManager.GetFilmById(Convert.
                                            ToInt32(Stream.ReadLine()));
                                        Stream.WriteLine($"id: {film.id}, name: {film.name}, age rate: {film.ageRate}, genres:");
                                        foreach (var genre in film.genres)
                                        {
                                            Stream.WriteLine($"{genre.name}");
                                        }

                                        Stream.WriteLine($"company: {film.company.name}, duration: {film.duration}, filmRatio: {film.filmaRatio}");
                                        Stream.WriteLine("Done! Would you like to get another film? Y/N");
                                        if (Stream.ReadLine() == "N") isRepeated = false;
                                        else isRepeated = true;

                                    } while (isRepeated);

                                    break;

                                case "Edit":
                                    isRepeated = true;
                                    do
                                    {
                                        Stream.WriteLine("input id");
                                        decimal id = Convert.ToInt32(Stream.ReadLine());
                                        Stream.WriteLine("input new name");
                                        string newName = Stream.ReadLine();
                                        Stream.WriteLine("input new age rate");
                                        string newAgeRate = Stream.ReadLine();

                                        Stream.WriteLine("Input new count of genres in film");
                                        decimal newGenresCount = Convert.ToInt32(Stream.ReadLine());
                                        List<Genre> newGenres = new List<Genre>();
                                        for (int i = 0; i < newGenresCount; i++)
                                        {
                                            Stream.WriteLine("Input id genre");
                                            decimal idGenre = Convert.ToInt32(Stream.ReadLine());
                                            newGenres.Add(myGenreManager.GetGenreById(idGenre));
                                        }

                                        Stream.WriteLine("Input new company id");
                                        var newCompany = myCompanyManager.GetCompanyById(
                                            Convert.ToInt32(Stream.ReadLine()));

                                        Stream.WriteLine("Input new duration");
                                        decimal newDuration = Convert.ToInt32(Stream.ReadLine());

                                        Stream.WriteLine("Input new filmRatio");
                                        double newRatio = Convert.ToDouble(Stream.ReadLine());

                                        myFilmManager.EditFilm(id, newName, newAgeRate, newGenres,
                                            newCompany, newDuration, newRatio);

                                        Stream.WriteLine("Done! Would you like to edit a film again? Y/N");
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

                    case "Hall":
                        Stream.WriteLine("Now you a Hall manager");
                        isLeaved = false;

                        while (true)
                        {
                            if (isLeaved) break;
                            PrintIdeas("Hall");
                            string action = Stream.ReadLine();
                            switch (action)
                            {
                                case "Add":
                                    bool isRepeated = true;
                                    do
                                    {
                                        Stream.WriteLine("Input id");
                                        decimal id = Convert.ToInt32(Stream.ReadLine());
                                        Stream.WriteLine("Input name of hall");
                                        string name = Stream.ReadLine();
                                        Stream.WriteLine("Input count of seats in your hall");
                                        decimal seatCount = Convert.ToInt32(Stream.ReadLine());

                                        List<Seat> hallSeats = new List<Seat>();
                                        for (var i = 0; i < seatCount; i++)
                                        {
                                            Stream.WriteLine("Input row");
                                            decimal seatRow = Convert.ToInt32(Stream.ReadLine());
                                            Stream.WriteLine("Input placeCol");
                                            decimal seatPlaceCol = Convert.ToInt32(Stream.ReadLine());                                    
                                            Stream.WriteLine("Input seatRatio");
                                            double seatRatio = Convert.ToDouble(Stream.ReadLine());
                                            hallSeats.Add(mySeatManager.MakeSeat(seatRow, seatPlaceCol, seatRatio));
                                        }

                                        Stream.WriteLine("Input hallRatio");
                                        double hallRatio = Convert.ToDouble(Stream.ReadLine());
                                        myHallManager.MakeHall(id, name, hallSeats, hallRatio);
                                        Stream.WriteLine("Done! Would you like to make new Hall? Y/N");
                                        if (Stream.ReadLine() == "N") isRepeated = false;
                                        else isRepeated = true;
                                    } while (isRepeated);
                                    break;

                                case "GetAll":
                                    var list = myHallManager.GetAllHalls();
                                    foreach (var i in list)
                                    {
                                        Stream.WriteLine($"id: {i.id}, name: {i.name}, hall ratio:{i.hallRatio}");
                                        foreach (var k in i.seats)
                                        {
                                            Stream.WriteLine($"row: {k.row}, col: {k.placeCol}, seat ratio: {k.seatRatio}");
                                        }
                                    }
                                    
                                    break;

                                case "Get":
                                    isRepeated = true;
                                    do
                                    {
                                        Stream.WriteLine("Input id");
                                        decimal id = Convert.ToInt32(Stream.ReadLine());
                                        var hall = myHallManager.GetHallById(id);
                                        Stream.WriteLine($"id: {hall.id}, name: {hall.name}, hallRatio: {hall.hallRatio}");
                                        foreach (var k in hall.seats)
                                        {
                                            Stream.WriteLine($"row: {k.row}, col: {k.placeCol}, seat ratio: {k.seatRatio}");
                                        }

                                        Stream.WriteLine("Done! Would you like to get another hall? Y/N");
                                        if (Stream.ReadLine() == "N") isRepeated = false;
                                        else isRepeated = true;
                                    } while (isRepeated);
                                    break;

                                case "Edit":
                                    isRepeated = true;
                                    do
                                    {
                                        Stream.WriteLine("Input id");
                                        decimal id = Convert.ToDecimal(Stream.ReadLine());

                                        Stream.WriteLine("Input new name of hall");
                                        string newName = Stream.ReadLine();

                                        Stream.WriteLine("Input new Hall ratio");
                                        double newRatio = Convert.ToDouble(Stream.ReadLine());

                                        Stream.WriteLine("Input new count of seats in your hall");
                                        decimal newSeatCount = Convert.ToInt32(Stream.ReadLine());

                                        List<Seat> newHallSeats = new List<Seat>();
                                        for (var i = 0; i < newSeatCount; i++)
                                        {
                                            Stream.WriteLine("Input row");
                                            decimal seatRow = Convert.ToInt32(Stream.ReadLine());
                                            Stream.WriteLine("Input placeCol");
                                            decimal seatPlaceCol = Convert.ToInt32(Stream.ReadLine());
                                            Stream.WriteLine("Input seatRatio");
                                            double seatRatio = Convert.ToDouble(Stream.ReadLine());
                                            newHallSeats.Add(mySeatManager.MakeSeat(seatRow, seatPlaceCol, seatRatio));
                                        }

                                        myHallManager.EditHall(id, newName, newHallSeats, newRatio);

                                        Stream.WriteLine("Done! Would you like to edit another hall? Y/N");
                                        if (Stream.ReadLine() == "N") isRepeated = false;
                                        else isRepeated = true;

                                    } while (isRepeated);
                                    break;

                                case "Delete":
                                    isRepeated = true;
                                    do
                                    {
                                        Stream.WriteLine("Input id");
                                        decimal id = Convert.ToInt32(Stream.ReadLine());
                                        myHallManager.DeleteHall(id);
                                        Stream.WriteLine("Done! Would you like to delete another hall? Y/N");
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

                    case "Session":
                        Stream.WriteLine("Now you a Session Manager");                        
                        isLeaved = false;
                        while (true)
                        {
                            if (isLeaved) break;
                            PrintIdeas("Session");
                            string action = Stream.ReadLine();
                            switch (action)
                            {
                                case "Add":
                                    bool isRepeated = true;

                                    do
                                    {
                                        Stream.WriteLine("Input id");
                                        decimal id = Convert.ToInt32(Stream.ReadLine());
                                        Stream.WriteLine("Input name of session");
                                        string name = Stream.ReadLine();
                                        Stream.WriteLine("Input date of start Session (dd.mm.yyyy)");
                                        string dateStart = Stream.ReadLine();
                                        Stream.WriteLine("Input time of start Session (hh.mm)");
                                        string timeStart = Stream.ReadLine();
                                        Stream.WriteLine("Input id of your hall");
                                        Hall sessionHall = myHallManager.GetHallById(Convert.ToInt32(
                                            Stream.ReadLine()));
                                        Stream.WriteLine("Input id of your film");
                                        Film sessionFilm = myFilmManager.GetFilmById(Convert.ToInt32(
                                            Stream.ReadLine()));
                                        Stream.WriteLine("Input an Session Ratio");
                                        double sessionRatio = Convert.ToDouble(Stream.ReadLine());

                                        mySessionManager.sessionsList.Add(new Session(
                                            id, name, dateStart, timeStart, sessionHall, sessionFilm,
                                            sessionRatio));

                                        Stream.WriteLine("Done! Would you like to add new session? Y/N");
                                        if (Stream.ReadLine() == "N") isRepeated = false;
                                        else isRepeated = true;
                                    } while (isRepeated);

                                    break;

                                case "GetAll":
                                    var sessionList = mySessionManager.GetAllSessionsInList();
                                    foreach(var i in sessionList)
                                    {
                                        Stream.WriteLine($"id: {i.id}, name: {i.name}, date start: {i.dateStart}");
                                        Stream.WriteLine($"time start: {i.timeStart}, session ratio: {i.sessionRatio}");
                                        Stream.WriteLine($"hall id: {i.hall.id}");
                                    }
                                    break;

                                case "Edit":
                                    isRepeated = true;
                                    do
                                    {
                                        Stream.WriteLine("Input id");
                                        decimal id = Convert.ToDecimal(Stream.ReadLine());

                                        Stream.WriteLine("Input new name of session");
                                        string newName = Stream.ReadLine();

                                        Stream.WriteLine("Input new start date session");
                                        string newStartDate = Stream.ReadLine();

                                        Stream.WriteLine("Input new start time session");
                                        string newStartTime = Stream.ReadLine();

                                        Stream.WriteLine("Input id new hall");
                                        Hall newHall = myHallManager.GetHallById(Convert.ToDecimal(
                                            Stream.ReadLine()));

                                        Stream.WriteLine("Input id new film");
                                        Film newfilm = myFilmManager.GetFilmById(Convert.ToDecimal(
                                            Stream.ReadLine()));

                                        Stream.WriteLine("Input new session ratio");
                                        double newRatio = Convert.ToDouble(Stream.ReadLine());

                                        mySessionManager.EditSession(id, newName, newStartDate,
                                            newStartTime, newHall, newfilm, newRatio);

                                        Stream.WriteLine("Done! Would you like to delete another session? Y/N");
                                        if (Stream.ReadLine() == "N") isRepeated = false;
                                        else isRepeated = true;
                                    } while (isRepeated);
                                    break;

                                case "Delete":
                                    isRepeated = true;
                                    do
                                    {
                                        Stream.WriteLine("Input id");
                                        decimal id = Convert.ToDecimal(Stream.ReadLine());
                                        mySessionManager.DeleteSession(id);
                                        Stream.WriteLine("Done! Would you like to delete another session? Y/N");
                                        if (Stream.ReadLine() == "N") isRepeated = false;
                                        else isRepeated = true;
                                    } while (isRepeated);
                                    break;

                                case "Get":
                                    isRepeated = true;
                                    do
                                    {
                                        Stream.WriteLine("Input id");
                                        Session session = mySessionManager.GetSessionById(Convert.
                                            ToDecimal(Stream.ReadLine()));
                                        Stream.WriteLine($"id: {session.id}, name: {session.name}");
                                        Stream.WriteLine($"start date: {session.dateStart}, time start: {session.timeStart}");
                                        Stream.WriteLine($"hall id: {session.hall.name}, film id: {session.film.id}, session ratio: {session.sessionRatio}");
                                        Stream.WriteLine("Done! Would you like to delete another session? Y/N");
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

                    case "Cashier":
                        Stream.WriteLine("Now you a Cashier");
                        isLeaved = false;
                        while (true)
                        {
                            if (isLeaved) break;
                            Stream.WriteLine("If you want to view all valid Seats input 'getValid'");
                            Stream.WriteLine("If you want to buy a ticket input 'Ticket'");
                            Stream.WriteLine("If you want to leave Cashier input 'Leave'");

                            string action = Stream.ReadLine();
                            switch (action)
                            {
                                case "getValid":
                                    Stream.WriteLine("Input a session id");
                                    decimal id = Convert.ToDecimal(Stream.ReadLine());
                                    var list = myCashier.getAllValidSeats(mySessionManager.
                                        GetSessionById(id));
                                    foreach(var i in list)
                                    {
                                        Stream.WriteLine($"row: {i.row}, col: {i.placeCol}");
                                    }

                                    break;

                                case "Ticket":
                                    Stream.WriteLine("Input a session id");
                                    Session session = mySessionManager.GetSessionById(Convert.
                                        ToDecimal(Stream.ReadLine()));
                                    Stream.WriteLine("Input a row");
                                    decimal row = Convert.ToDecimal(Stream.ReadLine());
                                    Stream.WriteLine("Input a column");
                                    decimal col = Convert.ToDecimal(Stream.ReadLine());

                                    decimal cost = myCashier.CountCost(session, row, col);
                                    Stream.WriteLine($"It was cost {cost}. Are you agree? Y/N");
                                    if (Stream.ReadLine() == "Y") myCashier.SellTicket(session, row, col);
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
