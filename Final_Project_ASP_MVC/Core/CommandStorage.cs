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

        public void Add(Command command)
        {
            Connection.AddCommand(command);
            commands.Add(command);
        }

        public void RemoveByName(int id)
        {
            Connection.RemoveCommand(id);
            commands.RemoveAll(p => p.ID == id);
        }
    }
}
