
using Core;
using Final_Project_ASP_MVC.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_ASP_MVC.Core
{
    public class Connection
    {
        public static string connStr = ConfigurationManager.AppSettings["connection"].ToString();
        public static MySqlConnection conn;
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
            conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = $"SELECT idUser FROM Competition.User where '{email}' = Email and '{password}' = Password;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader res = cmd.ExecuteReader();
            while (res.Read())
            {
                return Convert.ToInt32(res[0]);
            }
            res.Close();
            conn.Close();
            return Convert.ToInt32(res[0]);
        }

        public static void GetUser(int idUser)
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = $"SELECT Name, Surname FROM Competition.User where '{idUser}' = idUser;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader res = cmd.ExecuteReader();
            while (res.Read())
            {
                Name = res[0].ToString();
                Surname = res[1].ToString();
            }
            res.Close();
            conn.Close();
        }

        public static void AddUser(User user)
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO `Competition`.`User` (`Email`, `Password`, `Year`, Competition.User.Name, Competition.User.Surname) Values ('{user.Email}','{user.Password}', {user.Year}, '{user.UserName}', '{user.Surname}')", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }

        public static List<string> GetImages()
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            images = new List<string>();
            string sql = "SELECT Name FROM Images";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader img = cmd.ExecuteReader();

            while (img.Read())
            {
                images.Add(img[0].ToString());
            }
            img.Close();
            conn.Close();
            return images;          
        }

        public static List<string> GetTitles()
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            titles = new List<string>();
            string sql = "SELECT Name FROM Title";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader tit = cmd.ExecuteReader();

            while (tit.Read())
            {
                titles.Add(tit[0].ToString());
            }
            tit.Close();
            conn.Close();
            return titles;
        }

        public static List<string> GetNameCommands()
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            commands = new List<string>();
            string sql = "SELECT Name FROM Command";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader com = cmd.ExecuteReader();

            while (com.Read())
            {
                commands.Add(com[0].ToString());
            }
            com.Close();
            conn.Close();
            return commands;
        }

        public static List<string> GetNameCompets()
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            competitions = new List<string>();
            string sql = "SELECT Name FROM Competition.Competition";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader com = cmd.ExecuteReader();

            while (com.Read())
            {
                competitions.Add(com[0].ToString());
            }
            com.Close();
            conn.Close();
            return competitions;
        }

        public static List<string> GetCities()
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            cities = new List<string>();
            string sql = "SELECT Name FROM City";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader city = cmd.ExecuteReader();

            while (city.Read())
            {
                cities.Add(city[0].ToString());
            }
            city.Close();
            conn.Close();
            return cities;
        }

        public static bool IsLogin(string email, string password)
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = $"SELECT Email,Password FROM Competition.User where '{email}' = Email and '{password}' = Password;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader res = cmd.ExecuteReader();
            while (res.Read())
            {
                if (res[0].ToString() == email && res[1].ToString() == password)
                {                   
                    return true;
                }
                else
                {
                    return false;
                }              
            }           
            res.Close();
            conn.Close();
            return false;
        }       
    }
}
