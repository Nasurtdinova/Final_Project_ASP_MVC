using Final_Project_ASP_MVC.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class SponsorshipStorage
    {
        public static List<Sponsorship> sponsorships { get; private set; } = ConnectionSponsorship.GetSponsorship();
        public static List<Sponsorship> sponsorshipsViewerAdmin { get; private set; } = ConnectionSponsorship.GetSponsorshipViewerAdmin();

        public static void Add(Sponsorship sponship)
        {
            ConnectionSponsorship.AddSponsorship(sponship);
            sponsorships.Add(sponship);
        }

        public static void RemoveByName(int id)
        {
            ConnectionSponsorship.RemoveSponsorship(id);
            sponsorships.RemoveAll(p => p.ID == id);
        }

        //public static void Update(Sponsorship compet)
        //{
        //    Connection.UpdateCompet(compet);
        //    competition = Connection.GetCompetition();
        //}
    }
}
