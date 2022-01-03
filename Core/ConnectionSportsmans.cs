using Dapper;
using Final_Project_ASP_MVC.Core;
using Final_Project_ASP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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
                return connection.Query<Sportsman>("SELECT ID,Surname,Sportsman.Name, Images.Name, Title.Name,Height,Cost,Command.Name FROM Sportsman join Images  on ID_Image = idImages join Title on Title.idTitle = Sportsman.idTitle join Command on Command.idCommand = Sportsman.idCommand;").AsList();
            }
            catch
            {
                return null;
            }
        }

        public static Sportsman GetSportsmansId(int id)
        {
            try
            {
                //return new Sportsman();
                return connection.Query<Sportsman>($"SELECT ID,Surname,Sportsman.Name, Images.Name, Title.Name,Height,Cost,Command.Name FROM Sportsman join Images on ID_Image = idImages join Title on Title.idTitle = Sportsman.idTitle join Command on Command.idCommand = Sportsman.idCommand where Sportsman.ID = {id};").AsList().FirstOrDefault();
            }

            catch
            {
                return null;
            }
        }

        public static void RemoveSportsman(int id)
        {
            try
            {
                connection.Query($"DELETE from Competition.Sportsman WHERE (ID = '{id}')");
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
                connection.Query($"INSERT INTO Sportsman(surname,Sportsman.Name,ID_Image,idTitle,Cost,Height, idCommand) values('{sportsman.Surname}', '{sportsman.Name}', (select Competition.Images.idImages FROM Competition.Images where '{sportsman.Image}' = Competition.Images.Name), (select Competition.Title.idTitle FROM Competition.Title where '{sportsman.Title}' = Competition.Title.Name),{sportsman.Cost}, {sportsman.Height}, (select Competition.Command.idCommand from Competition.Command where Competition.Command.Name = '{sportsman.Command}'));");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateSportsman(Sportsman sportsman)
        {
            try
            {
                connection.Query($"update Sportsman set Sportsman.Surname='{sportsman.Surname}',Sportsman.Name='{sportsman.Name}', Sportsman.ID_Image = (select idImages  from Images where '{sportsman.Image}' = Images.Name), Sportsman.idTitle = (select idTitle from Title where '{sportsman.Title}' = Title.Name), Sportsman.Height = {sportsman.Height}, Sportsman.Cost = {sportsman.Cost},Sportsman.idCommand =(select Command.idCommand from Command where Command.Name = '{sportsman.Command}') where ID = {sportsman.ID};");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
