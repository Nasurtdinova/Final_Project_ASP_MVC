
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
        public static List<Command> Commands { get; set; }
        public static List<Competition> Compets { get; set; }
        public static List<City> Cities { get; set; }
        public static List<Users> Users { get; set; }
        private static List<string> images;
        private static List<string> cities;
        private static List<string> titles;
        private static List<string> commands { get; set; }
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
            var type = Users.Where(tt => tt.Email == email && tt.Password == password).FirstOrDefault();
            return type.idUser;
        }

        public static bool GetIdType(string email, string password)
        {
            if (Users.Where(tt => tt.Email == email && tt.Password == password).FirstOrDefault().idType == 1)
                return true;
            else
                return false;
        }

        public static void GetUser(int idUser)
        {
            Name = Users.Where(tt => tt.idUser == idUser).FirstOrDefault().Name;
            Surname = Users.Where(tt => tt.idUser == idUser).FirstOrDefault().Surname;
        }

        public static List<Users> GetUser()
        {
            return Users = new List<Users>(bdConnection.connection.Users.ToList());
        }
        public static List<City> GetCities()
        {
            return Cities = new List<City>(bdConnection.connection.City.ToList());
        }

        public static List<Command> GetCommand()
        {
            return Commands = new List<Command>(bdConnection.connection.Command.ToList());
        }

        public static List<Competition> GetCompetition()
        {
            return Compets = new List<Competition>(bdConnection.connection.Competition.ToList());
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

        public static List<string> GetNameCities()
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

        public static int IsLogin(string email, string password)
        {
            Users = GetUser();
            var admin = from usrs in Users
                          where email == usrs.Email && password == usrs.Password && usrs.idType == 1
                          select usrs;

            var sponsor = from usrs in Users
                       where email == usrs.Email && password== usrs.Password && usrs.idType == 2
                       select usrs;

            var trainer = from usrs in Users
                          where email == usrs.Email && password== usrs.Password && usrs.idType == 3
                          select usrs;

            if (sponsor.Count() == 1)
            {
                CurrentUser.user = sponsor.FirstOrDefault();
                return 2;
            }
            else if (trainer.Count() == 1)
            {
                CurrentUser.user = trainer.FirstOrDefault();
                return 3;
            }
            else if (admin.Count() == 1)
            {
                CurrentUser.user = admin.FirstOrDefault();
                return 1;
            }
            else
            {
                return 0;
            }
        }       
    }
}
