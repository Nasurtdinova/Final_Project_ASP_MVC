using Dapper;
using Final_Project_ASP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Core
{
    public class Connection
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["Competition"].ConnectionString;
        private static IDbConnection connection = new SqlConnection(connStr);

        private static List<string> images;
        private static List<string> cities;
        private static List<string> titles;
        private static List<string> commands;
        private static List<string> competitions;

        public static int IdUser { get; set; }
        public static string Name { get; set; }
        public static string Surname { get; set; }

        public Connection(string login, string password)
        {
            IdUser = GetIdUser(login, password);
            GetUser(IdUser);
        }

        public static int GetIdUser(string email, string password)
        {
            return connection.Query<int>( $"SELECT idUser FROM Users where '{email}' = Email and '{password}' = Password;").AsList()[0];
        }

        public static bool GetIdType(string email, string password)
        {
            if (connection.Query<int>($"SELECT idType FROM Users where '{email}' = Email and '{password}' = Password;").AsList()[0] == 1)
                return true;
            else
                return false;
        }

        public static void GetUser(int idUser)
        {
            Name =connection.Query<string>($"SELECT Name FROM Users where '{idUser}' = idUser;").AsList()[0];
            Surname = connection.Query<string>($"SELECT Surname FROM Users where '{idUser}' = idUser;").AsList()[0];
        }

        public static void AddUser(User user)
        {   
            try
            {
                connection.Query($"INSERT Users Values ('{user.Email}','{user.Password}', {user.Year}, '{user.UserName}', '{user.Surname}');");
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }        
        }

        public static List<string> GetImages()
        {
            images = new List<string>();
            foreach (var i in connection.Query<string>("SELECT Name FROM Images").AsList())
            {
                images.Add(i);
            }
            return images;          
        }

        public static List<string> GetTitles()
        {       
            titles = new List<string>();
            foreach (var i in connection.Query<string>("SELECT Name FROM Title").AsList())
            {
                titles.Add(i);
            }
            return titles;
        }

        public static List<string> GetNameCommands()
        {
            commands = new List<string>();
            foreach (var i in connection.Query<string>("SELECT Name FROM Command").AsList())
            {
                commands.Add(i);
            }
            return commands;
        }

        public static List<string> GetNameCompets()
        {        
            competitions = new List<string>();
            foreach (var i in connection.Query<string>("SELECT Name FROM Competition").AsList())
            {
                competitions.Add(i);
            }
            return competitions;
        }

        public static List<string> GetCities()
        {
            cities = new List<string>();
            foreach (var i in connection.Query<string>("SELECT Name FROM City").AsList())
            {
                cities.Add(i);
            }
            return cities;
        }

        public static string GetNameCommand(int id)
        {
            return connection.Query<string>($"SELECT Name FROM Command where '{id}' = idCommand;").AsList()[0];
        }

        public static string GetNameTitle(int id)
        {
            return connection.Query<string>($"SELECT Name FROM Title where '{id}' = idTitle;").AsList()[0];
        }

        public static string GetNameImage(int id)
        {
            return connection.Query<string>($"SELECT Name FROM Images where '{id}' = idImages;").AsList()[0];
        }

        public static int GetIdCommand(string name)
        {
            return connection.Query<int>($"SELECT idCommand FROM Command where '{name}' = Name;").AsList()[0];
        }

        public static int GetIdTitle(string name)
        {
            return connection.Query<int>($"SELECT idTitle FROM Title where '{name}' = Name;").AsList()[0];
        }

        public static int GetIdImage(string name)
        {
            return connection.Query<int>($"SELECT idImages FROM Images where '{name}' = Name;").AsList()[0];
        }

        public static bool IsLogin(string email, string password)
        {
            if (connection.Query<string>($"SELECT Email FROM Users where '{email}' = Email and '{password}' = Password;").AsList()[0] == email 
            && connection.Query<string>($"SELECT Password FROM Users where '{email}' = Email and '{password}' = Password;").AsList()[0] == password)
            {
                return true;
            }
            else
            {
                return false;
            }             
        }       
    }
}
