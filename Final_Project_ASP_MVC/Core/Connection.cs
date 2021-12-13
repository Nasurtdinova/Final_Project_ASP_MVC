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

        //static Connection()
        //{
        //    conn.Open();
        //}

        public static List<string> GetImages()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
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

        public static List<string> GetCities()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
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
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            try
            {
                string sql = $"SELECT Email,Password FROM Competition.User where '{email}' = Email and '{password}' = Password ;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();
                conn.Close();
                return true;
            }
            catch
            {
                conn.Close();
                return false;
            }
            
        }
        public static List<Sportsman> GetSportsmans()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            List<Sportsman> sportsmans = new List<Sportsman>();

            try
            {
                string sql = "SELECT ID,Surname,Competition.Sportsman.Name,Competition.Images.Name FROM Competition.Sportsman  join Competition.Images  on ID_Image = idImages;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    sportsmans.Add(new Sportsman { ID = Convert.ToInt32(res[0]), Surname = res[1].ToString(), Name = res[2].ToString(), Image = res[3].ToString() });
                }
                res.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return sportsmans;
        }

        public static Sportsman GetSportsmansId(int id)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Sportsman sportsman = null;
            try
            {
                string sql = $"SELECT ID,Surname,Competition.Sportsman.Name,Competition.Images.Name FROM Competition.Sportsman  join Competition.Images  on ID_Image = idImages where Competition.Sportsman.ID = {id};";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    sportsman = new Sportsman { ID = Convert.ToInt32(res[0]), Surname = res[1].ToString(), Name = res[2].ToString(), Image = res[3].ToString() };
                }
                res.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return sportsman;
        }

        public static List<Command> GetCommands()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            List<Command> commands = new List<Command>();

            try
            {
                string sql = "SELECT idCommand, Competition.Command.Name, Count,Image,Competition.City.Name FROM Competition.Command  join Competition.City  on ID_city = idCity;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    commands.Add(new Command { ID = Convert.ToInt32(res[0]), Name = res[1].ToString(), Count = Convert.ToInt32(res[2]),  Image = res[3].ToString(), City = res[4].ToString() });
                }
                res.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return commands;
        }

        public static void AddCommand(Command command)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO `Competition`.`Command` (`Name`, `Count`, `Image`,'ID_city') SELECT '{command.Name}', {command.Count}, '{command.Image}', idCity  FROM Competition.City where '{command.City}' = Competition.City.Name", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }

        public static void RemoveCommand(int id)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"DELETE from Competition.Command WHERE (idCommand = '{id}')", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }

        public static void RemoveSportsman(string name)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"DELETE from Competition.Sportsman WHERE (Name = '{name}')", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }

        public static void AddSportsman(Sportsman sportsman)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO `Competition`.`Sportsman` (`Surname`, `Name`, `ID_Image`) SELECT '{sportsman.Surname}', '{sportsman.Name}', idImages  FROM Competition.Images where '{sportsman.Image}' = Competition.Images.Name", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }

        public static void AddUser(User user)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO `Competition`.`User` (`Email`, `Password`, `Year`) Values ('{user.Email}','{user.Password}', {user.Year})", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();

        }

        public static void UpdateSportsman(Sportsman sportsman)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"update Competition.Sportsman set Surname='{sportsman.Surname}',Name='{sportsman.Name}' where ID = {sportsman.ID};", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }
    }
}
