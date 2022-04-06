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
            Amount = Convert.ToInt32(args[1]);
            DateBegin = Convert.ToDateTime(args[2]);
            DateEnd = Convert.ToDateTime(args[2]);
        }
    }
}
