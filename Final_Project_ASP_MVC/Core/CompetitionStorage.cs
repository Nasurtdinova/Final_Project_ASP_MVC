using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_ASP_MVC.Core
{
    public class CompetitionStorage
    {
        public static List<Competition> competition { get; private set; } = Connection.GetCompetition();

        public static void Add(Competition compet)
        {
            Connection.AddCompetition(compet);
            competition.Add(compet);
        }
        public static void Update(Competition compet)
        {
            Connection.UpdateCompet(compet);
            competition = Connection.GetCompetition();
        }
    }
}
