using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Sponsorship
    {
        public int ID { get; set; }
        public string SponsorName { get; set; }
        public string SponsorSurname { get; set; }
        public string Command { get; set; }
        public int teamContract { get; set; }
        public int Amount { get; set; }
    }
}
