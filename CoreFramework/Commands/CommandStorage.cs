using System.Collections;
using System.Collections.ObjectModel;

namespace CoreFramework
{
    public class CommandStorage : IEnumerable
    {
        public static ObservableCollection<Command> commands { get; private set; } = ConnectionCommands.GetCommands();

        public IEnumerator GetEnumerator()
        {
            return commands.GetEnumerator();
        }

        public static void Add(Command command)
        {
            ConnectionCommands.AddCommand(command);
            commands.Add(command);
        }

        public static void RemoveByName(int id)
        {
            ConnectionCommands.RemoveCommand(id);
            commands = ConnectionCommands.GetCommands();
        }

        public static void Update(Command command)
        {
            ConnectionCommands.UpdateCommand(command);
            commands = ConnectionCommands.GetCommands();
        }
    }
}
