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
    public class ConnectionSportsmans //разнести классы по папочкам
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["Competition"].ConnectionString;
        private static IDbConnection connection = new SqlConnection(connStr);

        public static ObservableCollection<Sportsmans> GetSportsmans()
        {
            ObservableCollection<Sportsmans> sportsman = new ObservableCollection<Sportsmans>();
            try
            {
                List<Sportsmans> list = connection.Query<Sportsmans>("select * from Sportsman").AsList();
                foreach (var i in list)
                {
                    i.Image = Connection.GetNameImage(i.ID_Image);
                    i.Command = Connection.GetNameCommand(i.idCommand);
                    i.Title = Connection.GetNameTitle(i.idTitle);
                }
                sportsman = new ObservableCollection<Sportsmans>(list);
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }

            return sportsman;
        }

        public static Sportsmans GetSportsmansId(int id)
        {
            Sportsmans sportsman = null;

            try
            {
                ObservableCollection<Sportsmans> sportsmans = GetSportsmans();
                sportsman =  sportsmans.Where(t => t.ID == id).FirstOrDefault();
            }

            catch // Exception исправить
            { 
                return null; 
            }

            return sportsman;
        }

        public static void RemoveSportsman(int id)
        {
            try
            {
                connection.Query($"DELETE from Sportsman WHERE (ID = '{id}')");
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AddSportsman(Sportsman sportsman)
        {
            try
            {
                connection.Query($"INSERT Sportsman values('{sportsman.Surname}', '{sportsman.Name}', {Connection.GetIdImage(sportsman.Image)}," +
                    $"{Connection.GetIdTitle(sportsman.Title)},{sportsman.Cost}, {sportsman.Height}, {Connection.GetIdCommand(sportsman.Command)});");
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateSportsman(Sportsman sportsman)
        {
            try
            {
                connection.Query($"update Sportsman set Sportsman.Surname='{sportsman.Surname}',Sportsman.Name='{sportsman.Name}', " +
                    $"Sportsman.ID_Image = {Connection.GetIdImage(sportsman.Image)}, Sportsman.idTitle = {Connection.GetIdTitle(sportsman.Title)}, " +
                    $"Sportsman.Height = {sportsman.Height}, Sportsman.Cost = {sportsman.Cost},Sportsman.idCommand ={Connection.GetIdCommand(sportsman.Command)} " +
                    $"where ID = {sportsman.ID};");
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
