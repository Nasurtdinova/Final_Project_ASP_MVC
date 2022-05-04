using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CoreFramework
{
    public class ConnectionSponsorship 
    {
        public static List<SponsorCommand> GetSponsorshipAccepted()
        {
            return GetAcceptedRequest().Where(tt => tt.idSponsor == CurrentUser.spon.idSponsor).ToList();
        }

        public static List<SponsorCommand> GetSponsorshipTopical()
        {
            return new List<SponsorCommand>(bdConnection.connection.SponsorCommand.ToList()).Where(a => a.idStatus == 1).ToList();
        }

        public static List<SponsorCommand> GetSponsorships()
        {
            return new List<SponsorCommand>(bdConnection.connection.SponsorCommand.ToList());
        }

        public static bool IsAddTrue(int idCommand)
        {
            if (GetSponsorshipAccepted().Where(tt =>tt.idCom == idCommand).Count() == 0)
                return true;
            else
                return false;                
        }

        public static bool IsAddTopicalTrue(int idCommand)
        {
            if (GetSponsorshipTopical().Where(tt =>tt.idSponsor == CurrentUser.spon.idSponsor && tt.idCom == idCommand && tt.DateBegin > DateTime.Now).Count() == 0)
                return true;
            else
                return false;
        }

        public static List<SponsorCommand> GetAcceptedRequest()
        {
            return new List<SponsorCommand>(bdConnection.connection.SponsorCommand.ToList()).Where(a => a.idStatus == 3 && a.DateEnd > DateTime.Now).ToList();
        }

        public static SponsorCommand GetSponsorshipId(int id)
        {
            return GetAcceptedRequest().Where(tt => tt.id == id).FirstOrDefault();
        }

        public static void AddSponsorship(SponsorCommand sponsorship)
        {
            try
            {
                sponsorship.Sponsor = CurrentUser.spon;
                sponsorship.Command = ConnectionCommands.GetCommandsId(Convert.ToInt32(sponsorship.idCom));
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

        public static void EndSponsorship(int id)
        {
            SponsorCommand sponCom = bdConnection.connection.SponsorCommand.FirstOrDefault(p => p.id == id);
            sponCom.idStatus = 4;
            bdConnection.connection.SaveChanges();
        }
    }
}
