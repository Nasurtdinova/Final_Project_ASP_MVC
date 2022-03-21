using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFramework
{
    public class Sportsmans : Sportsman
    {
        public Sportsmans () {}

        public Sportsmans(string[] args)
        {
            Name = args[0];
            Surname = args[1];
            Height = Convert.ToInt32(args[4]);
            Cost = Convert.ToInt32(args[5]);
        }

        public Sportsmans(string[] args, int id)
        {
            ID = id;
            Name = args[1];
            Surname = args[2];
            Height = Convert.ToInt32(args[5]);
            Cost = Convert.ToInt32(args[6]);
        }
    }
}
