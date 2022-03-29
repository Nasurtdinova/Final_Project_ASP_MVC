using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CoreFramework
{
    public class ConnectionCommands
    {
        private static List<Sportsman> sporCom;

        public static List<Sportsman> GetSporCom(int id)
        {
            try
            {
                ObservableCollection<Sportsman> sportsman = new ObservableCollection<Sportsman>(bdConnection.connection.Sportsman.ToList());
                sporCom = sportsman.Where(tt => tt.idCommand == id).ToList();
            }

            catch // Exception исправить
            {
                return null;
            }
            return sporCom;
        }

        public static ObservableCollection<Command> GetCommands()
        {
            ObservableCollection<Command> commands = new ObservableCollection<Command>(bdConnection.connection.Command.ToList());
            return commands;
        }

        public static void AddCommand(Command command)
        {
            try
            {
                command.City = Connection.GetIdCity(command.City.Name);
                command.Image = command.Image;

                bdConnection.connection.Command.Add(command);
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static void RemoveCommand(int id)
        {
            try
            {
                Command com = bdConnection.connection.Command.FirstOrDefault(p => p.idCommand == id);
                bdConnection.connection.Command.Remove(com);
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateCommand(Command command)
        {
            try
            {
                var com = bdConnection.connection.Command.SingleOrDefault(r => r.idCommand == command.idCommand);
                com.Name = command.Name;
                com.Count = command.Count;
                com.City = Connection.GetIdCity(command.City.Name);
                //com.Images = Connection.GetIdImage(command.Images.Name);

                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static Command GetCommandsId(int id)
        {
            ObservableCollection<Command> commands = GetCommands();
            return commands.Where(tt => tt.idCommand == id).FirstOrDefault();
        }
    }
}
