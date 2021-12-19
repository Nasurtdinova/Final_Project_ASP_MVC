using Final_Project_ASP_MVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_ASP_MVC.Core
{
    public class SportsmanStorage
    {     
        public static List<Sportsman> sportsmans { get; private set; } = Connection.GetSportsmans();

        public static void Add(Sportsman project)
        {
            Connection.AddSportsman(project);
            sportsmans.Add(project);
        }

        public static void RemoveByName(int id)
        {
            Connection.RemoveSportsman(id);
            sportsmans.RemoveAll(p => p.ID == id);
        }

        public static void Update(Sportsman sportsman)
        {
            Connection.UpdateSportsman(sportsman);
            sportsmans = Connection.GetSportsmans();
        }
    }
}
