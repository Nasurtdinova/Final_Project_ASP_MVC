using Final_Project_ASP_MVC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Project.Service
{
    public static class SportsmanService
    {
        static List<Sportsman> Sportsmans { get; }
        static int nextId = 23;
        static SportsmanService()
        {
            Sportsmans = Connection.GetSportsmans();
        }

        public static List<Sportsman> GetAll() => Sportsmans;

        public static Sportsman Get(int id) => Sportsmans.FirstOrDefault(p => p.ID == id);

        public static void Add(Sportsman sportsman)
        {
            Connection.AddSportsman(sportsman);
            sportsman.ID = nextId++;
            Sportsmans.Add(sportsman);
        }

        public static void Delete(int id)
        {
            var sportsman = Get(id);
            if (sportsman is null)
                return;
            Connection.RemoveSportsman(id);
            Sportsmans.Remove(sportsman);
        }

        public static void Update(Sportsman sportsman)
        {
            var index = Sportsmans.FindIndex(p => p.ID == sportsman.ID);
            if (index == -1)
                return;

            Connection.UpdateSportsman(sportsman);
            Sportsmans[index] = sportsman;
        }


    }
}
