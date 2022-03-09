
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CoreFramework
{
    public class Connection
    {
        public static List<Competition> compet { get; set; }
        public static List<Users> user { get; set; }
        private static List<string> images;
        private static List<string> cities;
        private static List<string> titles;
        private static List<string> commands;
        private static List<string> competitions;

        public static int IdUser { get; set; }
        public static string Name { get; set; }
        public static string Surname { get; set; }

        public Connection(string login, string password)
        {
            IdUser = GetIdUser(login, password);
            GetUser(IdUser);
        }

        public static int GetIdUser(string email, string password)
        {
            var type = user.Where(tt => tt.Email == email && tt.Password == password).FirstOrDefault();
            return type.idUser;
        }

        public static bool GetIdType(string email, string password)
        {
            if (user.Where(tt => tt.Email == email && tt.Password == password).FirstOrDefault().idType == 1)
                return true;
            else
                return false;
        }

        public static void GetUser(int idUser)
        {
            Name = user.Where(tt => tt.idUser == idUser).FirstOrDefault().Name;
            Surname = user.Where(tt => tt.idUser == idUser).FirstOrDefault().Surname;
        }

        public static List<Users> GetUser()
        {
            return user = new List<Users>(bdConnection.connection.Users.ToList());
        }

        public static void AddUser(Users user)
        {
            try
            {
                bdConnection.connection.Users.Add(user);
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static List<string> GetImages()
        {
            List<Images> imgs = new List<Images>(bdConnection.connection.Images.ToList());
            images = new List<string>();
            foreach (var i in imgs)
            {
                images.Add(i.Name);
            }
            return images;          
        }

        public static List<string> GetTitles()
        {
            List<Title> tits = new List<Title>(bdConnection.connection.Title.ToList());
            titles = new List<string>();
            foreach (var i in tits)
            {
                titles.Add(i.Name);
            }
            return titles;
        }

        public static List<string> GetNameCommands()
        {
            List<Command> coms = new List<Command>(bdConnection.connection.Command.ToList());
            commands = new List<string>();
            foreach (var i in coms)
            {
                commands.Add(i.Name);
            }
            return commands;
        }

        public static List<string> GetNameCompets()
        {
            List<Competition> compets = new List<Competition>(bdConnection.connection.Competition.ToList());
            competitions = new List<string>();
            foreach (var i in compets)
            {
                competitions.Add(i.Name);
            }
            return competitions;
        }

        public static List<string> GetCities()
        {
            List<City> city = new List<City>(bdConnection.connection.City.ToList());
            cities = new List<string>();
            foreach(var i in city)
            {
                cities.Add(i.Name);
            }
            return cities;
        }

        public static string GetCitiesId(int id)
        {
            List<City> city = new List<City>(bdConnection.connection.City.ToList());
            var cities = city.Where(t => t.idCity == id).FirstOrDefault();
            return cities.Name;
        }

        public static bool IsLogin(string email, string password)
        {
            user = GetUser();
            if (user.Where(tt => tt.Email == email && tt.Password == password).FirstOrDefault().Email != null
            && user.Where(tt => tt.Email == email && tt.Password == password).FirstOrDefault().Password != null)
            {
                return true;
            }
            else
            {
                return false;
            }             
        }       
    }
}
