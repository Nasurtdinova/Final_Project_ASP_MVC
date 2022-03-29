using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFramework
{
    public class Commands : Command
    {
        public Commands() { }

        public Commands(string[] args)
        {
            Name = args[0];
            //CityName = args[1];
            Count = Convert.ToInt32(args[2]);
        }

        public Commands(string[] args, int id)
        {
            idCommand = id;
            Name = args[1];
            //CityName = args[2];
            Count = Convert.ToInt32(args[3]);
        }


    }
}
