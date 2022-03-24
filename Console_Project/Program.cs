using Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security;

namespace Console_Project
{
    class Program
    {
        static void Main(string[] args)
        {            
            Dictionary<int, string> message = new Dictionary<int, string>
            {
                { 0, "Hello, input login and password, else write Viewer"},
                { 1, "Input values: Name,Surname,Title,Image,Height,Cost,Command" },
                { 2, "Input values: Name,City,Count" },
                { 3, "Input values: Name,NameVenue,Street,Home,City,Date" },
                { 4, "Input values: Command,Compet,Rank" },
                { 5, "If you want to see, click, sportsmans - 1, commands - 2, competitions - 3, results of competitions - 4, sponsorships - 5"},
                { 6,"What do you want to do 'Get', 'Add', 'Remove'?" }
            };

            Console.WriteLine(message[0]);
            string login = Console.ReadLine();
            if (login == "Viewer")
            {
                while (true)
                {
                    Console.WriteLine(message[5]);
                    int click = Convert.ToInt32(Console.ReadLine());
                    Viewer(click);
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

            if (Connection.IsLogin(login, password))
            {
                while (true)
                {
                    Console.WriteLine(message[5]);
                    int click = Convert.ToInt32(Console.ReadLine());
                    if (!Connection.GetIdType(login, password))
                    {
                        Connection con = new Connection(login, password);
                        if (click == 5)
                        {
                            Console.WriteLine(message[6]);
                            string instruction = Console.ReadLine();
                            string values = Console.ReadLine();
                            string[] value = values.Split(',');
                            PrintSponsorships(instruction, value);
                            continue;
                        }
                        string[] emptyStringArray = new string[0];
                        Sponsor(click, "Get", emptyStringArray);
                    }
                }
            }

            else
            {
                Console.WriteLine("No correct"); //
            }
        }

        private static void Viewer(int click)
        {
            switch (click)
            {
                case 1:
                    PrintSportsmans();
                    break;
                case 2:
                    PrintCommands();
                    break;
                case 3:
                    PrintCompetitions();
                    break;
                case 4:
                    PrintResults();
                    break;
            }
        }

        private static void Sponsor(int click, string command, string[] values)
        {
            switch (click)
            {
                case 1:
                    PrintSportsmans();
                    break;
                case 2:
                    PrintCommands();
                    break;
                case 3:
                    PrintCompetitions();
                    break;
                case 4:
                    PrintResults();
                    break;
                case 5:
                    PrintSponsorships(command, values);
                    break;
            }
        }

        private static void PrintSportsmans()
        {
            ObservableCollection<Sportsmans> sportsmans = ConnectionSportsmans.GetSportsmans();
            foreach (Sportsmans i in sportsmans)
            {
                Console.WriteLine(i);
            }
        }

        private static void PrintCommands()
        {
            ObservableCollection<Commands> commands = ConnectionCommands.GetCommands();
            foreach (Commands i in commands)
            {
                Console.WriteLine(i);
            }             
        }

        private static void PrintCompetitions()
        {
            ObservableCollection<Competitions> compet = ConnectionCompetitions.GetCompetition();
            foreach (Competitions i in compet)
            {
                Console.WriteLine(i);
            }
        }

        private static void PrintResults()
        {
            ObservableCollection<Results> results = ConnectionResults.GetResults();
            foreach (Results i in results)
            {
                Console.WriteLine(i);
            }
        }

        private static void PrintSponsorships(string command, string []values)
        {
            switch (command)
            {
                case "Get":
                    List<Sponsorships> sponsorships = ConnectionSponsorship.GetSponsorshipViewerAdmin();
                    foreach (Sponsorships i in sponsorships)
                    {
                        Console.WriteLine(i);
                    }
                    break;
                case "Remove":
                    ConnectionSponsorship.RemoveSponsorship(Convert.ToInt32(values[0]));
                    break;
                case "Add":
                    ConnectionSponsorship.AddSponsorship(new Sponsorship(values));
                    break;
            }
        }
    }
}
