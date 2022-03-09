using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreFramework
{
    public class Competitions : Competition
    {
        public Competitions() { }

        public Competitions(string[] args)
        {
            Name = args[0];
            NameVenue = args[1];
            Street = args[2];
            Home = Convert.ToInt32(args[3]);
            //CityName = args[4];
            Date = Convert.ToDateTime(args[5]);
        }

        public Competitions(string[] args, int id)
        {
            idCompetition = id;
            Name = args[1];
            NameVenue = args[2];
            Street = args[3];
            Home = Convert.ToInt32(args[4]);
            //CityName = args[5];
            Date = Convert.ToDateTime(args[6]);
        }
    }
}
