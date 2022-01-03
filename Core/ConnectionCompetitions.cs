using Final_Project_ASP_MVC.Core;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Core
{
    public class ConnectionCompetitions
    {
        private static string connStr = ConfigurationManager.AppSettings["connection"].ToString();
        private static MySqlConnection conn;

        public static Competition GetCompetId(int id)
        {
            conn.Open();
            Competition compet = null;
            try
            {
                string sql = $"SELECT idCompetition,Competition.Competition.Name,NameVenue,Street,Home,Date, Competition.City.Name FROM Competition.Competition  join Competition.City  on Competition.Competition.idCity = Competition.City.idCity where idCompetition ={id};";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    compet = new Competition { ID = Convert.ToInt32(res[0]), Name = res[1].ToString(), NameVenue = res[2].ToString(), Street = res[3].ToString(), Home = Convert.ToInt32(res[4]), Date = Convert.ToDateTime(res[5]), City = res[6].ToString() };
                }
                res.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return compet;
        }

        public static List<Competition> GetCompetition()
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            List<Competition> competition = new List<Competition>();

            try
            {
                string sql = "select idCompetition, Competition.Competition.Name, NameVenue, Street, Competition.City.Name, Home,Date from Competition.Competition join Competition.City on Competition.idCity = Competition.City.idCity;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    competition.Add(new Competition { ID = Convert.ToInt32(res[0]), Name = res[1].ToString(), NameVenue = res[2].ToString(), Street = res[3].ToString(), City = res[4].ToString(), Home = Convert.ToInt32(res[5].ToString()), Date = Convert.ToDateTime(res[6].ToString()) });
                }
                res.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return competition;
        }

        public static void AddCompetition(Competition compet)
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO `Competition`.`Competition` (`Name`, `NameVenue`, `Street`,Home,Date,idCity) SELECT '{compet.Name}', '{compet.NameVenue}', '{compet.Street}', {compet.Home}, '{compet.Date.ToString("yyyy-MM-dd hh:mm:ss")}', idCity  FROM Competition.City where '{compet.City}' = Competition.City.Name;", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }

        public static void RemoveCompetition(int id)
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"DELETE from Competition.Competition WHERE (idCompetition = '{id}')", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }

        public static void UpdateCompet(Competition compet)
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"update Competition.Competition set Name='{compet.Name}',NameVenue='{compet.NameVenue}',Street='{compet.Street}', Home='{compet.Home}',idCity = (select idCity from City where Competition.City.Name = '{compet.City}'), Date ='{compet.Date.ToString("yyyy-MM-dd hh:mm:ss")}' where idCompetition = {compet.ID};", conn);
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
