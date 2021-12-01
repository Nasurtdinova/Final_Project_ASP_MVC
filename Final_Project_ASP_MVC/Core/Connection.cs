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
        public static MySqlConnection conn = new MySqlConnection(connStr);

        static Connection()
        {
            conn.Open();
        }

        public static List<Sportsman> GetProjects()
        {
            List<Sportsman> projects = new List<Sportsman>();

            try
            {
                string sql = "SELECT * FROM Sportsman";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    projects.Add(new Sportsman { ID = Convert.ToInt32(res[0]), Surname = res[1].ToString(), Name = res[2].ToString(), Image = res[3].ToString() });
                }
                res.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return projects;
        }

        public static void RemoveProject(string name)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand($"DELETE from Projects.Projects WHERE (Name = '{name}')", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AddProject(Sportsman sportsman)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO Competition.Sportsman(Surname, Name, Image) VALUES('{sportsman.Surname}', '{sportsman.Name}','{sportsman.Image}')", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
