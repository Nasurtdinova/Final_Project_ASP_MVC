using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CoreFramework
{
    public class ConnectionUser
    {
        public static List<City> Cities { get; set; }
        public static List<Users> Users { get; set; }
        public static List<Title> Titles { get; set; }

        public static bool IsCorrectPassword(string password)
        {
            bool isLetter = false;
            bool isDigit = false;
            bool isSymbol = false;
            char[] chars = { '!', '@', '#', '$', '%', '^' };

            foreach (var i in password)
            {
                if (Char.IsLetter(i))
                    isLetter = true;
                if (Char.IsNumber(i))
                    isDigit = true;
                if (chars.Contains(i))
                    isSymbol = true;
            }

            if (isLetter && isDigit && isSymbol)
                return true;
            else
                return false;
        }

        public static Users GetUser(string email, string password)
        {
            return GetUsers().Where(tt => tt.Email == email && tt.Password == password).FirstOrDefault();
        }

        public static List<Users> GetUsers()
        {
            return new List<Users>(bdConnection.connection.Users.ToList());
        }

        public static bool IsCoinsLogin(string login)
        {
            List<Users> users = GetUsers();
            if (users.Where(a => a.Email == login).ToList().Count != 0)
                return true;
            else
                return false;
        }

        public static List<City> GetCities()
        {
            return new List<City>(bdConnection.connection.City.ToList());
        }

        public static List<Title> GetTitles()
        {
            return new List<Title>(bdConnection.connection.Title.ToList());
        }

        public static List<Sponsor> GetSponsors()
        {
            return new List<Sponsor>(bdConnection.connection.Sponsor.ToList());
        }

        public static Sponsor GetSponsor(int idUser)
        {
            return GetSponsors().Where(t => t.idUser == idUser).FirstOrDefault();
        }

        public static void AddUser(Users user)
        {
            try
            {
                bdConnection.connection.Users.Add(user);
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AddSponsor(Sponsor sponsor)
        {
            try
            {
                bdConnection.connection.Sponsor.Add(sponsor);
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static Title GetTitle(int id)
        {
            return GetTitles().Where(a => a.idTitle == id).FirstOrDefault();
        }

        public static City GetCity(string name)
        {
            return GetCities().Where(a=> a.Name == name).FirstOrDefault();
        }

        public static string GetCitiesId(int id)
        {
            return GetCities().Where(t => t.idCity == id).FirstOrDefault().Name;
        }

        public static int IsCorrectUser(string email, string password)
        {
            Users = GetUsers();
            var admin = from usrs in Users
                          where email == usrs.Email && password == usrs.Password && usrs.idType == 1
                          select usrs;

            var sponsor = from usrs in Users
                       where email == usrs.Email && password== usrs.Password && usrs.idType == 2
                       select usrs;

            if (sponsor.Count() == 1)
            {
                CurrentUser.user = sponsor.FirstOrDefault();
                CurrentUser.spon = ConnectionUser.GetSponsors().Where(a => a.idUser == CurrentUser.user.idUser).FirstOrDefault();
                return 2;
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
