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
        public static MySqlConnection conn = new MySqlConnection(connStr);
        public static List<string> images;

        static Connection()
        {
            conn.Open();
        }

        public static List<string> GetImages()
        {
            images = new List<string>();
            string sql = "SELECT Name FROM Images";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader img = cmd.ExecuteReader();

            while (img.Read())
            {
                images.Add(img[0].ToString());
            }
            img.Close();

            return images;         
        }

        //public static string GetPath()
        //{
        //    string sql = "SELECT Name FROM Images";
        //    MySqlCommand cmd = new MySqlCommand(sql, conn);
        //    MySqlDataReader img = cmd.ExecuteReader();

        //    while (img.Read())
        //    {
        //        images.Add(img[0].ToString());
        //    }
        //    img.Close();

        //    return images;
        //}

        public static List<Sportsman> GetSportsmans()
        {
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

            return sportsmans;
        }

        public static List<Command> GetCommands()
        {
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

            return commands;
        }

        public static void RemoveSportsman(string name)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand($"DELETE from Competition.Sportsman WHERE (Name = '{name}')", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AddSportsman(Sportsman sportsman)
        {         
            try
            {
                //string sql = $"SELECT idImages  FROM Competition.Sportsman  join Competition.Images  on ID_Image = idImages where  '{sportsman.Image}' = Competition.Images.Name;";
                //MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                //MySqlDataReader res = cmd1.ExecuteReader();
                //while (res.Read())
                //{
                    MySqlCommand cmd = new MySqlCommand($"INSERT INTO `Competition`.`Sportsman` (`Surname`, `Name`, `ID_Image`) SELECT '{sportsman.Surname}', '{sportsman.Name}', idImages  FROM Competition.Sportsman  join Competition.Images  on ID_Image = idImages where  '{sportsman.Image}' = Competition.Images.Name", conn);
                    cmd.ExecuteNonQuery();
                //}
                //res.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
