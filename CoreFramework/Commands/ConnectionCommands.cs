using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CoreFramework
{
    public class ConnectionCommands
    {
        private static List<Sportsman> sporCom;

        public static List<Sportsman> GetSporCom(int id)
        {
            try
            {
                sporCom = ConnectionSportsmans.GetSportsmans().Where(tt => tt.idCommand == id).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return sporCom;
        }

        public static ObservableCollection<Command> GetCommands()
        {
            return new ObservableCollection<Command>(bdConnection.connection.Command.ToList().Where(a => a.IsDeleted == false));           
        }

        public static void AddCommand(Command command)
        {
            try
            {
                command.IsDeleted = false;

                bdConnection.connection.Command.Add(command);
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static bool AddCommandTest(Command command)
        {
            try
            {
                command.IsDeleted = false;

                bdConnection.connection.Command.Add(command);
                bdConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void RemoveCommand(int id)
        {
            try
            {
                Command com = bdConnection.connection.Command.FirstOrDefault(p => p.idCommand == id);
                com.IsDeleted = true;
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static bool RemoveCommandTest(int id)
        {
            try
            {
                Command com = bdConnection.connection.Command.FirstOrDefault(p => p.idCommand == id);
                com.IsDeleted = true;
                bdConnection.connection.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void UpdateCommand(Command command)
        {
            try
            {
                var com = bdConnection.connection.Command.SingleOrDefault(r => r.idCommand == command.idCommand);
                com.Name = command.Name;
                com.Count = command.Count;
                com.ID_city = command.ID_city;
                if (command.Image != null)
                    com.Image = command.Image;

                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static bool UpdateCommandTest(Command command)
        {
            try
            {
                var com = bdConnection.connection.Command.SingleOrDefault(r => r.idCommand == command.idCommand);
                com.Name = command.Name;
                com.Count = command.Count;
                com.ID_city = command.ID_city;
                if (command.Image != null)
                    com.Image = command.Image;

                bdConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void UpdateImageCommand(int id, byte[] img)
        {
            try
            {
                var com = bdConnection.connection.Command.SingleOrDefault(r => r.idCommand == id);
                com.Image = img;

                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static Command GetCommandsId(int id)
        {
            return GetCommands().Where(tt => tt.idCommand == id).FirstOrDefault();
        }
    }
}
