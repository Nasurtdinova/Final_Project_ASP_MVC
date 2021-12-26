
using Core;
using Final_Project_ASP_MVC.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_ASP_MVC.Core
{
    public class Connection
    {
        public static string connStr = ConfigurationManager.AppSettings["connection"].ToString();
        public static MySqlConnection conn;
        public static List<string> images;
        public static List<string> cities;
        public static List<string> titles;
        public static List<string> commands;
        public static List<string> competitions;

        public static List<Sportsman> sporCom;
        public static int idUser { get; set; }
        public static string Name { get; set; }
        public static string Surname { get; set; }

        public Connection(string login, string password)
        {
            idUser = GetIdUser(login, password);
            GetUser(idUser);
        }

        public static int GetIdUser(string email, string password)
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = $"SELECT idUser FROM Competition.User where '{email}' = Email and '{password}' = Password;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader res = cmd.ExecuteReader();
            while (res.Read())
            {
                return Convert.ToInt32(res[0]);
            }
            res.Close();
            conn.Close();
            return Convert.ToInt32(res[0]);          
        }

        public static void GetUser(int idUser)
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = $"SELECT Name, Surname FROM Competition.User where '{idUser}' = idUser;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader res = cmd.ExecuteReader();
            while (res.Read())
            {
                Name = res[0].ToString();
                Surname = res[1].ToString();
            }
            res.Close();
            conn.Close();

        }

        public static List<string> GetImages()
        {
            conn.Open();
            images = new List<string>();
            string sql = "SELECT Name FROM Images";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader img = cmd.ExecuteReader();

            while (img.Read())
            {
                images.Add(img[0].ToString());
            }
            img.Close();
            conn.Close();
            return images;          
        }

        public static List<string> GetTitles()
        {
            conn.Open();
            titles = new List<string>();
            string sql = "SELECT Name FROM Title";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader tit = cmd.ExecuteReader();

            while (tit.Read())
            {
                titles.Add(tit[0].ToString());
            }
            tit.Close();
            conn.Close();
            return titles;
        }

        public static List<string> GetNameCommands()
        {
            conn.Open();
            commands = new List<string>();
            string sql = "SELECT Name FROM Command";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader com = cmd.ExecuteReader();

            while (com.Read())
            {
                commands.Add(com[0].ToString());
            }
            com.Close();
            conn.Close();
            return commands;
        }

        public static List<string> GetNameCompets()
        {
            conn.Open();
            competitions = new List<string>();
            string sql = "SELECT Name FROM Competition.Competition";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader com = cmd.ExecuteReader();

            while (com.Read())
            {
                competitions.Add(com[0].ToString());
            }
            com.Close();
            conn.Close();
            return competitions;
        }

        public static List<string> GetCities()
        {
            conn.Open();
            cities = new List<string>();
            string sql = "SELECT Name FROM City";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader city = cmd.ExecuteReader();

            while (city.Read())
            {
                cities.Add(city[0].ToString());
            }
            city.Close();
            conn.Close();
            return cities;
        }

        public static bool IsLogin(string email, string password)
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = $"SELECT Email,Password FROM Competition.User where '{email}' = Email and '{password}' = Password;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader res = cmd.ExecuteReader();
            while (res.Read())
            {
                if (res[0].ToString() == email && res[1].ToString() == password)
                {
                    
                    return true;
                }
                else
                {
                    return false;
                }
                
            }           
            res.Close();
            conn.Close();
            return false;
        }
        public static List<Sportsman> GetSportsmans()
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            List<Sportsman> sportsmans = new List<Sportsman>();

            try
            {
                string sql = "SELECT ID,Surname,Competition.Sportsman.Name,Competition.Images.Name, Competition.Title.Name,Height,Cost, Competition.Command.Name " +
                    "FROM Competition.Sportsman  " +
                    "join Competition.Images  on ID_Image = idImages " +
                    "join Competition.Title on Competition.Title.idTitle = Competition.Sportsman.idTitle join Competition.Command on Competition.Command.idCommand = Competition.Sportsman.idCommand;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    sportsmans.Add(new Sportsman { ID = Convert.ToInt32(res[0]), Surname = res[1].ToString(), 
                        Name = res[2].ToString(), Image = res[3].ToString(), Title = res[4].ToString(), 
                        Height = Convert.ToInt32(res[5]), Cost = Convert.ToInt32(res[6]), Command = res[7].ToString() });
                }
                res.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return sportsmans;
        }
        public static List<Result> GetResults()
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            List<Result> results = new List<Result>();

            try
            {
                string sql = "SELECT Competition.ResultCompetition.idResult, Competition.Command.Name, Competition.Competition.Name, Competition.ResultCompetition.Rank " +
                    "from Competition.ResultCompetition " +
                    "join Competition.Command on Competition.ResultCompetition.idCommand = Competition.Command.idCommand " +
                    "join Competition.Competition on Competition.ResultCompetition.idCompetition = Competition.Competition.idCompetition;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    results.Add(new Result { ID = Convert.ToInt32(res[0]), Command = res[1].ToString(), Compet = res[2].ToString(), Rank = Convert.ToInt32(res[3]) });
                }
                res.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return results;
        }

        public static List<Sponsorship> GetSponsorship()
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            List<Sponsorship> sponsorship = new List<Sponsorship>();

            try
            {
                string sql = $"SELECT id, Competition.User.Name, Competition.User.Surname, Competition.Command.Name, teamContract, amount from Competition.SponsorCommand join Competition.User on Competition.SponsorCommand.idSponsor = Competition.User.idUser join Competition.Command on Competition.SponsorCommand.idCom = Competition.Command.idCommand where Competition.SponsorCommand.idSponsor = {idUser}; ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    sponsorship.Add(new Sponsorship { ID = Convert.ToInt32(res[0]), SponsorName = res[1].ToString(), SponsorSurname = res[2].ToString(), Command = res[3].ToString(), teamContract = Convert.ToInt32(res[4]), Amount = Convert.ToInt32(res[5]) });
                }
                res.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return sponsorship;
        }
        public static List<Sportsman> GetSporCom(int id)
        {
            conn.Open();
            sporCom = new List<Sportsman>();
            try
            {
                string sql = $"select * from Competition.Sportsman where idCommand = {id};";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    sporCom.Add(new Sportsman { ID = Convert.ToInt32(res[0]), Surname = res[1].ToString(), Name = res[2].ToString() });
                }
                res.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return sporCom;
        }

        public static Result GetResultsId(int id)
        {
            conn.Open();
            Result results = null;

            try
            {
                string sql = $"SELECT Competition.ResultCompetition.idResult, Competition.Command.Name, Competition.Competition.Name, Competition.ResultCompetition.Rank from Competition.ResultCompetition join Competition.Command on Competition.ResultCompetition.idCommand = Competition.Command.idCommand join Competition.Competition on Competition.ResultCompetition.idCompetition = Competition.Competition.idCompetition where Competition.ResultCompetition.idResult = {id};";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    results = new Result { ID = Convert.ToInt32(res[0]), Command = res[1].ToString(), Compet = res[2].ToString(), Rank = Convert.ToInt32(res[3]) };
                }
                res.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return results;
        }

        public static Sportsman GetSportsmansId(int id)
        {
            conn.Open();
            Sportsman sportsman = null;
            try
            {
                string sql = $"SELECT ID,Surname,Competition.Sportsman.Name,Competition.Images.Name, Competition.Title.Name,Height,Cost, Competition.Command.Name FROM Competition.Sportsman join Competition.Images on ID_Image = idImages join Competition.Title on Competition.Title.idTitle = Competition.Sportsman.idTitle join Competition.Command on Competition.Command.idCommand = Competition.Sportsman.idCommand where Competition.Sportsman.ID = {id};";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    sportsman = new Sportsman { 
                        ID = Convert.ToInt32(res[0]), 
                        Surname = res[1].ToString(), 
                        Name = res[2].ToString(), 
                        Image = res[3].ToString(),
                        Title = res[4].ToString(),
                        Height = Convert.ToInt32(res[5]),
                        Cost = Convert.ToInt32(res[6]),
                        Command = res[7].ToString()
                    };
                }
                res.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return sportsman;
        }

        public static Command GetCommandsId(int id)
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            Command command = null;
            try
            {
                string sql = $"SELECT idCommand,Competition.Command.Name,Count,Image, Competition.City.Name FROM Competition.Command  join Competition.City  on ID_city = idCity where Competition.Command.idCommand = {id};";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    command = new Command { ID = Convert.ToInt32(res[0]), Name = res[1].ToString(), Count = Convert.ToInt32(res[2]),Image = res[3].ToString(), City = res[4].ToString() };
                }
                res.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return command;
        }

        public static Competition GetCompetId(int id)
        {
            conn.Open();
            Competition compet = null;
            try
            {
                string sql = $"SELECT idCompetition,Competition.Competition.Name,NameVenue,Street,Home,Date, Competition.City.Name FROM Competition.Competition  join Competition.City  on Competition.Competition.idCity = Competition.City.idCity where idCompetition ={id};";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    compet = new Competition { ID = Convert.ToInt32(res[0]), Name = res[1].ToString(), NameVenue = res[2].ToString(), Street = res[3].ToString(),Home=Convert.ToInt32(res[4]), Date=Convert.ToDateTime(res[5]), City = res[6].ToString() };
                }
                res.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return compet;
        }

        public static List<Command> GetCommands()
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            List<Command> commands = new List<Command>();

            try
            {
                string sql = "SELECT idCommand, Competition.Command.Name, Count,Image,Competition.City.Name FROM Competition.Command  join Competition.City  on ID_city = idCity;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    commands.Add(new Command { ID = Convert.ToInt32(res[0]), Name = res[1].ToString(), Count = Convert.ToInt32(res[2]),  Image = res[3].ToString(), City = res[4].ToString() });
                }
                res.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return commands;
        }

        public static List<Competition> GetCompetition()
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            List<Competition> competition = new List<Competition>();

            try
            {
                string sql = "select idCompetition, Competition.Competition.Name, NameVenue, Street, Competition.City.Name, Home,Date from Competition.Competition join Competition.City on Competition.idCity = Competition.City.idCity;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    competition.Add(new Competition { ID = Convert.ToInt32(res[0]), Name = res[1].ToString(), NameVenue = res[2].ToString(), Street = res[3].ToString(), City = res[4].ToString(), Home = Convert.ToInt32(res[5].ToString()), Date = Convert.ToDateTime(res[6].ToString()) });
                }
                res.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return competition;
        }

        public static void AddCommand(Command command)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO `Competition`.`Command` (`Name`, `Count`, `Image`,ID_city) SELECT '{command.Name}', {command.Count}, '{command.Image}', idCity  FROM Competition.City where '{command.City}' = Competition.City.Name;", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }

        public static void AddSponsorship(Sponsorship sponsorship)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO Competition.SponsorCommand (idSponsor, idCom, teamContract, amount) values ({idUser}, (select Competition.Command.idCommand from Competition.Command where Competition.Command.Name = '{sponsorship.Command}'), {sponsorship.teamContract}, {sponsorship.Amount});", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }

        public static void AddCompetition(Competition compet)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO `Competition`.`Competition` (`Name`, `NameVenue`, `Street`,Home,Date,idCity) SELECT '{compet.Name}', '{compet.NameVenue}', '{compet.Street}', {compet.Home}, '{compet.Date.ToString("yyyy-MM-dd hh:mm:ss")}', idCity  FROM Competition.City where '{compet.City}' = Competition.City.Name;", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }

        public static void RemoveCommand(int id)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"DELETE from Competition.Command WHERE (idCommand = '{id}')", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }

        public static void RemoveSponsorship(int id)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"DELETE from Competition.SponsorCommand WHERE (Competition.SponsorCommand.id = '{id}')", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }

        public static void RemoveSportsman(int id)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"DELETE from Competition.Sportsman WHERE (ID = '{id}')", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }

        public static void RemoveCompetition(int id)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"DELETE from Competition.Competition WHERE (idCompetition = '{id}')", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }

        public static void RemoveResult(int id)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"DELETE from Competition.ResultCompetition WHERE (idResult = {id});", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }

        public static void AddSportsman(Sportsman sportsman)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO `Competition`.`Sportsman`(surname,Competition.Sportsman.Name,ID_Image,idTitle,Cost,Height, idCommand) values('{sportsman.Surname}', '{sportsman.Name}', (select Competition.Images.idImages FROM Competition.Images where '{sportsman.Image}' = Competition.Images.Name), (select Competition.Title.idTitle FROM Competition.Title where '{sportsman.Title}' = Competition.Title.Name),{sportsman.Cost}, {sportsman.Height}, (select Competition.Command.idCommand from Competition.Command where Competition.Command.Name = '{sportsman.Command}'));", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }

        public static void AddResult(Result result)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO Competition.ResultCompetition (idCommand, idCompetition, Competition.ResultCompetition.Rank) values ((select Competition.Command.idCommand from Competition.Command where Competition.Command.Name = '{result.Command}'), (select Competition.Competition.idCompetition from Competition.Competition where Competition.Competition.Name = '{result.Compet}'), {result.Rank});", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }

        public static void AddUser(User user)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO `Competition`.`User` (`Email`, `Password`, `Year`) Values ('{user.Email}','{user.Password}', {user.Year})", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }

        public static void UpdateSportsman(Sportsman sportsman)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"update Competition.Sportsman set Competition.Sportsman.Surname='{sportsman.Surname}',Competition.Sportsman.Name='{sportsman.Name}', Competition.Sportsman.ID_Image = (select idImages  from Competition.Images where '{sportsman.Image}' = Competition.Images.Name), Competition.Sportsman.idTitle = (select idTitle from Competition.Title where '{sportsman.Title}' = Competition.Title.Name), Competition.Sportsman.Height = {sportsman.Height}, Competition.Sportsman.Cost = {sportsman.Cost},Competition.Sportsman.idCommand =(select Competition.Command.idCommand from Competition.Command where Competition.Command.Name = '{sportsman.Command}') where ID = {sportsman.ID};", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }
        public static void UpdateCommand(Command command)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"update Competition.Command set Name='{command.Name}',Count={command.Count},Image='{command.Image}', ID_city = (select Competition.City.idCity from Competition.City where Competition.City.Name = '{command.City}') where idCommand = {command.ID};", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }
        public static void UpdateCompet(Competition compet)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"update Competition.Competition set Name='{compet.Name}',NameVenue='{compet.NameVenue}',Street='{compet.Street}', Home='{compet.Home}',idCity = (select idCity from City where Competition.City.Name = '{compet.City}'), Date ='{compet.Date.ToString("yyyy-MM-dd hh:mm:ss")}' where idCompetition = {compet.ID};", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }

        public static void UpdateResult(Result result)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand($"update Competition.ResultCompetition set Competition.ResultCompetition.idCompetition=(select Competition.Competition.idCompetition from Competition.Competition where Competition.Competition.Name = '{result.Compet}'), Competition.ResultCompetition.idCommand=(select Competition.Command.idCommand from Competition.Command where Competition.Command.Name = '{result.Command}'), Competition.ResultCompetition.Rank = {result.Rank} where idResult = {result.ID};", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }
    }
}
