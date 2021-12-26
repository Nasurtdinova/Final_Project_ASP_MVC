using Core;
using Final_Project_ASP_MVC.Core;
using System;
using System.Collections.Generic;
using System.Security;

namespace Console_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, input login and password, else write Viewer");
            string login = Console.ReadLine();
            string password = null;
            while (true)
            {
                var key = System.Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                password += key.KeyChar;
            }

            if (Connection.IsLogin(login, password))
            {
                if (login == "nasurtdinovaguz@mail.ru" && password == "2003")
                {
                    while (true)
                    {
                        Console.WriteLine("If you want to see, click, sportsmans - 1, commands - 2, competitions - 3, results of competitions - 4, sponsorships - 5");
                        int click = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("What do you want to do 'Get', 'Add', 'Remove', 'Update'?");
                        string instruction = Console.ReadLine();
                        Console.WriteLine("Input values");
                        switch (click)
                        {
                            case 1:
                                Console.WriteLine("Name Surname Title Height Cost Command");
                                break;
                            case 2:
                                Console.WriteLine("Name City Count");
                                break;
                            case 3:
                                Console.WriteLine("Name NameVenue Street Home City Date");
                                break;
                            case 4:
                                Console.WriteLine("Command Compet Rank");
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
                        Console.WriteLine("If you want to see, click, sportsmans - 1, commands - 2, competitions - 3, results of competitions - 4, sponsorships - 5");
                        int click = Convert.ToInt32(Console.ReadLine());
                        string instruction = "Get";
                        string values = " ";
                        switch (click)
                        {
                            case 5:
                                Console.WriteLine("What do you want to do 'Get', 'Add', 'Remove', 'Update'?");
                                instruction = Console.ReadLine();
                                Console.WriteLine("Sponsor Command");
                                values = Console.ReadLine();
                                break;
                        }
                        Done(click, instruction, values);
                    }
                }
            }
           
            else if (login == "Viewer")
            {
                while (true)
                {
                    Console.WriteLine("If you want to see, click, sportsmans - 1, commands - 2, competitions - 3, results of competitions - 4, sponsorships - 5");
                    int click = Convert.ToInt32(Console.ReadLine());
                    Done(click, "Get", " ");
                }
            }

            else
            {
                Console.WriteLine("No correct");
            }
        }

        private static void Done(int click, string command, string values)
        {
            switch(click)
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
                    PrintSponsorships(command);
                    break;
            }
        }

        private static void PrintSportsmans(string command, string values)
        {
            string[] value = values.Split(' ');
            switch (command)
            {
                case "Get":
                    List<Sportsman> sportsmans = ConnectionSportsmans.GetSportsmans();
                    foreach (Sportsman i in sportsmans)
                    {
                        Console.WriteLine($"{i.Name}, {i.Surname}, {i.Title}, {i.Height}, {i.Cost}, {i.Command}");
                    }
                    break;
                case "Add":
                    ConnectionSportsmans.AddSportsman(new Sportsman() {
                        Name = value[0],
                        Surname = value[1],
                        Title = value[2],
                        Height = Convert.ToInt32(value[3]),
                        Cost = Convert.ToInt32(value[4]),
                        Command = value[5]
                    });
                    break;
                case "Update":
                    ConnectionSportsmans.UpdateSportsman(new Sportsman() {
                        ID = Convert.ToInt32(value[0]),
                        Name = value[1],
                        Surname = value[2],
                        Title = value[3],
                        Height = Convert.ToInt32(value[4]),
                        Cost = Convert.ToInt32(value[5]),
                        Command = value[6]
                    });
                    break;
                case "Remove":
                    ConnectionSportsmans.RemoveSportsman(Convert.ToInt32(value[0]));
                    break;
            }
        }

        private static void PrintCommands(string command, string values)
        {
            string[] value = values.Split(' ');
            switch (command)
            {
                case "Get":
                    List<Command> commands = ConnectionCommands.GetCommands();
                    foreach (Command i in commands)
                    {
                        Console.WriteLine($"{i.Name} {i.City} {i.Count}");
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
            string[] value = values.Split(' ');
            switch (command)
            {
                case "Get":
                    List<Result> res = ConnectionResults.GetResults();
                    foreach (Result i in res)
                    {
                        Console.WriteLine($"{i.Command} {i.Compet} {i.Rank}");
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
            string[] value = values.Split(' ');
            switch (command)
            {
                case "Get":
                    List<Result> results = ConnectionResults.GetResults();
                    foreach (Result i in results)
                    {
                        Console.WriteLine($"{i.Command}, {i.Compet}, {i.Rank}");
                    }
                    break;
                case "Add":
                    ConnectionResults.AddResult(new Result()
                    {
                        Command = value[0],
                        Compet = value[1],
                        Rank = Convert.ToInt32(value[2]),
                    });
                    break;
                case "Update":
                    ConnectionResults.UpdateResult(new Result()
                    {
                        ID = Convert.ToInt32(value[0]),
                        Command = value[1],
                        Compet = value[2],
                        Rank = Convert.ToInt32(value[3]),
                    });
                    break;
                case "Remove":
                    ConnectionResults.RemoveResult(Convert.ToInt32(value[0]));
                    break;
            }
        }

        private static void PrintSponsorships(string command)
        {
            switch (command)
            {
                case "Get":
                    List<Sponsorship> sponsorships = ConnectionSponsorship.GetSponsorshipViewerAdmin();
                    foreach (Sponsorship i in sponsorships)
                    {
                        Console.WriteLine($"{i.SponsorName}, {i.Command}");
                    }
                    break;
            }
        }
    }

}
