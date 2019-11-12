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

            // Making all Managers

            GenreManager myGenreManager = new GenreManager();
            

            Stream.WriteLine("Welcome to Baranov's Cinema Model!");
            bool isExited = false;
            while (true)
            {
                Stream.WriteLine(separator);
                if (isExited) break;
                Stream.WriteLine("If you want to be Genre Manager input 'Genre'");


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
