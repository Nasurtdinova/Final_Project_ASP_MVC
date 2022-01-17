using Core;
using Final_Project_ASP_MVC.Core;
using System;
using System.Collections.Generic;
using System.Security;
//лишние библиотеки убрать
namespace Console_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            //исправить выход из программы
            Console.WriteLine("Hello, input login and password, else write Viewer");
            string login = Console.ReadLine();
            if (login == "Viewer")
            {
                while (true)
                {
                    Console.WriteLine("If you want to see, click, sportsmans - 1, commands - 2, competitions - 3, results of competitions - 4, sponsorships - 5");
                    int click = Convert.ToInt32(Console.ReadLine());
                    Done(click, "Get", " ");
                }
            }
            string password = null;
            while (true)
            {
                var key = System.Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                password += key.KeyChar;
            }
            //убрать лишние условия
            if (Connection.IsLogin(login, password))
            {
                if (login == "nasurtdinovaguz@mail.ru" && password == "2003")
                {
                    while (true)
                    {
                        Console.WriteLine("If you want to see, click, sportsmans - 1, commands - 2, competitions - 3, results of competitions - 4, sponsorships - 5");
                        int click = Convert.ToInt32(Console.ReadLine());
                        if (click == 5)
                        {
                            PrintSponsorshipsViewer("Get");
                            continue;
                        }
                        Console.WriteLine("What do you want to do 'Get', 'Add', 'Remove', 'Update'?");
                        string instruction = Console.ReadLine();
                        if (instruction == "Get")
                        {
                            Done(click, "Get", " ");
                            continue;
                        }

                        switch (click)
                        {
                            case 1:
                                Console.WriteLine("Input values: Name,Surname,Title,Image,Height,Cost,Command");
                                break;
                            case 2:
                                Console.WriteLine("Input values: Name,City,Count");
                                break;
                            case 3:
                                Console.WriteLine("Input values: Name,NameVenue,Street,Home,City,Date");
                                break;
                            case 4:
                                Console.WriteLine("Input values: Command,Compet,Rank");
                                break;
                        }
                        string values = Console.ReadLine();
                        Done(click, instruction, values);
                    }
                }
                else
                {
                    while (true)
                    {
                        Connection con = new Connection(login, password);
                        Console.WriteLine("If you want to see, click, sportsmans - 1, commands - 2, competitions - 3, results of competitions - 4, sponsorships - 5");
                        int click = Convert.ToInt32(Console.ReadLine());
                        if (click == 6)
                        {
                            continue;
                        }
                        if (click == 5)
                        {
                            Console.WriteLine("What do you want to do 'Get', 'Add', 'Remove'?");
                            string instruction = Console.ReadLine();
                            if (instruction == "Get")
                            {
                                PrintSponsorships("Get", " ");
                                continue;
                            }
                            string values = Console.ReadLine();
                            PrintSponsorships(instruction, values);
                            continue;
                        }
                        Done(click, "Get", " ");
                    }
                }
            }

            else
            {
                Console.WriteLine("No correct"); //
            }
        }

        private static void Done(int click, string command, string values)
        {
            switch (click)
            {
                case 1:
                    PrintSportsmans(command, values);
                    break;

                case 2:
                    PrintCommands(command, values);
                    break;

                case 3:
                    PrintCompetitions(command, values);
                    break;

                case 4:
                    PrintResults(command, values);
                    break;

                case 5:
                    PrintSponsorshipsViewer(command);
                    break;
            }
        }

        private static void PrintSportsmans(string command, string values)
        {
            string[] value = values.Split(',');
            switch (command)
            {
                case "Get":
                    List<Sportsman> sportsmans = ConnectionSportsmans.GetSportsmans();
                    foreach (Sportsman i in sportsmans)
                    {
                        Console.WriteLine($"{i.ID}, {i.Name}, {i.Surname}, {i.Title}, {i.Height}, {i.Cost}, {i.Command}");
                    }
                    break;
                case "Add":
                    ConnectionSportsmans.AddSportsman(new Sportsman()
                    {
                        Name = value[0],
                        Surname = value[1],
                        Title = value[2],
                        Image = value[3],
                        Height = Convert.ToInt32(value[4]),
                        Cost = Convert.ToInt32(value[5]),
                        Command = value[6]
                    });
                    break;
                case "Update":
                    ConnectionSportsmans.UpdateSportsman(new Sportsman()
                    {
                        ID = Convert.ToInt32(value[0]),
                        Name = value[1],
                        Surname = value[2],
                        Title = value[3],
                        Image = value[4],
                        Height = Convert.ToInt32(value[5]),
                        Cost = Convert.ToInt32(value[6]),
                        Command = value[7]
                    });
                    break;
                case "Remove":
                    ConnectionSportsmans.RemoveSportsman(Convert.ToInt32(value[0]));
                    break;
            }
        }

        private static void PrintCommands(string command, string values)
        {
            string[] value = values.Split(',');
            switch (command)
            {
                case "Get":
                    List<Command> commands = ConnectionCommands.GetCommands();
                    foreach (Command i in commands)
                    {
                        Console.WriteLine($"{i.ID},{i.Name} {i.City} {i.Count}");
                    }
                    break;
                case "Add":
                    ConnectionCommands.AddCommand(new Command()
                    {
                        Name = value[0],
                        City = value[1],
                        Count = Convert.ToInt32(value[2]),
                    });
                    break;
                case "Update":
                    ConnectionCommands.UpdateCommand(new Command()
                    {
                        ID = Convert.ToInt32(value[0]),
                        Name = value[1],
                        City = value[2],
                        Count = Convert.ToInt32(value[3]),
                    });
                    break;
                case "Remove":
                    ConnectionCommands.RemoveCommand(Convert.ToInt32(value[0]));
                    break;
            }
        }

        private static void PrintCompetitions(string command, string values)
        {
            string[] value = values.Split(',');
            switch (command)
            {
                case "Get":
                    List<Competition> compet = ConnectionCompetitions.GetCompetition();
                    foreach (Competition i in compet)
                    {
                        Console.WriteLine($"{i.ID},{i.Name} {i.NameVenue} {i.Street} {i.Home} {i.City} {i.Date}");
                    }
                    break;
                case "Add":
                    ConnectionCompetitions.AddCompetition(new Competition()
                    {
                        Name = value[0],
                        NameVenue = value[1],
                        Street = value[2],
                        Home = Convert.ToInt32(value[3]),
                        City = value[4],
                        Date = Convert.ToDateTime(value[5]),
                    });
                    break;
                case "Update":
                    ConnectionCompetitions.UpdateCompet(new Competition()
                    {
                        ID = Convert.ToInt32(value[0]),
                        Name = value[1],
                        NameVenue = value[2],
                        Street = value[3],
                        Home = Convert.ToInt32(value[4]),
                        City = value[5],
                        Date = Convert.ToDateTime(value[6]),
                    });
                    break;
                case "Remove":
                    ConnectionCompetitions.RemoveCompetition(Convert.ToInt32(value[0]));
                    break;
            }
        }

        private static void PrintResults(string command, string values)
        {
            string[] value = values.Split(',');
            switch (command)
            {
                case "Get":
                    List<Result> results = ConnectionResults.GetResults();
                    foreach (Result i in results)
                    {
                        Console.WriteLine($"{i.idCommand},{i.idCompet},{i.Command} {i.Compet} {i.Rank}");
                    }
                    break;
                case "Add":
                    ResultStorage.Add(new Result()
                    {
                        Command = value[0],
                        Compet = value[1],
                        Rank = Convert.ToInt32(value[2]),
                    });
                    break;
                case "Update":
                    ConnectionResults.UpdateResult(new Result()
                    {
                        Command = value[0],
                        Compet = value[1],
                        Rank = Convert.ToInt32(value[2]),
                    });
                    break;
                case "Remove":
                    ConnectionResults.RemoveResult(Convert.ToInt32(value[0]), Convert.ToInt32(value[1]));
                    break;
            }
        }

        private static void PrintSponsorships(string command, string values)
        {
            string[] value = values.Split(',');
            switch (command)
            {
                case "Get":
                    List<Sponsorship> sponsorships = ConnectionSponsorship.GetSponsorship(Connection.idUser);
                    foreach (Sponsorship i in sponsorships)
                    {
                        Console.WriteLine($"{i.ID},{i.SponsorName} - {i.Command}, {i.Amount}, {i.teamContract}");
                    }
                    break;

                case "Remove":
                    ConnectionSponsorship.RemoveSponsorship(Convert.ToInt32(value[0]));
                    break;
                case "Add":
                    ConnectionSponsorship.AddSponsorship(new Sponsorship()
                    {
                        Command = value[0],
                        Amount = Convert.ToInt32(value[1]),
                        teamContract = Convert.ToInt32(value[2]),
                    });
                    break;
            }
        }

        private static void PrintSponsorshipsViewer(string command)
        {
            switch (command)
            {
                case "Get":
                    List<Sponsorship> sponsorships = ConnectionSponsorship.GetSponsorshipViewerAdmin();
                    foreach (Sponsorship i in sponsorships)
                    {
                        Console.WriteLine($"{i.ID},{i.SponsorName} - {i.Command}");
                    }
                    break;
            }
        }
    }
}
