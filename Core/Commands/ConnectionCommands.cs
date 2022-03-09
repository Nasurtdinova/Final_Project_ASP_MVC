using Dapper;
using Final_Project_ASP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
//лишние библиотеки убрать
namespace Core
{
    public class ConnectionCommands //разнести классы по папочкам
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["Competition"].ConnectionString;
        private static IDbConnection connection = new SqlConnection(connStr);

        private static ObservableCollection<Sportsman> sporCom;

        public static ObservableCollection<Sportsman> GetSporCom(int id)
        {
            sporCom = new ObservableCollection<Sportsman>();
            try
            {
                for (int i = 0; i < connection.Query<int>($"select * from Sportsman where idCommand = {id};").Count(); i++)
                {
                    sporCom.Add(new Sportsman
                    {
                        ID = connection.Query<int>($"select idCommand from Sportsman where idCommand = {id};").AsList()[i],
                        Surname = connection.Query<string>($"select Surname from Sportsman where idCommand = {id};").AsList()[i],
                        Name = connection.Query<string>($"select Sportsman.Name from Sportsman where idCommand = {id};").AsList()[i]
                    });
                }
            }

            catch // Exception исправить
            {
                return null;
            }
            return sporCom;
        }

        public static ObservableCollection<Commands> GetCommands()
        {
            ObservableCollection<Commands> commands = new ObservableCollection<Commands>();

            try
            {
                for (int i = 0; i < connection.Query<int>($"select * from Command;").Count(); i++)
                {
                    commands.Add(new Commands
                    {
                        ID = connection.Query<int>("SELECT idCommand FROM Command join City  on ID_city = idCity;").AsList()[i],
                        Name = connection.Query<string>("SELECT Command.Name FROM Command join City  on ID_city = idCity;").AsList()[i],
                        Count = connection.Query<int>("SELECT Count FROM Command join City  on ID_city = idCity;").AsList()[i],
                        Image = connection.Query<string>("SELECT Image FROM Command join City  on ID_city = idCity;").AsList()[i],
                        City = connection.Query<string>("SELECT City.Name FROM Command join City  on ID_city = idCity;").AsList()[i]
                    });
                }
            }

            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
            return commands;
        }

        public static void AddCommand(Command command)
        {
            try
            {
                connection.Query($"INSERT INTO Command (Name, Count, Image,ID_city) SELECT '{command.Name}', {command.Count}, '{command.Image}', idCity  FROM City where '{command.City}' = City.Name;");
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void RemoveCommand(int id)
        {
            try
            {
                connection.Query($"DELETE from Command WHERE (idCommand = '{id}')");
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
                connection.Query($"update Command set Name='{command.Name}',Count={command.Count},Image='{command.Image}', ID_city = (select City.idCity from City where City.Name = '{command.City}') where idCommand = {command.ID};");
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static Command GetCommandsId(int id)
        {
            Command command = null;
            try
            {
                command = new Command
                {
                    ID = connection.Query<int>($"SELECT idCommand FROM Command join City on ID_city = idCity where Command.idCommand = {id};").AsList().FirstOrDefault(),
                    Name = connection.Query<string>($"SELECT Command.Name FROM Command join City on ID_city = idCity where Command.idCommand = {id};").AsList().FirstOrDefault(),
                    Count = connection.Query<int>($"SELECT Count FROM Command join City on ID_city = idCity where Command.idCommand = {id};").AsList().FirstOrDefault(),
                    Image = connection.Query<string>($"SELECT Image FROM Command join City on ID_city = idCity where Command.idCommand = {id};").AsList().FirstOrDefault(),
                    City = connection.Query<string>($"SELECT City.Name FROM Command join City on ID_city = idCity where Command.idCommand = {id};").AsList().FirstOrDefault()
                };
            }

            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
            return command;
        }
    }
}
