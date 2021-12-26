using Core;
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
        public static List<Sportsman> sportsmans { get; private set; } = ConnectionSportsmans.GetSportsmans();

        public static void Add(Sportsman project)
        {
            ConnectionSportsmans.AddSportsman(project);
            sportsmans.Add(project);
        }

        public static void RemoveByName(int id)
        {
            ConnectionSportsmans.RemoveSportsman(id);
            sportsmans.RemoveAll(p => p.ID == id);
        }

        public static void Update(Sportsman sportsman)
        {
            ConnectionSportsmans.UpdateSportsman(sportsman);
            sportsmans = ConnectionSportsmans.GetSportsmans();
        }
    }
}
