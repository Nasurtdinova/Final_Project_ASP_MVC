
using Final_Project_ASP_MVC.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class ResultStorage
    {
        public static List<Result> results { get; private set; } = ConnectionResults.GetResults();

        public static void Add(Result result)
        {
            if (ConnectionResults.isTrue(result.Command,result.Compet))
            {
                throw new Exception("!!!!");
            }
            else
            {
                ConnectionResults.AddResult(result);
                results.Add(result);
            }         
        }

        public static void RemoveByName(int idCommand, int idCompetition)
        {
            ConnectionResults.RemoveResult(idCommand, idCompetition);
            results = ConnectionResults.GetResults();
        }

        public static void Update(Result result)
        {
            ConnectionResults.UpdateResult(result);
            results = ConnectionResults.GetResults();
        }
    }
}
