using Final_Project_ASP_MVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_ASP_MVC.Core
{
    public class SportsmanStorage : IEnumerable
    {     
        public static List<Sportsman> sportsmans { get; private set; } = Connection.GetSportsmans();

        public IEnumerator GetEnumerator()
        {
            return sportsmans.GetEnumerator();
        }

        public void Add(Sportsman project)
        {
            Connection.AddSportsman(project);
            sportsmans.Add(project);
        }

        public void RemoveByName(int id)
        {
            Connection.RemoveSportsman(id);
            sportsmans.RemoveAll(p => p.ID == id);
        }

        public void Update(Sportsman sportsman)
        {
            Connection.UpdateSportsman(sportsman);
            sportsmans = Connection.GetSportsmans();
        }
    }
}
