
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
            return new ObservableCollection<ResultCompetition>(bdConnection.connection.ResultCompetition.ToList().Where(a=>a.Command.IsDeleted == false && a.Competition.IsDeleted == false));
        }
        public static List<ResultCompetition> GetResutCompet(int idCompet)
        {
            try
            {
                return GetResults().Where(tt => tt.idCompetition == idCompet).ToList();
            }

            catch // Exception исправить
            {
                return null;
            }
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

        public static bool isComCompetTrue(int Command,int Competition)
        {
            if (GetResults().Where(t => t.idCommand == Command && t.idCompetition == Competition).Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isRankTrue(int rank, int compet)
        {
            if (GetResults().Where(t => t.Rank == rank && t.idCompetition == compet).Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void AddResult(ResultCompetition result)
        {
            try
            {
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
