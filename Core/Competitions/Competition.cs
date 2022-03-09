using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class Competition : Competitions
    {
        public Competition() { }

        public Competition(string[] args)
        {
            Name = args[0];
            NameVenue = args[1];
            Street = args[2];
            Home = Convert.ToInt32(args[3]);
            City = args[4];
            Date = Convert.ToDateTime(args[5]);
        }

        public Competition(string[] args, int id)
        {
            ID = id;
            Name = args[1];
            NameVenue = args[2];
            Street = args[3];
            Home = Convert.ToInt32(args[4]);
            City = args[5];
            Date = Convert.ToDateTime(args[6]);
        }
    }
}
