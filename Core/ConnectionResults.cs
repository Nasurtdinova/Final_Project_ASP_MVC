using Final_Project_ASP_MVC.Core;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Core
{
    public class ConnectionResults
    {
        public static string connStr = ConfigurationManager.AppSettings["connection"].ToString();
        public static MySqlConnection conn;

        public static List<Result> GetResults()
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            List<Result> results = new List<Result>();

            try
            {
                string sql = "SELECT Competition.Command.idCommand, Competition.Competition.idCompetition, Competition.Command.Name, Competition.Competition.Name, Competition.ResultCompetition.Rank " +
                    "from Competition.ResultCompetition " +
                    "join Competition.Command on Competition.ResultCompetition.idCommand = Competition.Command.idCommand " +
                    "join Competition.Competition on Competition.ResultCompetition.idCompetition = Competition.Competition.idCompetition;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    results.Add(new Result { idCommand = Convert.ToInt32(res[0]), idCompet = Convert.ToInt32(res[1]), Command = res[2].ToString(), Compet = res[3].ToString(), Rank = Convert.ToInt32(res[4]) });
                }
                res.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return results;
        }

        public static Result GetResultsId(int idCommand, int idCompet)
        {
            conn.Open();
            Result results = null;

            try
            {
                string sql = $"SELECT Competition.Command.Name, Competition.Competition.Name, Competition.ResultCompetition.Rank from Competition.ResultCompetition join Competition.Command on Competition.ResultCompetition.idCommand = Competition.Command.idCommand join Competition.Competition on Competition.ResultCompetition.idCompetition = Competition.Competition.idCompetition where Competition.ResultCompetition.idCommand = {idCommand} and Competition.ResultCompetition.idCompetition = {idCompet};";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    results = new Result { idCommand = idCommand, idCompet = idCompet,  Command = res[0].ToString(), Compet = res[1].ToString(), Rank = Convert.ToInt32(res[2]) };
                }
                res.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return results;
        }

        public static void RemoveResult(int idCommand, int idCompetition)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"DELETE from Competition.ResultCompetition WHERE (Competition.ResultCompetition.idCommand = {idCommand} && Competition.ResultCompetition.idCompetition = {idCompetition});", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }

        public static bool isTrue(string Command,string Competition)
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
                string sql = $"SELECT Competition.Command.idCommand, Competition.Competition.idCompetition from Competition.ResultCompetition join Competition.Competition on Competition.ResultCompetition.idCompetition = Competition.Competition.idCompetition join Competition.Command on Competition.ResultCompetition.idCommand = Competition.Command.idCommand where Competition.Competition.Name = '{Competition}' and Competition.Command.Name = '{Command}';";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

            while (res.Read())
            {
                if (res[0].ToString() == Command && res[1].ToString() == Competition)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            res.Close();
            conn.Close();
            return false;
        }

        public static void AddResult(Result result)
        {
            conn = new MySqlConnection(connStr);
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO Competition.ResultCompetition (Competition.ResultCompetition.idCommand, Competition.ResultCompetition.idCompetition, Competition.ResultCompetition.Rank) values ((select Competition.Command.idCommand from Competition.Command where Competition.Command.Name = '{result.Command}'), (select Competition.Competition.idCompetition from Competition.Competition where Competition.Competition.Name = '{result.Compet}'), {result.Rank});", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }

        public static void UpdateResult(Result result)
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"update Competition.ResultCompetition set Competition.ResultCompetition.idCompetition=(select Competition.Competition.idCompetition from Competition.Competition where Competition.Competition.Name = '{result.Compet}'), Competition.ResultCompetition.idCommand=(select Competition.Command.idCommand from Competition.Command where Competition.Command.Name = '{result.Command}'), Competition.ResultCompetition.Rank = {result.Rank} where Competition.ResultCompetition.idCommand =(select Competition.Command.idCommand from Competition.Command where Competition.Command.Name = '{result.Command}') and Competition.ResultCompetition.idCompetition =(select Competition.Competition.idCompetition from Competition.Competition where Competition.Competition.Name = '{result.Compet}');", conn);
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
