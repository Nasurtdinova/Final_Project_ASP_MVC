using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_ASP_MVC.Core
{
    public class CompetitionStorage
    {
        public static List<Competition> competition { get; private set; } = ConnectionCompetitions.GetCompetition();

        public static void Add(Competition compet)
        {
            ConnectionCompetitions.AddCompetition(compet);
            competition.Add(compet);
        }

        public static void RemoveByName(int id)
        {
            ConnectionCompetitions.RemoveCompetition(id);
            competition.RemoveAll(p => p.ID == id);
        }

        public static void Update(Competition compet)
        {
            ConnectionCompetitions.UpdateCompet(compet);
            competition = ConnectionCompetitions.GetCompetition();
        }
    }
}
