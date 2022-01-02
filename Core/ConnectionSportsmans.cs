using Dapper;
using Final_Project_ASP_MVC.Core;
using Final_Project_ASP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Core
{
    public class ConnectionSportsmans
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["Competition"].ConnectionString;
        private static IDbConnection connection = new SqlConnection(connStr);

        public static List<Sportsman> GetSportsmans()
        {
            try
            {
                return connection.Query<Sportsman>("SELECT ID,Surname,Sportsman.Name,Images.Name, Title.Name, Height,Cost, Command.Name FROM Sportsman join Images  on ID_Image = idImages join Title on Title.idTitle = Sportsman.idTitle join Command on Command.idCommand = Sportsman.idCommand;").AsList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Sportsman GetSportsmansId(int id)
        {
            try
            {
                //return new Sportsman();
                return connection.Query<Sportsman>($"SELECT ID,Surname,Sportsman.Name,Images.Name,Title.Name,Height,Cost, Command.Name FROM Sportsman join Images on ID_Image = idImages join Title on Title.idTitle = Sportsman.idTitle join Command on Command.idCommand = Sportsman.idCommand where Sportsman.ID = {id};").AsList().FirstOrDefault();
            }


            catch
            {
                return null;
            }
        }

        public static void RemoveSportsman(int id)
        {
            //conn = new MySqlConnection(connStr);
            //conn.Open();
            //try
            //{
            //    MySqlCommand cmd = new MySqlCommand($"DELETE from Competition.Sportsman WHERE (ID = '{id}')", conn);
            //    cmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //conn.Close();
        }

        public static void AddSportsman(Sportsman sportsman)
        {
            //conn = new MySqlConnection(connStr);
            //conn.Open();
            //try
            //{
            //    MySqlCommand cmd = new MySqlCommand($"INSERT INTO `Competition`.`Sportsman`(surname,Competition.Sportsman.Name,ID_Image,idTitle,Cost,Height, idCommand) values('{sportsman.Surname}', '{sportsman.Name}', (select Competition.Images.idImages FROM Competition.Images where '{sportsman.Image}' = Competition.Images.Name), (select Competition.Title.idTitle FROM Competition.Title where '{sportsman.Title}' = Competition.Title.Name),{sportsman.Cost}, {sportsman.Height}, (select Competition.Command.idCommand from Competition.Command where Competition.Command.Name = '{sportsman.Command}'));", conn);
            //    cmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //conn.Close();
        }

        public static void UpdateSportsman(Sportsman sportsman)
        {
            //conn = new MySqlConnection(connStr);
            //conn.Open();
            //try
            //{
            //    MySqlCommand cmd = new MySqlCommand($"update Competition.Sportsman set Competition.Sportsman.Surname='{sportsman.Surname}',Competition.Sportsman.Name='{sportsman.Name}', Competition.Sportsman.ID_Image = (select idImages  from Competition.Images where '{sportsman.Image}' = Competition.Images.Name), Competition.Sportsman.idTitle = (select idTitle from Competition.Title where '{sportsman.Title}' = Competition.Title.Name), Competition.Sportsman.Height = {sportsman.Height}, Competition.Sportsman.Cost = {sportsman.Cost},Competition.Sportsman.idCommand =(select Competition.Command.idCommand from Competition.Command where Competition.Command.Name = '{sportsman.Command}') where ID = {sportsman.ID};", conn);
            //    cmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //conn.Close();
        }
    }
}
