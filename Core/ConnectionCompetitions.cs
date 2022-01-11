using Dapper;
using Final_Project_ASP_MVC.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Core
{
    public class ConnectionCompetitions
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["Competition"].ConnectionString;
        private static IDbConnection connection = new SqlConnection(connStr);

        public static Competition GetCompetId(int id)
        {
            Competition compet = null;
            try
            {
                compet = new Competition
                {
                    ID = connection.Query<int>($"SELECT idCompetition FROM Competition join City on Competition.idCity = City.idCity where idCompetition ={id};").AsList().FirstOrDefault(),
                    Name = connection.Query<string>($"SELECT Competition.Name FROM Competition join City on Competition.idCity = City.idCity where idCompetition ={id};").AsList().FirstOrDefault(),
                    NameVenue = connection.Query<string>($"SELECT NameVenue FROM Competition join City on Competition.idCity = City.idCity where idCompetition ={id};").AsList().FirstOrDefault(),
                    Street = connection.Query<string>($"SELECT Street FROM Competition join City on Competition.idCity = City.idCity where idCompetition ={id};").AsList().FirstOrDefault(),
                    Home = connection.Query<int>($"SELECT Home FROM Competition join City on Competition.idCity = City.idCity where idCompetition ={id};").AsList().FirstOrDefault(),
                    Date = connection.Query<DateTime>($"SELECT Date FROM Competition join City on Competition.idCity = City.idCity where idCompetition ={id};").AsList().FirstOrDefault(),
                    City = connection.Query<string>($"SELECT City.Name FROM Competition join City on Competition.idCity = City.idCity where idCompetition ={id};").AsList().FirstOrDefault()
                };
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return compet;
        }

        public static List<Competition> GetCompetition()
        {
            List<Competition> competition = new List<Competition>();

            try
            {
                for (int i = 0; i < connection.Query<int>($"SELECT * FROM Competition;").Count(); i++)
                {
                    competition.Add(new Competition
                    {
                        ID = connection.Query<int>("select idCompetition from Competition join City on Competition.idCity = City.idCity;").AsList()[i],
                        Name = connection.Query<string>("select Competition.Name from Competition join City on Competition.idCity = City.idCity;").AsList()[i],
                        NameVenue = connection.Query<string>("select NameVenue from Competition join City on Competition.idCity = City.idCity;").AsList()[i],
                        Street = connection.Query<string>("select Street from Competition join City on Competition.idCity = City.idCity;").AsList()[i],
                        City = connection.Query<string>("select City.Name from Competition join City on Competition.idCity = City.idCity;").AsList()[i],
                        Home = connection.Query<int>("select Home from Competition join City on Competition.idCity = City.idCity;").AsList()[i],
                        Date = connection.Query<DateTime>("select Date from Competition join City on Competition.idCity = City.idCity;").AsList()[i]
                    });
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return competition;
        }

        public static void AddCompetition(Competition compet)
        {
            try
            {
                connection.Query($"INSERT INTO Competition (Name, NameVenue, Street,Home,Date,idCity) SELECT '{compet.Name}', '{compet.NameVenue}', '{compet.Street}', {compet.Home}, '{compet.Date.ToString("yyyy-MM-dd hh:mm:ss")}', idCity FROM City where '{compet.City}' = City.Name;");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void RemoveCompetition(int id)
        {
            try
            {
                connection.Query($"DELETE from Competition WHERE (idCompetition = '{id}')");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateCompet(Competition compet)
        {
            try
            {
                connection.Query($"update Competition set Competition.Name ='{compet.Name}',NameVenue='{compet.NameVenue}',Street='{compet.Street}', Home={compet.Home},idCity = (select idCity from City where City.Name = '{compet.City}'), Competition.Date ='{compet.Date.ToString("dd.MM.yyyy hh:mm:ss")}' where idCompetition = {compet.ID};");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
