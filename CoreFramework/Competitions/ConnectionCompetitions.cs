
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

//лишние библиотеки убрать
namespace CoreFramework
{
    public class ConnectionCompetitions //разнести классы по папочкам
    {
        //public static List<Competition> compet { get; set; }
        public static Competition GetCompetId(int id)
        {
            List<Competition> compets = GetCompetition();
            var com = compets.Where(tt => tt.idCompetition == id).FirstOrDefault();
            Competition compet = new Competition
            {
                idCompetition = id,
                Name = com.Name,
                Date = com.Date,
                Home = com.Home,
                //CityName = com.City.Name,
                //idCity = com.City.idCity,
                NameVenue = com.NameVenue,
                Street = com.Street
            };
            return compet;
        }

        public static List<Competition> GetCompetition()
        {
            List<Competition> compet = new List<Competition>(bdConnection.connection.Competition.ToList());
            return compet;
        }

        public static void AddCompetition(Competition compet)
        {
            try
            {
                List<City> city = new List<City>(bdConnection.connection.City);
                //var type = city.Where(tt => tt.Name == compet.CityName).FirstOrDefault();
                //compet.idCity = type.idCity;
                bdConnection.connection.Competition.Add(compet);
                bdConnection.connection.SaveChanges();
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
                Competition compet = bdConnection.connection.Competition.FirstOrDefault(p => p.idCompetition == id);
                bdConnection.connection.Competition.Remove(compet);
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateCompet(Competition compet)
        {
            try
            {
                var competition = bdConnection.connection.Competition.SingleOrDefault(r => r.idCompetition == compet.idCompetition);
                competition.Name = compet.Name;
                competition.NameVenue = compet.NameVenue;
                competition.Date = compet.Date;
                //var cit = bdConnection.connection.City.SingleOrDefault(r => r.Name == compet.CityName);
                //competition.idCity = cit.idCity;
                competition.Home = compet.Home;
                competition.Street = compet.Street;
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
