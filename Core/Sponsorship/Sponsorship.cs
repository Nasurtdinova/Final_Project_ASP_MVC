using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Sponsorship : Sponsorships
    {
        public Sponsorship() { }

        public Sponsorship(string[] args)
        {
            Command = args[0];
            Amount = Convert.ToInt32(args[1]);
            teamContract = Convert.ToInt32(args[2]);
        }
    }
}
