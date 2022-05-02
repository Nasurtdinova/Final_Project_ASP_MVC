using System.Collections.ObjectModel;

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
