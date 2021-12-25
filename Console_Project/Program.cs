using Final_Project_ASP_MVC.Core;
using System;
using System.Collections.Generic;

namespace Console_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, input login and password, else write Viewer");
            string login = Console.ReadLine();
            string password = Console.ReadLine();
            if (Connection.IsLogin(login, password))
            {
                if (login == "nasurtdinovaguz@mail.ru" && password == "2003")
                {

                }
                else
                {

                }
            }
            else if (login == "Viewer")
            {
                Console.WriteLine("Hello, if you want to see, click, sportsmens -1, commands- 2, competitions -3, results of competitions - 4,");
                int click = Convert.ToInt32(Console.ReadLine());

                if (click == 1)
                {
                    List<Sportsman> sportsmans = Connection.GetSportsmans();
                    foreach (Sportsman i in sportsmans)
                    {
                        Console.WriteLine(i.Name);
                        Console.WriteLine(i.Surname);
                    }
                }

                else if (click == 2)
                {
                    List<Command> commands = Connection.GetCommands();
                    foreach (Command i in commands)
                    {
                        Console.WriteLine(i.Name);
                        Console.WriteLine(i.City);
                        Console.WriteLine(i.Count);
                    }
                }

                else if (click == 3)
                {
                    List<Competition> compet = Connection.GetCompetition();
                    foreach (Competition i in compet)
                    {
                        Console.WriteLine(i.Name);
                        Console.WriteLine(i.NameVenue);
                        Console.WriteLine(i.City);
                        Console.WriteLine(i.Street);
                        Console.WriteLine(i.Home);
                        Console.WriteLine(i.Date);
                    }
                }
            }
            else
            {
                Console.WriteLine("No correct");
            }
            
            //List<Sportsman> sportsmans = Connection.GetSportsmans();
            //foreach (Sportsman i in sportsmans)
            //{               
            //    Console.WriteLine(i.Name);
            //    Console.WriteLine(i.Surname);
            //}

            //Connection.AddSportsman(new Sportsman() { Name = "Степанов", Surname = "Степан", Image = "/images/Sportsmans/sport12.jpg" });
            //Connection.UpdateSportsman(new Sportsman() { ID = 28, Name = "Леонидов", Surname = "Степан", Image = "/images/Sportsmans/sport12.jpg" });
            //Connection.RemoveSportsman(28);

            //List<Command> commands = Connection.GetCommands();
            //foreach (Command i in commands)
            //{
            //    Console.WriteLine(i.Name);
            //    Console.WriteLine(i.City);
            //    Console.WriteLine(i.Count);
            //}

            //Connection.AddCommand(new Command() { Name = "Светлячки", City = "Казань", Count = 15, Image = "/images/Commands/command2.jpg" });
            //Connection.UpdateCommand(new Command() { ID = 28, Name = "Снежинки", City = "Казань", Count = 15, Image = "/images/Commands/command2.jpg" });
            //Connection.RemoveCommand(28);

            //List<Competition> compet = Connection.GetCompetition();
            //foreach (Competition i in compet)
            //{
            //    Console.WriteLine(i.Name);
            //    Console.WriteLine(i.NameVenue);
            //    Console.WriteLine(i.City);
            //    Console.WriteLine(i.Street);
            //    Console.WriteLine(i.Home);
            //    Console.WriteLine(i.Date);
            //}

            //Connection.AddCompetition(new Competition() { Name = "Светлячки", City = "Казань", Home=3, NameVenue="gfg", Street="kgjh", Date = new DateTime(2021,10,15,8,0,0) });
            //Connection.UpdateCompet(new Competition() { ID = 28, Name = "Снежинки", City = "Казань" });
            //Connection.RemoveCompetition(28);
        }
    }
}
