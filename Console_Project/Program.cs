using CoreFramework;
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
                { 1, "Input values: Name,Surname,Title,Image,Height,Cost,Command" },
                { 2, "Input values: Name,City,Count" },
                { 3, "Input values: Name,NameVenue,Street,Home,City,Date" },
                { 4, "Input values: Command,Compet,Rank" },
                { 5, "If you want to see, click, sportsmans - 1, commands - 2, competitions - 3, results of competitions - 4, sponsorships - 5"},
            };

            while (true)
            {
                Console.WriteLine(message[5]);
                int click = Convert.ToInt32(Console.ReadLine());
                Viewer(click);
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
    }
}
