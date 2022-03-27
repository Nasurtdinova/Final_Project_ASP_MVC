
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CoreFramework
{
    public class ConnectionCompetitions
    {
        //public static List<Competition> compet { get; set; }
        public static Competition GetCompetId(int id)
        {
            ObservableCollection<Competition> commands = GetCompetitions();
            return commands.Where(tt => tt.idCompetition == id).FirstOrDefault();            
        }

        public static ObservableCollection<Competition> GetCompetitions()
        {
            return new ObservableCollection<Competition>(bdConnection.connection.Competition.ToList());
        }

        public static void AddCompetition(Competition compet)
        {
            try
            {
                //List<City> city = new List<City>(bdConnection.connection.City);
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
                //var cit = bdConnection.connection.City.SingleOrDefault(r => r.Name == compet.City.Name);
                competition.City = compet.City;
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
