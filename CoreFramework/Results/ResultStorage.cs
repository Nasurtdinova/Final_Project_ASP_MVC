
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CoreFramework
{
    public class ResultStorage
    {
        public static ObservableCollection<ResultCompetition> results { get; private set; } = ConnectionResults.GetResults();

        public static void Add(ResultCompetition result)
        {
            //if (ConnectionResults.isTrue(result.NameCommand,result.NameCompetition) || ConnectionResults.isRankTrue(Convert.ToInt32(result.Rank), result.NameCompetition))
            //{
            //    throw new Exception("!!!!");
            //}
            //else
            //{
            //    ConnectionResults.AddResult(result);
            //    results.Add(result);
            //}         
        }

        public static void RemoveByName(int idCommand, int idCompetition)
        {
            ConnectionResults.RemoveResult(idCommand, idCompetition);
            results = ConnectionResults.GetResults();
        }

        public static void Update(ResultCompetition result)
        {
            ConnectionResults.UpdateResult(result);
            results = ConnectionResults.GetResults();
        }
    }
}
