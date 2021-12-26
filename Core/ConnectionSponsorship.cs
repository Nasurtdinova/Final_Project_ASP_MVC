using Final_Project_ASP_MVC.Core;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Core
{
    public class ConnectionSponsorship
    {
        public static string connStr = ConfigurationManager.AppSettings["connection"].ToString();
        public static MySqlConnection conn;

        public static List<Sponsorship> GetSponsorship()
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            List<Sponsorship> sponsorship = new List<Sponsorship>();

            try
            {
                string sql = $"SELECT id, Competition.User.Name, Competition.User.Surname, Competition.Command.Name, teamContract, amount from Competition.SponsorCommand join Competition.User on Competition.SponsorCommand.idSponsor = Competition.User.idUser join Competition.Command on Competition.SponsorCommand.idCom = Competition.Command.idCommand where Competition.SponsorCommand.idSponsor = {Connection.idUser}; ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    sponsorship.Add(new Sponsorship { ID = Convert.ToInt32(res[0]), SponsorName = res[1].ToString(), SponsorSurname = res[2].ToString(), Command = res[3].ToString(), teamContract = Convert.ToInt32(res[4]), Amount = Convert.ToInt32(res[5]) });
                }
                res.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return sponsorship;
        }

        public static List<Sponsorship> GetSponsorshipViewerAdmin()
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            List<Sponsorship> sponsorship = new List<Sponsorship>();

            try
            {
                string sql = $"SELECT id, Competition.User.Name, Competition.User.Surname, Competition.Command.Name, teamContract, amount from Competition.SponsorCommand join Competition.User on Competition.SponsorCommand.idSponsor = Competition.User.idUser join Competition.Command on Competition.SponsorCommand.idCom = Competition.Command.idCommand; ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    sponsorship.Add(new Sponsorship { ID = Convert.ToInt32(res[0]), SponsorName = res[1].ToString(), SponsorSurname = res[2].ToString(), Command = res[3].ToString(), teamContract = Convert.ToInt32(res[4]), Amount = Convert.ToInt32(res[5]) });
                }
                res.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return sponsorship;
        }

        public static void AddSponsorship(Sponsorship sponsorship)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO Competition.SponsorCommand (idSponsor, idCom, teamContract, amount) values ({Connection.idUser}, (select Competition.Command.idCommand from Competition.Command where Competition.Command.Name = '{sponsorship.Command}'), {sponsorship.teamContract}, {sponsorship.Amount});", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }

        public static void RemoveSponsorship(int id)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"DELETE from Competition.SponsorCommand WHERE (Competition.SponsorCommand.id = '{id}')", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }
    }
}
