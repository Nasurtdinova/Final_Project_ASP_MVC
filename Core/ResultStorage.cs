
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

        public static void RemoveByName(int id)
        {
            Connection.RemoveResult(id);
            results.RemoveAll(p => p.ID == id);
        }

        public static void Update(Result result)
        {
            Connection.UpdateResult(result);
            results = Connection.GetResults();
        }
    }
}
