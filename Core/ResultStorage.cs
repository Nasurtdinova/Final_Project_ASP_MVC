using Final_Project_ASP_MVC.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class ResultStorage
    {
        public static List<Result> results { get; private set; } = Connection.GetResults();

        public static void Add(Result result)
        {
            Connection.AddResult(result);
            results.Add(result);
        }

        public static void RemoveByName(int idResult)
        {
            Connection.RemoveResult(idResult);
            results.RemoveAll(p => p.IDresult == idResult);
        }

        //public static void Update(Competition compet)
        //{
        //    Connection.UpdateCompet(compet);
        //    competition = Connection.GetCompetition();
        //}
    }
}
