using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFramework
{
    public class Results : ResultCompetition
    {
        public Results() { }

        public Results(string[] args)
        {
           Command.Name = args[0];
           Competition.Name = args[1];
            Rank = Convert.ToInt32(args[2]);
        }
    }
}
