using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_ASP_MVC.Core
{
    public class CommandStorage : IEnumerable
    {
        public static List<Command> commands { get; private set; } = Connection.GetCommands();

        public IEnumerator GetEnumerator()
        {
            return commands.GetEnumerator();
        }
    }
}
