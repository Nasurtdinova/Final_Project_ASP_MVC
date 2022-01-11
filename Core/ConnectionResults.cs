using Dapper;
using Final_Project_ASP_MVC.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Core
{
    public class ConnectionResults
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["Competition"].ConnectionString;
        private static IDbConnection connection = new SqlConnection(connStr);

        public static List<Result> GetResults()
        {
            List<Result> results = new List<Result>();

            try
            {
                for (int i = 0; i < connection.Query<int>($"SELECT * FROM ResultCompetition;").Count(); i++)
                {
                    results.Add(new Result
                    {
                        idCommand = connection.Query<int>("SELECT Command.idCommand from ResultCompetition join Command on ResultCompetition.idCommand = Command.idCommand join Competition on ResultCompetition.idCompetition = Competition.idCompetition;").AsList()[i],
                        idCompet = connection.Query<int>("SELECT Competition.idCompetition from ResultCompetition join Command on ResultCompetition.idCommand = Command.idCommand join Competition on ResultCompetition.idCompetition = Competition.idCompetition;").AsList()[i],
                        Command = connection.Query<string>("SELECT Command.Name from ResultCompetition join Command on ResultCompetition.idCommand = Command.idCommand join Competition on ResultCompetition.idCompetition = Competition.idCompetition;").AsList()[i],
                        Compet = connection.Query<string>("SELECT Competition.Name from ResultCompetition join Command on ResultCompetition.idCommand = Command.idCommand join Competition on ResultCompetition.idCompetition = Competition.idCompetition;").AsList()[i],
                        Rank = connection.Query<int>("SELECT ResultCompetition.Rank from ResultCompetition join Command on ResultCompetition.idCommand = Command.idCommand join Competition on ResultCompetition.idCompetition = Competition.idCompetition;").AsList()[i]
                    });
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return results;
        }

        public static Result GetResultsId(int idCommand, int idCompet)
        {
            Result results = null;

            try
            {
                results = new Result
                {
                    idCommand = idCommand,
                    idCompet = idCompet,
                    Command = connection.Query<string>($"SELECT Command.Name from ResultCompetition join Command on ResultCompetition.idCommand = Command.idCommand join Competition on ResultCompetition.idCompetition = Competition.idCompetition where ResultCompetition.idCommand = {idCommand} and ResultCompetition.idCompetition = {idCompet};").AsList().FirstOrDefault(),
                    Compet = connection.Query<string>($"SELECT Competition.Name from ResultCompetition join Command on ResultCompetition.idCommand = Command.idCommand join Competition on ResultCompetition.idCompetition = Competition.idCompetition where ResultCompetition.idCommand = {idCommand} and ResultCompetition.idCompetition = {idCompet};").AsList().FirstOrDefault(),
                    Rank = connection.Query<int>($"SELECT ResultCompetition.Rank from ResultCompetition join Command on ResultCompetition.idCommand = Command.idCommand join Competition on ResultCompetition.idCompetition = Competition.idCompetition where ResultCompetition.idCommand = {idCommand} and ResultCompetition.idCompetition = {idCompet};").AsList().FirstOrDefault()
                };
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
            return results;
        }

        public static void RemoveResult(int idCommand, int idCompetition)
        {
            try
            {
                connection.Query($"DELETE from ResultCompetition WHERE (ResultCompetition.idCommand = {idCommand} and ResultCompetition.idCompetition = {idCompetition});");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static bool isTrue(string Command,string Competition)
        {
            if (connection.Query<string>($"SELECT Command.Name, Competition.Name from ResultCompetition join Competition on ResultCompetition.idCompetition = Competition.idCompetition join Command on ResultCompetition.idCommand = Command.idCommand where Competition.Name = '{Competition}' and Command.Name = '{Command}';").AsList().FirstOrDefault() == Command && connection.Query<string>($"SELECT Competition.Name from ResultCompetition join Competition on ResultCompetition.idCompetition = Competition.idCompetition join Command on ResultCompetition.idCommand = Command.idCommand where Competition.Name = '{Competition}' and Command.Name = '{Command}';").AsList().FirstOrDefault() == Competition)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isRankTrue(int rank, string compet)
        {
            if (connection.Query<int>($"select ResultCompetition.Rank from ResultCompetition where (select Competition.idCompetition from Competition where Name = '{compet}')= ResultCompetition.idCompetition and ResultCompetition.Rank = {rank};").AsList().FirstOrDefault() == rank)
            { 
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void AddResult(Result result)
        {
            try
            {
                connection.Query($"INSERT ResultCompetition values ((select Command.idCommand from Command where Command.Name = '{result.Command}'), (select Competition.idCompetition from Competition where Competition.Name = '{result.Compet}'), {result.Rank});");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateResult(Result result)
        {
            try
            {
                connection.Query($"update ResultCompetition set ResultCompetition.idCompetition=(select Competition.idCompetition from Competition where Competition.Name = '{result.Compet}'), ResultCompetition.idCommand=(select Command.idCommand from Command where Command.Name = '{result.Command}'), ResultCompetition.Rank = {result.Rank} where ResultCompetition.idCommand =(select Command.idCommand from Command where Command.Name = '{result.Command}') and ResultCompetition.idCompetition =(select Competition.idCompetition from Competition where Competition.Name = '{result.Compet}');");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
