using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Result : Results
    {
        public Result() { }

        public Result(string[] args)
        {
            Command = args[0];
            Compet = args[1];
            Rank = Convert.ToInt32(args[2]);
        }
    }
}
