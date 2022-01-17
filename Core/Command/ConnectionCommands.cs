using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Core
{
    public class ConnectionCommands
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["Competition"].ConnectionString;
        private static IDbConnection connection = new SqlConnection(connStr);

        private static List<Sportsman> sporCom;

        public static List<Sportsman> GetSporCom(int id)
        {
            sporCom = new List<Sportsman>();

            for (int i = 0; i < connection.Query<int>($"select * from Sportsman where idCommand = {id};").Count(); i++)
            {
                sporCom.Add(new Sportsman
                {
                    ID = connection.Query<int>($"select idCommand from Sportsman where idCommand = {id};").AsList()[i],
                    Surname = connection.Query<string>($"select Surname from Sportsman where idCommand = {id};").AsList()[i],
                    Name = connection.Query<string>($"select Sportsman.Name from Sportsman where idCommand = {id};").AsList()[i]
                });
            }  

            return sporCom;
        }

        public static List<Command> GetCommands()
        {
            List<Command> commands = new List<Command>();

            for (int i = 0; i < connection.Query<int>($"select * from Command;").Count(); i++)
            {
                commands.Add(new Command
                {
                    ID = connection.Query<int>("SELECT idCommand FROM Command join City  on ID_city = idCity;").AsList()[i],
                    Name = connection.Query<string>("SELECT Command.Name FROM Command join City  on ID_city = idCity;").AsList()[i],
                    Count = connection.Query<int>("SELECT Count FROM Command join City  on ID_city = idCity;").AsList()[i],
                    Image = connection.Query<string>("SELECT Image FROM Command join City  on ID_city = idCity;").AsList()[i],
                    City = connection.Query<string>("SELECT City.Name FROM Command join City  on ID_city = idCity;").AsList()[i]
                });
            }
        
            return commands;
        }

        public static void AddCommand(Command command)
        {
            try
            {
                connection.Query($"INSERT INTO Command (Name, Count, Image,ID_city) SELECT '{command.Name}', {command.Count}, '{command.Image}'," +
                    $"idCity  FROM City where '{command.City}' = City.Name;");
            }
            catch 
            {
                throw new Exception("Incorrect data!!!");
            }
        }

        public static void RemoveCommand(int id)
        {
            try
            {
                connection.Query($"DELETE from Command WHERE (idCommand = '{id}')");
            }
            catch 
            {
                throw new Exception("Incorrect data!!!");
            }
        }

        public static void UpdateCommand(Command command)
        {
            try
            {
                connection.Query($"update Command set Name='{command.Name}',Count={command.Count},Image='{command.Image}'," +
                $"ID_city = (select City.idCity from City where City.Name = '{command.City}') where idCommand = {command.ID};");
            }
            catch
            {
                throw new Exception("Incorrect data!!!");
            }
        }

        public static Command GetCommandsId(int id)
        {
            Command command = null;

            command = new Command
            {
                ID = connection.Query<int>($"SELECT idCommand FROM Command join City on ID_city = idCity where Command.idCommand = {id};").AsList().FirstOrDefault(),
                Name = connection.Query<string>($"SELECT Command.Name FROM Command join City on ID_city = idCity where Command.idCommand = {id};").AsList().FirstOrDefault(),
                Count = connection.Query<int>($"SELECT Count FROM Command join City on ID_city = idCity where Command.idCommand = {id};").AsList().FirstOrDefault(),
                Image = connection.Query<string>($"SELECT Image FROM Command join City on ID_city = idCity where Command.idCommand = {id};").AsList().FirstOrDefault(),
                City = connection.Query<string>($"SELECT City.Name FROM Command join City on ID_city = idCity where Command.idCommand = {id};").AsList().FirstOrDefault()
            };

            return command;
        }
    }
}
