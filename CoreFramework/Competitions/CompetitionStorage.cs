
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

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
