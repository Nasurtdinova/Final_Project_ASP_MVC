using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFramework
{
    public class Sponsorship : SponsorCommand
    {
        public Sponsorship() { }

        public Sponsorship(string[] args)
        {
            Command.Name = args[0];
            amount = Convert.ToInt32(args[1]);
            teamContract = Convert.ToInt32(args[2]);
        }
    }
}
