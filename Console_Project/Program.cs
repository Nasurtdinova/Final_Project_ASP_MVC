using Final_Project_ASP_MVC.Core;
using System;
using System.Collections.Generic;

namespace Console_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Sportsman> sportsmans = Connection.GetSportsmans();
            foreach (Sportsman i in sportsmans)
            {               
                Console.WriteLine(i.Name);
                Console.WriteLine(i.Surname);
            }

            Connection.AddSportsman(new Sportsman() { Name = "Степанов", Surname = "Степан", Image = "/images/Sportsmans/sport12.jpg" });
            Connection.UpdateSportsman(new Sportsman() { ID = 28, Name = "Леонидов", Surname = "Степан", Image = "/images/Sportsmans/sport12.jpg" });
            Connection.RemoveSportsman(28);
        }
    }
}
