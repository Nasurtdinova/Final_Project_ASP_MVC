using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

namespace CoreFramework
{
    public class ConnectionSportsmans
    {
        public static ObservableCollection<Sportsman> GetSportsmans()
        {
            return new ObservableCollection<Sportsman>(bdConnection.connection.Sportsman.ToList().Where(a => a.IsDeleted == false));            
        }

        public static Sportsman GetSportsmansId(int id)
        {
            ObservableCollection<Sportsman> commands = GetSportsmans();
            return commands.Where(tt => tt.ID == id).FirstOrDefault();
        }

        public static void RemoveSportsman(int id)
        {
            try
            {
                Sportsman sportsman = bdConnection.connection.Sportsman.FirstOrDefault(p => p.ID == id);
                sportsman.IsDeleted = true;
                bdConnection.connection.SaveChanges();
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
                sportsman.Command = Connection.GetCommand(sportsman.Command.Name);
                sportsman.Title = Connection.GetTitle(sportsman.Title.Name);
                sportsman.IsDeleted = false;
                bdConnection.connection.Sportsman.Add(sportsman);
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateSportsman(Sportsman sportsman)
        {
            try
            {
                var sports = bdConnection.connection.Sportsman.SingleOrDefault(r => r.ID == sportsman.ID);
                sports.Name = sportsman.Name;
                sports.Height = sportsman.Height;
                sports.Surname = sportsman.Surname;

                if (sportsman.Image != null)
                    sports.Image = sportsman.Image;

                sportsman.Command = Connection.GetCommand(sportsman.Command.Name);
                sportsman.Title = Connection.GetTitle(sportsman.Title.Name);

                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
