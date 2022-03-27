
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
//лишние библиотеки убрать
namespace CoreFramework
{
    public class ConnectionResults //разнести классы по папочкам
    {
        public static ObservableCollection<ResultCompetition> GetResults()
        {
            return new ObservableCollection<ResultCompetition>(bdConnection.connection.ResultCompetition.ToList());
        }

        public static ResultCompetition GetResultsId(int idCommand, int idCompet)
        {
            ObservableCollection<ResultCompetition> results = GetResults();
            var com = results.Where(tt => tt.idCommand == idCommand && tt.idCompetition == idCompet).FirstOrDefault();
            ResultCompetition command = new ResultCompetition
            {
                idCommand = idCommand,
                idCompetition = idCompet,
                //NameCommand = com.Command.Name,
                //NameCompetition = com.Competition.Name,
                Rank = com.Rank               
            };
            return command;
        }

        public static void RemoveResult(int idCommand, int idCompetition)
        {
            try
            {
                ResultCompetition com = bdConnection.connection.ResultCompetition.FirstOrDefault(p => p.idCommand == idCommand && p.idCompetition == idCompetition);
                bdConnection.connection.ResultCompetition.Remove(com);
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex) // Exception исправить
            { 
                Console.WriteLine(ex.Message); 
            }
        }

        public static bool isTrue(string Command,string Competition)
        {
            List<ResultCompetition> resultCompet = new List<ResultCompetition>(bdConnection.connection.ResultCompetition);
            //if (resultCompet.Where(t => t.NameCommand == Command).First().NameCommand == Command && resultCompet.Where(t => t.NameCompetition == Competition).First().NameCompetition == Competition)
            //{
            //    return true;
            //}
            //else
            //{
                return false;
            //}
        }

        public static bool isRankTrue(int rank, string compet)
        {
            List<ResultCompetition> resultCompet = new List<ResultCompetition>(bdConnection.connection.ResultCompetition);
            //if (resultCompet.Where(t => t.Rank == rank).First().Rank == rank && resultCompet.Where(t => t.NameCompetition == compet).First().NameCompetition == compet)
            //{
            //    return true;
            //}
            //else
            //{
                return false;
            //}
        }

        public static void AddResult(ResultCompetition result)
        {
            try
            {
                //List<Command> com = new List<Command>(bdConnection.connection.Command);
                //var type = com.Where(tt => tt.Name == result.NameCommand).FirstOrDefault();
                //result.idCommand = type.idCommand;

                //List<Competition> compet = new List<Competition>(bdConnection.connection.Competition);
                //var type1 = compet.Where(tt => tt.Name == result.NameCompetition).FirstOrDefault();
                //result.idCompetition = type1.idCompetition;
                bdConnection.connection.ResultCompetition.Add(result);
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateResult(ResultCompetition result)
        {
            try
            {
                var res = bdConnection.connection.ResultCompetition.SingleOrDefault(tt => tt.Command.Name == result.Command.Name && tt.Competition.Name == result.Competition.Name);
                //var com = bdConnection.connection.ResultCompetition.SingleOrDefault(tt => tt.NameCommand == result.NameCommand);
                //var compet = bdConnection.connection.ResultCompetition.SingleOrDefault(tt => tt.NameCompetition == result.NameCompetition);
                res.idCommand = result.idCommand;
                res.idCompetition = result.idCompetition;
                res.Rank = result.Rank;
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
