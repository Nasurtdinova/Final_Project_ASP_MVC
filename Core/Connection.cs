﻿using Dapper;
using Final_Project_ASP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Final_Project_ASP_MVC.Core
{
    public class Connection
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["Competition"].ConnectionString;
        private static IDbConnection connection = new SqlConnection(connStr);
        public static List<string> images;
        public static List<string> cities;
        public static List<string> titles;
        public static List<string> commands;
        public static List<string> competitions;

        public static int idUser { get; set; }
        public static string Name { get; set; }
        public static string Surname { get; set; }

        public Connection(string login, string password)
        {
            idUser = GetIdUser(login, password);
            GetUser(idUser);
        }

        public static int GetIdUser(string email, string password)
        {
            return connection.Query<int>( $"SELECT idUser FROM Users where '{email}' = Email and '{password}' = Password;").AsList()[0];
        }

        public static void GetUser(int idUser)
        {
            Name =connection.Query<string>($"SELECT Name, Surname FROM Users where '{idUser}' = idUser;").AsList()[0];
            Surname = connection.Query<string>($"SELECT Name, Surname FROM Users where '{idUser}' = idUser;").AsList()[1];
        }

        public static void AddUser(User user)
        {   
            try
            {
                connection.Query($"INSERT Users Values ('{user.Email}','{user.Password}', {user.Year}, '{user.UserName}', '{user.Surname}');");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }        
        }

        public static List<string> GetImages()
        {
            images = new List<string>();
            foreach (var i in connection.Query("SELECT Name FROM Images").AsList())
            {
                images.Add(i);
            }
            return images;          
        }

        public static List<string> GetTitles()
        {       
            titles = new List<string>();
            foreach (var i in connection.Query("SELECT Name FROM Title").AsList())
            {
                titles.Add(i);
            }
            return titles;
        }

        public static List<string> GetNameCommands()
        {
            commands = new List<string>();
            foreach (var i in connection.Query("SELECT Name FROM Command").AsList())
            {
                commands.Add(i);
            }
            return commands;
        }

        public static List<string> GetNameCompets()
        {        
            competitions = new List<string>();
            foreach (var i in connection.Query("SELECT Name FROM Competition").AsList())
            {
                competitions.Add(i);
            }
            return competitions;
        }

        public static List<string> GetCities()
        {
            cities = new List<string>();
            foreach (var i in connection.Query("SELECT Name FROM City").AsList())
            {
                cities.Add(i);
            }
            return cities;
        }

        public static bool IsLogin(string email, string password)
        {
            if (connection.Query<string>($"SELECT Email FROM Users where '{email}' = Email and '{password}' = Password;").AsList()[0] == email && connection.Query<string>($"SELECT Password FROM Users where '{email}' = Email and '{password}' = Password;").AsList()[0] == password)
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
