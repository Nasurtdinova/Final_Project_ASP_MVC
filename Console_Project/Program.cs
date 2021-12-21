using Final_Project_ASP_MVC.Core;
using System;
using System.Collections.Generic;

namespace Console_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Sportsman> sportsmans = new List<Sportsman>();
            sportsmans = Connection.GetSportsmans();
            foreach (Sportsman i in sportsmans)
            {
                
                Console.WriteLine(i.Name);
            }
           
            Console.WriteLine("Hello World!");
        }
    }
}
