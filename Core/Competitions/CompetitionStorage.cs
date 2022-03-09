using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class CompetitionStorage
    {
        public static ObservableCollection<Competitions> competition { get; private set; } = ConnectionCompetitions.GetCompetition();

        public static void Add(Competition compet)
        {
            ConnectionCompetitions.AddCompetition(compet);
            competition.Add(compet);
        }

        public static void RemoveByName(int id)
        {
            ConnectionCompetitions.RemoveCompetition(id);
            competition = ConnectionCompetitions.GetCompetition();
        }

        public static void Update(Competition compet)
        {
            ConnectionCompetitions.UpdateCompet(compet);
            competition = ConnectionCompetitions.GetCompetition();
        }
    }
}
