using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class Command : Commands
    {
        public Command() { }

        public Command(string[] args)
        {
            Name = args[0];
            City = args[1];
            Count = Convert.ToInt32(args[2]);
        }

        public Command(string[] args, int id)
        {
            ID = id;
            Name = args[1];
            City = args[2];
            Count = Convert.ToInt32(args[3]);
        }
    }
}
