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
                string sql = "SELECT Competition.ResultCompetition.idResult, Competition.Command.Name, Competition.Competition.Name, Competition.ResultCompetition.Rank " +
                    "from Competition.ResultCompetition " +
                    "join Competition.Command on Competition.ResultCompetition.idCommand = Competition.Command.idCommand " +
                    "join Competition.Competition on Competition.ResultCompetition.idCompetition = Competition.Competition.idCompetition;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    results.Add(new Result { ID = Convert.ToInt32(res[0]), Command = res[1].ToString(), Compet = res[2].ToString(), Rank = Convert.ToInt32(res[3]) });
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

        public static Result GetResultsId(int id)
        {
            conn.Open();
            Result results = null;

            try
            {
                string sql = $"SELECT Competition.ResultCompetition.idResult, Competition.Command.Name, Competition.Competition.Name, Competition.ResultCompetition.Rank from Competition.ResultCompetition join Competition.Command on Competition.ResultCompetition.idCommand = Competition.Command.idCommand join Competition.Competition on Competition.ResultCompetition.idCompetition = Competition.Competition.idCompetition where Competition.ResultCompetition.idResult = {id};";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    results = new Result { ID = Convert.ToInt32(res[0]), Command = res[1].ToString(), Compet = res[2].ToString(), Rank = Convert.ToInt32(res[3]) };
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

        public static void RemoveResult(int id)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"DELETE from Competition.ResultCompetition WHERE (idResult = {id});", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }



        public static void AddResult(Result result)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO Competition.ResultCompetition (idCommand, idCompetition, Competition.ResultCompetition.Rank) values ((select Competition.Command.idCommand from Competition.Command where Competition.Command.Name = '{result.Command}'), (select Competition.Competition.idCompetition from Competition.Competition where Competition.Competition.Name = '{result.Compet}'), {result.Rank});", conn);
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
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"update Competition.ResultCompetition set Competition.ResultCompetition.idCompetition=(select Competition.Competition.idCompetition from Competition.Competition where Competition.Competition.Name = '{result.Compet}'), Competition.ResultCompetition.idCommand=(select Competition.Command.idCommand from Competition.Command where Competition.Command.Name = '{result.Command}'), Competition.ResultCompetition.Rank = {result.Rank} where idResult = {result.ID};", conn);
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
