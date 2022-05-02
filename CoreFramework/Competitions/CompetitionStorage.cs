using System.Collections.ObjectModel;

namespace CoreFramework
{
    public class CompetitionStorage
    {
        public static ObservableCollection<Competition> competition { get; private set; } = ConnectionCompetitions.GetCompetitions();

        public static void Add(Competition compet)
        {
            ConnectionCompetitions.AddCompetition(compet);
            competition.Add(compet);
        }

        public static void RemoveByName(int id)
        {
            ConnectionCompetitions.RemoveCompetition(id);
        }

        public static void Update(Competition compet)
        {
            ConnectionCompetitions.UpdateCompet(compet);
            competition = ConnectionCompetitions.GetCompetitions();
        }
    }
}
