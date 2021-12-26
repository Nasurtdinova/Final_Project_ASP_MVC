using Final_Project_ASP_MVC.Core;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Core
{
    public class ConnectionCommands
    {
        public static string connStr = ConfigurationManager.AppSettings["connection"].ToString();
        public static MySqlConnection conn;
        public static List<Sportsman> sporCom;

        public static List<Sportsman> GetSporCom(int id)
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            sporCom = new List<Sportsman>();
            try
            {
                string sql = $"select * from Competition.Sportsman where idCommand = {id};";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    sporCom.Add(new Sportsman { ID = Convert.ToInt32(res[0]), Surname = res[1].ToString(), Name = res[2].ToString() });
                }
                res.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return sporCom;
        }

        public static List<Command> GetCommands()
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            List<Command> commands = new List<Command>();

            try
            {
                string sql = "SELECT idCommand, Competition.Command.Name, Count,Image,Competition.City.Name FROM Competition.Command  join Competition.City  on ID_city = idCity;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    commands.Add(new Command { ID = Convert.ToInt32(res[0]), Name = res[1].ToString(), Count = Convert.ToInt32(res[2]), Image = res[3].ToString(), City = res[4].ToString() });
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
            conn = new MySqlConnection(connStr);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO `Competition`.`Command` (`Name`, `Count`, `Image`,ID_city) SELECT '{command.Name}', {command.Count}, '{command.Image}', idCity  FROM Competition.City where '{command.City}' = Competition.City.Name;", conn);
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
            conn = new MySqlConnection(connStr);
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

        public static void UpdateCommand(Command command)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"update Competition.Command set Name='{command.Name}',Count={command.Count},Image='{command.Image}', ID_city = (select Competition.City.idCity from Competition.City where Competition.City.Name = '{command.City}') where idCommand = {command.ID};", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }

        public static Command GetCommandsId(int id)
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            Command command = null;
            try
            {
                string sql = $"SELECT idCommand,Competition.Command.Name,Count,Image, Competition.City.Name FROM Competition.Command  join Competition.City  on ID_city = idCity where Competition.Command.idCommand = {id};";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    command = new Command { ID = Convert.ToInt32(res[0]), Name = res[1].ToString(), Count = Convert.ToInt32(res[2]), Image = res[3].ToString(), City = res[4].ToString() };
                }
                res.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return command;
        }
    }
}
