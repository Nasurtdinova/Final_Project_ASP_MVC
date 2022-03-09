using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CoreFramework
{
    public class ConnectionCommands //разнести классы по папочкам
    {
        private static List<Sportsman> sporCom;

        public static List<Sportsman> GetSporCom(int id)
        {
            sporCom = new List<Sportsman>();
            try
            {
                List<Sportsman> sportsman = new List<Sportsman>(bdConnection.connection.Sportsman.ToList());
                var spor = sportsman.Where(tt => tt.idCommand == id).FirstOrDefault();
                sporCom.Add(new Sportsman
                {
                    ID = spor.ID,
                    Surname = spor.Surname,
                    Name = spor.Name
                });
            }

            catch // Exception исправить
            {
                return null;
            }
            return sporCom;
        }

        public static List<Command> GetCommands()
        {
            List<Command> commands = new List<Command>(bdConnection.connection.Command.ToList());
            return commands;
        }

        public static void AddCommand(Command command)
        {
            try
            {
                List<City> city = new List<City>(bdConnection.connection.City);
                var type = city.Where(tt => tt.Name == command.CityName).FirstOrDefault();
                command.ID_city = type.idCity;
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
                com.Image = command.Image;
                com.Count = command.Count;
                var cit = bdConnection.connection.City.SingleOrDefault(r => r.Name == command.CityName);
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
            List<Command> commands = GetCommands();
            List<City> city = new  List<City>(bdConnection.connection.City.ToList());
            var type = city.Where(tt => tt.idCity == id).FirstOrDefault();
            return type.Name;
        }

        public static Command GetCommandsId(int id)
        {
            List<Command> commands = GetCommands();
            var com = commands.Where(tt => tt.idCommand == id).FirstOrDefault();
            Command command = new Command
            {
                idCommand = id,
                Name = com.Name,
                Count = com.Count,
                Image = com.Image,
                CityName = com.City.Name,
                ID_city = com.City.idCity
            };
            return command;
        }

    }
}
