using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CoreFramework
{
    public class ConnectionCommands //разнести классы по папочкам
    {
        private static ObservableCollection<Sportsman> sporCom;

        public static ObservableCollection<Sportsman> GetSporCom(int id)
        {
            sporCom = new ObservableCollection<Sportsman>();
            try
            {
                ObservableCollection<Sportsman> sportsman = new ObservableCollection<Sportsman>(bdConnection.connection.Sportsman.ToList());
                var spor = sportsman.Where(tt => tt.idCommand == id).FirstOrDefault();
                sporCom.Add(spor);
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
                ObservableCollection<City> city = new ObservableCollection<City>(bdConnection.connection.City);
                //var type = city.Where(tt => tt.Name == command.CityName).FirstOrDefault();
                command.ID_city = city.Where(a=>a.Name == command.City.Name).FirstOrDefault().idCity;
                command.City.idCity = city.Where(a => a.Name == command.City.Name).FirstOrDefault().idCity;
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
                //com.Image = command.Image;
                com.Count = command.Count;
                var cit = bdConnection.connection.City.SingleOrDefault(r => r.Name == command.City.Name);
                com.ID_city = cit.idCity;
           
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static string GetCity(int id)
        {
            ObservableCollection<Command> commands = GetCommands();
            List<City> city = new  List<City>(bdConnection.connection.City.ToList());
            var type = city.Where(tt => tt.idCity == id).FirstOrDefault();
            return type.Name;
        }

        public static Command GetCommandsId(int id)
        {
            ObservableCollection<Command> commands = GetCommands();
            var com = commands.Where(tt => tt.idCommand == id).FirstOrDefault();
            return com;
        }

    }
}
