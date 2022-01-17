using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Core
{
    public class ConnectionSponsorship
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["Competition"].ConnectionString;
        private static IDbConnection connection = new SqlConnection(connStr);

        public static List<Sponsorship> GetSponsorship(int idUser)
        {
            List<Sponsorship> sponsorship = new List<Sponsorship>();

            for (int i = 0; i < connection.Query<int>($"SELECT * FROM SponsorCommand;").Count(); i++)
            {
                sponsorship.Add(new Sponsorship
                {
                    ID = connection.Query<int>($"SELECT id from SponsorCommand join Users on SponsorCommand.idSponsor = Users.idUser join Command on SponsorCommand.idCom = Command.idCommand where SponsorCommand.idSponsor = {idUser};").AsList()[i],
                    SponsorName = connection.Query<string>($"SELECT Users.Name from SponsorCommand join Users on SponsorCommand.idSponsor = Users.idUser join Command on SponsorCommand.idCom = Command.idCommand where SponsorCommand.idSponsor = {idUser};").AsList()[i],
                    SponsorSurname = connection.Query<string>($"SELECT Users.Surname from SponsorCommand join Users on SponsorCommand.idSponsor = Users.idUser join Command on SponsorCommand.idCom = Command.idCommand where SponsorCommand.idSponsor = {idUser};").AsList()[i],
                    Command = connection.Query<string>($"SELECT Command.Name from SponsorCommand join Users on SponsorCommand.idSponsor = Users.idUser join Command on SponsorCommand.idCom = Command.idCommand where SponsorCommand.idSponsor = {idUser};").AsList()[i],
                    teamContract = connection.Query<int>($"SELECT teamContract from SponsorCommand join Users on SponsorCommand.idSponsor = Users.idUser join Command on SponsorCommand.idCom = Command.idCommand where SponsorCommand.idSponsor = {idUser};").AsList()[i],
                    Amount = connection.Query<int>($"SELECT amount from SponsorCommand join Users on SponsorCommand.idSponsor = Users.idUser join Command on SponsorCommand.idCom = Command.idCommand where SponsorCommand.idSponsor = {idUser};").AsList()[i]
                });
            }

            return sponsorship;
        }

        public static List<Sponsorship> GetSponsorshipViewerAdmin()
        {
            List<Sponsorship> sponsorship = new List<Sponsorship>();

            for (int i = 0; i < connection.Query<int>($"SELECT * FROM SponsorCommand;").Count(); i++)
            {
                sponsorship.Add(new Sponsorship
                {
                    ID = connection.Query<int>($"SELECT id from SponsorCommand join Users on SponsorCommand.idSponsor = Users.idUser join Command on SponsorCommand.idCom = Command.idCommand;").AsList()[i],
                    SponsorName = connection.Query<string>($"SELECT Users.Name from SponsorCommand join Users on SponsorCommand.idSponsor = Users.idUser join Command on SponsorCommand.idCom = Command.idCommand;").AsList()[i],
                    SponsorSurname = connection.Query<string>($"SELECT Users.Surname from SponsorCommand join Users on SponsorCommand.idSponsor = Users.idUser join Command on SponsorCommand.idCom = Command.idCommand;").AsList()[i],
                    Command = connection.Query<string>($"SELECT Command.Name from SponsorCommand join Users on SponsorCommand.idSponsor = Users.idUser join Command on SponsorCommand.idCom = Command.idCommand;").AsList()[i],
                    teamContract = connection.Query<int>($"SELECT teamContract from SponsorCommand join Users on SponsorCommand.idSponsor = Users.idUser join Command on SponsorCommand.idCom = Command.idCommand;").AsList()[i],
                    Amount = connection.Query<int>($"SELECT amount from SponsorCommand join Users on SponsorCommand.idSponsor = Users.idUser join Command on SponsorCommand.idCom = Command.idCommand;").AsList()[i]
                });
            }
            return sponsorship;
        }

        public static Sponsorship GetSponsorshipId(int id)
        {
            Sponsorship sponsorship = null;

            sponsorship = new Sponsorship
            {
                ID = connection.Query<int>($"SELECT id from SponsorCommand join Users on SponsorCommand.idSponsor = Users.idUser join Command on SponsorCommand.idCom = Command.idCommand where SponsorCommand.id = {id};").AsList().FirstOrDefault(),
                SponsorName = connection.Query<string>($"SELECT Users.Name from SponsorCommand join Users on SponsorCommand.idSponsor = Users.idUser join Command on SponsorCommand.idCom = Command.idCommand where SponsorCommand.id = {id};").AsList().FirstOrDefault(),
                SponsorSurname = connection.Query<string>($"SELECT Users.Surname from SponsorCommand join Users on SponsorCommand.idSponsor = Users.idUser join Command on SponsorCommand.idCom = Command.idCommand where SponsorCommand.id = {id};").AsList().FirstOrDefault(),
                Command = connection.Query<string>($"SELECT Command.Name from SponsorCommand join Users on SponsorCommand.idSponsor = Users.idUser join Command on SponsorCommand.idCom = Command.idCommand where SponsorCommand.id = {id};").AsList().FirstOrDefault(),
                teamContract = connection.Query<int>($"SELECT teamContract from SponsorCommand join Users on SponsorCommand.idSponsor = Users.idUser join Command on SponsorCommand.idCom = Command.idCommand where SponsorCommand.id = {id};").AsList().FirstOrDefault(),
                Amount = connection.Query<int>($"SELECT amount from SponsorCommand join Users on SponsorCommand.idSponsor = Users.idUser join Command on SponsorCommand.idCom = Command.idCommand where SponsorCommand.id = {id};").AsList().FirstOrDefault()
            };

            return sponsorship;
        }

        public static void AddSponsorship(Sponsorship sponsorship)
        {
            try
            {
                connection.Query($"INSERT SponsorCommand values ({Connection.idUser}, (select Command.idCommand from Command where " +
                $"Command.Name = '{sponsorship.Command}'), {sponsorship.teamContract}, {sponsorship.Amount});");
            }
            catch 
            {
                throw new Exception("Incorrect data!!!");
            }
        }

        public static void AddSponsorshipApi(Sponsorship sponsorship)
        {
            try
            {
                connection.Query($"INSERT SponsorCommand values ((select User.idUser from Users where Users.Name = '{sponsorship.SponsorName}' " +
                $"and Users.Surname = '{sponsorship.SponsorSurname}'), (select Command.idCommand from Command where Command.Name = '{sponsorship.Command}'), {sponsorship.teamContract}, {sponsorship.Amount});");
            }
            catch
            {
                throw new Exception("Incorrect data!!!");
            }
        }

        public static void RemoveSponsorship(int id)
        {
            try
            {
                connection.Query($"DELETE from SponsorCommand WHERE (SponsorCommand.id = '{id}')");
            }
            catch 
            {
                throw new Exception("Incorrect data!!!");
            }
        }
    }
}
