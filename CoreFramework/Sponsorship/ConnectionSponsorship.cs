
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CoreFramework
{
    public class ConnectionSponsorship 
    {

        public static List<SponsorCommand> GetSponsorship(int idSponsor)
        {
            List<SponsorCommand> commands = GetSponsorshipViewerAdmin();
            return commands.Where(tt => tt.idSponsor == idSponsor).ToList();
        }

        public static List<SponsorCommand> GetSponsorshipTopical()
        {
            return new List<SponsorCommand>(bdConnection.connection.SponsorCommand.ToList()).Where(a => a.idStatus == 1).ToList();
        }

        public static bool IsAddTrue(int idSponsor, int idCommand)
        {
            List<SponsorCommand> commands = GetSponsorship(idSponsor);
            if (commands.Where(tt => tt.idSponsor == idSponsor && tt.idCom == idCommand && tt.DateEnd > DateTime.Now).Count() != 0)
                return false;
            else
                return true;                
        }

        public static List<SponsorCommand> GetSponsorshipViewerAdmin()
        {
            return new List<SponsorCommand>(bdConnection.connection.SponsorCommand.ToList()).Where(a => a.idStatus == 3).ToList();
        }

        public static SponsorCommand GetSponsorshipId(int id)
        {
            List<SponsorCommand> commands = GetSponsorshipViewerAdmin();
            return commands.Where(tt => tt.id == id).FirstOrDefault();
        }

        public static void AddSponsorship(SponsorCommand sponsorship)
        {
            try
            {
                sponsorship.Sponsor = CurrentUser.spon;
                sponsorship.Command = Connection.GetCommand(sponsorship.Command.Name);
                sponsorship.idStatus = 1;
                bdConnection.connection.SponsorCommand.Add(sponsorship);
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateSponsorship(SponsorCommand sponCom)
        {
            try
            {
                var sports = bdConnection.connection.SponsorCommand.SingleOrDefault(r => r.id == sponCom.id);
                sports.idSponsor = sponCom.idSponsor;
                sports.idCom = sponCom.idCom;
                sports.Amount = sponCom.Amount;
                sports.DateBegin = sponCom.DateBegin;
                sports.DateEnd = sponCom.DateEnd;
                sports.MutualBenefit = sponCom.MutualBenefit;

                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void RemoveSponsorship(int id)
        {
        }
    }
}
