using Final_Project_ASP_MVC.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class SponsorshipStorage
    {
        public static List<Sponsorship> sponsorships { get; private set; } = Connection.GetSponsorship();

        public static void Add(Sponsorship sponship)
        {
            Connection.AddSponsorship(sponship);
            sponsorships.Add(sponship);
        }

        //public static void RemoveByName(int id)
        //{
        //    Connection.RemoveCompetition(id);
        //    competition.RemoveAll(p => p.ID == id);
        //}

        //public static void Update(Sponsorship compet)
        //{
        //    Connection.UpdateCompet(compet);
        //    competition = Connection.GetCompetition();
        //}
    }
}
