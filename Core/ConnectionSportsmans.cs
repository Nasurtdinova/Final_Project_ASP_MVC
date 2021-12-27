using Final_Project_ASP_MVC.Core;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Core
{
    public class ConnectionSportsmans
    {
        public static string connStr = ConfigurationManager.AppSettings["connection"].ToString();
        public static MySqlConnection conn;

        public static List<Sportsman> GetSportsmans()
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            List<Sportsman> sportsmans = new List<Sportsman>();

            try
            {
                string sql = "SELECT ID,Surname,Competition.Sportsman.Name,Competition.Images.Name, Competition.Title.Name,Height,Cost, Competition.Command.Name " +
                    "FROM Competition.Sportsman  " +
                    "join Competition.Images  on ID_Image = idImages " +
                    "join Competition.Title on Competition.Title.idTitle = Competition.Sportsman.idTitle join Competition.Command on Competition.Command.idCommand = Competition.Sportsman.idCommand;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    sportsmans.Add(new Sportsman
                    {
                        ID = Convert.ToInt32(res[0]),
                        Surname = res[1].ToString(),
                        Name = res[2].ToString(),
                        Image = res[3].ToString(),
                        Title = res[4].ToString(),
                        Height = Convert.ToInt32(res[5]),
                        Cost = Convert.ToInt32(res[6]),
                        Command = res[7].ToString()
                    });
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
            conn = new MySqlConnection(connStr);
            conn.Open();
            Sportsman sportsman = null;
            try
            {
                string sql = $"SELECT ID,Surname,Competition.Sportsman.Name,Competition.Images.Name, Competition.Title.Name,Height,Cost, Competition.Command.Name FROM Competition.Sportsman join Competition.Images on ID_Image = idImages join Competition.Title on Competition.Title.idTitle = Competition.Sportsman.idTitle join Competition.Command on Competition.Command.idCommand = Competition.Sportsman.idCommand where Competition.Sportsman.ID = {id};";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    sportsman = new Sportsman
                    {
                        ID = Convert.ToInt32(res[0]),
                        Surname = res[1].ToString(),
                        Name = res[2].ToString(),
                        Image = res[3].ToString(),
                        Title = res[4].ToString(),
                        Height = Convert.ToInt32(res[5]),
                        Cost = Convert.ToInt32(res[6]),
                        Command = res[7].ToString()
                    };
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

        public static void RemoveSportsman(int id)
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"DELETE from Competition.Sportsman WHERE (ID = '{id}')", conn);
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
            conn = new MySqlConnection(connStr);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO `Competition`.`Sportsman`(surname,Competition.Sportsman.Name,ID_Image,idTitle,Cost,Height, idCommand) values('{sportsman.Surname}', '{sportsman.Name}', (select Competition.Images.idImages FROM Competition.Images where '{sportsman.Image}' = Competition.Images.Name), (select Competition.Title.idTitle FROM Competition.Title where '{sportsman.Title}' = Competition.Title.Name),{sportsman.Cost}, {sportsman.Height}, (select Competition.Command.idCommand from Competition.Command where Competition.Command.Name = '{sportsman.Command}'));", conn);
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
            conn = new MySqlConnection(connStr);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"update Competition.Sportsman set Competition.Sportsman.Surname='{sportsman.Surname}',Competition.Sportsman.Name='{sportsman.Name}', Competition.Sportsman.ID_Image = (select idImages  from Competition.Images where '{sportsman.Image}' = Competition.Images.Name), Competition.Sportsman.idTitle = (select idTitle from Competition.Title where '{sportsman.Title}' = Competition.Title.Name), Competition.Sportsman.Height = {sportsman.Height}, Competition.Sportsman.Cost = {sportsman.Cost},Competition.Sportsman.idCommand =(select Competition.Command.idCommand from Competition.Command where Competition.Command.Name = '{sportsman.Command}') where ID = {sportsman.ID};", conn);
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
