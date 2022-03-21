
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
    public class ConnectionSportsmans //разнести классы по папочкам
    {
        public static ObservableCollection<Sportsman> GetSportsmans()
        {
            ObservableCollection<Sportsman> sportsmans = new ObservableCollection<Sportsman>(bdConnection.connection.Sportsman.ToList());
            return sportsmans;
        }

        public static Sportsman GetSportsmansId(int id)
        {
            ObservableCollection<Sportsman> commands = GetSportsmans();
            var com = commands.Where(tt => tt.ID == id).FirstOrDefault();
            return com;
        }

        public static void RemoveSportsman(int id)
        {
            try
            {
                Sportsman com = bdConnection.connection.Sportsman.FirstOrDefault(p => p.ID == id);
                bdConnection.connection.Sportsman.Remove(com);
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
                ObservableCollection<Images> image = new ObservableCollection<Images>(bdConnection.connection.Images);
                var img = image.Where(tt => tt.Name == sportsman.NameImage).FirstOrDefault();

                ObservableCollection<Command> com = new ObservableCollection<Command>(bdConnection.connection.Command);
                var command = com.Where(tt => tt.Name == sportsman.NameCommand).FirstOrDefault();

                ObservableCollection<Title> title = new ObservableCollection<Title>(bdConnection.connection.Title);
                var tit = title.Where(tt => tt.Name == sportsman.NameTitle).FirstOrDefault();
                sportsman.ID_Image = img.idImages;
                sportsman.idCommand = command.idCommand;
                sportsman.idTitle = tit.idTitle;
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
                sports.Cost = sportsman.Cost;
                sports.Surname = sportsman.Surname;
                var img = bdConnection.connection.Images.SingleOrDefault(r => r.Name == sportsman.Images.Name);
                sports.ID_Image = img.idImages;
                var title = bdConnection.connection.Title.SingleOrDefault(r => r.Name == sportsman.Title.Name);
                sports.idTitle = title.idTitle;
                var com = bdConnection.connection.Command.SingleOrDefault(r => r.Name == sportsman.Command.Name);
                sports.idCommand = com.idCommand;

                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
