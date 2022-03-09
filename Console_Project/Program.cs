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
                { 6,"What do you want to do 'Get', 'Add', 'Remove', 'Update'?" },
                { 7,"What do you want to do 'Get', 'Add', 'Remove'?" }
            };

            Console.WriteLine(message[0]);
            string login = Console.ReadLine();
            if (login == "Viewer")
            {
                while (true)
                {
                    Console.WriteLine(message[5]);
                    int click = Convert.ToInt32(Console.ReadLine());
                    string[] emptyStringArray = new string[0];
                    Done(click,"Get", emptyStringArray);
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
                    if (Connection.GetIdType(login, password))
                    {
                        Console.WriteLine(message[6]);
                        string instruction = Console.ReadLine();

                        switch (click)
                        {
                            case 1:
                                Console.WriteLine(message[1]);
                                break;
                            case 2:
                                Console.WriteLine(message[2]);
                                break;
                            case 3:
                                Console.WriteLine(message[3]);
                                break;
                            case 4:
                                Console.WriteLine(message[4]);
                                break;
                        }

                        string values = Console.ReadLine();
                        string[] value = values.Split(',');
                        Done(click, instruction, value);
                    }
                    else
                    {
                        Connection con = new Connection(login, password);
                        if (click == 5)
                        {
                            Console.WriteLine(message[7]);
                            string instruction = Console.ReadLine();
                            string values = Console.ReadLine();
                            string[] value = values.Split(',');
                            PrintSponsorships(instruction, value);
                            continue;
                        }
                        string[] emptyStringArray = new string[0];
                        Done(click, "Get", emptyStringArray);
                    }
                }
            }

            else
            {
                Console.WriteLine("No correct"); //
            }
        }

        private static void Done(int click, string command, string[] values)
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
                    PrintSponsorships(command, values);
                    break;
            }
        }

        private static void PrintSportsmans(string command, string []values)
        {
            switch (command)
            {
                case "Get":
                    List<Sportsmans> sportsmans = ConnectionSportsmans.GetSportsmans();
                    foreach (Sportsmans i in sportsmans)
                    {
                        Console.WriteLine(i);
                    }
                    break;
                case "Add":
                    ConnectionSportsmans.AddSportsman(new Sportsman(values));
                    break;
                case "Update":
                    ConnectionSportsmans.UpdateSportsman(new Sportsman(values, Convert.ToInt32(values[0])));
                    break;
                case "Remove":
                    ConnectionSportsmans.RemoveSportsman(Convert.ToInt32(values[0]));
                    break;
            }
        }

        private static void PrintCommands(string command, string[] values)
        {
            switch (command)
            {
                case "Get":
                    ObservableCollection<Commands> commands = ConnectionCommands.GetCommands();
                    foreach (Commands i in commands)
                    {
                        Console.WriteLine(i);
                    }
                    break;
                case "Add":
                    ConnectionCommands.AddCommand(new Command(values));
                    break;
                case "Update":
                    ConnectionCommands.UpdateCommand(new Command(values, Convert.ToInt32(values[0])));
                    break;
                case "Remove":
                    ConnectionCommands.RemoveCommand(Convert.ToInt32(values[0]));
                    break;
            }
        }

        private static void PrintCompetitions(string command, string []values)
        {
            switch (command)
            {
                case "Get":
                    List<Competitions> compet = ConnectionCompetitions.GetCompetition();
                    foreach (Competitions i in compet)
                    {
                        Console.WriteLine(i);
                    }
                    break;
                case "Add":
                    ConnectionCompetitions.AddCompetition(new Competition(values));
                    break;
                case "Update":
                    ConnectionCompetitions.UpdateCompet(new Competition(values, Convert.ToInt32(values[0])));
                    break;
                case "Remove":
                    ConnectionCompetitions.RemoveCompetition(Convert.ToInt32(values[0]));
                    break;
            }
        }

        private static void PrintResults(string command, string [] values)
        {
            switch (command)
            {
                case "Get":
                    List<Results> results = ConnectionResults.GetResults();
                    foreach (Results i in results)
                    {
                        Console.WriteLine(i);
                    }
                    break;
                case "Add":
                    ResultStorage.Add(new Result(values));
                    break;
                case "Update":
                    ConnectionResults.UpdateResult(new Result(values));
                    break;
                case "Remove":
                    ConnectionResults.RemoveResult(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));
                    break;
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
