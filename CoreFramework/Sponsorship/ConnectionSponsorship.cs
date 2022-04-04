﻿
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

        public static List<SponsorCommand> GetSponsorship(int idUser)
        {
            List<SponsorCommand> commands = GetSponsorshipViewerAdmin();
            return commands.Where(tt => tt.Sponsor.idUser == idUser).ToList();
        }

        public static List<SponsorCommand> GetSponsorshipViewerAdmin()
        {
            return new List<SponsorCommand>(bdConnection.connection.SponsorCommand.ToList());
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

        public static void AddSponsorshipApi(SponsorCommand sponsorship)
        {
        }

        public static void RemoveSponsorship(int id)
        {
        }
    }
}