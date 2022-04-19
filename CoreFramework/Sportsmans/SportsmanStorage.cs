
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFramework
{
    public class SportsmanStorage
    {     
        public static ObservableCollection<Sportsman> sportsmans { get; private set; } = ConnectionSportsmans.GetSportsmans();

        public static void Add(Sportsman project)
        {
            ConnectionSportsmans.AddSportsman(project);
            sportsmans.Add(project);
        }

        public static void RemoveByName(int id)
        {
            ConnectionSportsmans.RemoveSportsman(id);
            sportsmans = ConnectionSportsmans.GetSportsmans();
        }

        public static void Update(Sportsman sportsman)
        {
            ConnectionSportsmans.UpdateSportsman(sportsman);
            sportsmans = ConnectionSportsmans.GetSportsmans();
        }
    }
}
