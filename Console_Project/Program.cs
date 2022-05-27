using CoreFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security;

namespace Console_Project
{
    class Program
    {
        public static Dictionary<int, string> message = new Dictionary<int, string> { 
            { 1, "Values: ID, Name, Surname, Title, Height, Command" },
            { 2, "Values: ID, Name, Count" },
            { 3, "Values: ID, Name, Name venue, Street, Home, City, Date" },
            { 4, "Values: Command, Competition, Rank" },
            { 5, "Values: Sponsor - Command, Amount, Date begin - Date end" },
            { 6, "If you want to see, click, sportsmans - 1, commands - 2, competitions - 3, results of competitions - 4, sponsorships - 5" },};

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(message[6]);
                int click = Convert.ToInt32(Console.ReadLine());
                Viewer(click);
            }
        }

        private static void Viewer(int click)
        {
            switch (click)
            {
                case 1:
                    Console.WriteLine(message[1]);
                    PrintSportsmans();
                    break;
                case 2:
                    Console.WriteLine(message[2]);
                    PrintCommands();
                    break;
                case 3:
                    Console.WriteLine(message[3]);
                    PrintCompetitions();
                    break;
                case 4:
                    Console.WriteLine(message[4]);
                    PrintResults();
                    break;
                case 5:
                    Console.WriteLine(message[5]);
                    PrintSponsorships();
                    break;
            }
        }

        private static void PrintSportsmans()
        {
            ObservableCollection<Sportsman> sportsmans = ConnectionSportsmans.GetSportsmans();
            foreach (Sportsman i in sportsmans)
            {
                Console.WriteLine(i);
            }
        }

        private static void PrintCommands()
        {
            ObservableCollection<Command> commands = ConnectionCommands.GetCommands();
            foreach (Command i in commands)
            {
                Console.WriteLine(i);
            }             
        }

        private static void PrintCompetitions()
        {
            ObservableCollection<Competition> compet = ConnectionCompetitions.GetCompetitions();
            foreach (Competition i in compet)
            {
                Console.WriteLine(i);
            }
        }

        private static void PrintResults()
        {
            ObservableCollection<ResultCompetition> results = ConnectionResults.GetResults();
            foreach (ResultCompetition i in results)
            {
                Console.WriteLine(i);
            }
        }

        private static void PrintSponsorships()
        {
            List<SponsorCommand> sponsorships = ConnectionSponsorship.GetAcceptedRequest();
            foreach (SponsorCommand i in sponsorships)
            {
                Console.WriteLine(i);
            }
        }
    }
}
