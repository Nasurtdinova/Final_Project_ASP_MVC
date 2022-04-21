using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

namespace CoreFramework
{
    public class ConnectionCompetitions
    {
        public static Competition GetCompetId(int id)
        {
            ObservableCollection<Competition> commands = GetCompetitions();
            return commands.Where(tt => tt.idCompetition == id).FirstOrDefault();            
        }

        public static ObservableCollection<Competition> GetCompetitions()
        {
           return new ObservableCollection<Competition>(bdConnection.connection.Competition.ToList().Where(a => a.IsDeleted == false));
        }

        public static void AddCompetition(Competition compet)
        {
            try
            {
                compet.IsDeleted = false;

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
                compet.IsDeleted = true;
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

                competition.City = Connection.GetCity(compet.City.Name);
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
