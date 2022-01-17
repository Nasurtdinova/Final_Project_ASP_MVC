using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class Competition
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NameVenue { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Home { get; set; }
        public DateTime Date { get; set; }
    }
}
