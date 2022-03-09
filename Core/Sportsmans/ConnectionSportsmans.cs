﻿using Dapper;
using Final_Project_ASP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
//лишние библиотеки убрать
namespace Core
{
    public class ConnectionSportsmans //разнести классы по папочкам
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["Competition"].ConnectionString;
        private static IDbConnection connection = new SqlConnection(connStr);

        public static ObservableCollection<Sportsmans> GetSportsmans()
        {
            ObservableCollection<Sportsmans> sportsman = new ObservableCollection<Sportsmans>();
            try
            {
                for (int i = 0; i< connection.Query<int>($"SELECT * FROM Sportsman;").Count();i++)
                {
                    sportsman.Add(new Sportsmans
                    {
                        ID = connection.Query<int>($"SELECT ID FROM Sportsman join Images on ID_Image = idImages join Title on Title.idTitle = Sportsman.idTitle join Command on Command.idCommand = Sportsman.idCommand;").AsList()[i],
                        Surname = connection.Query<string>($"SELECT Surname FROM Sportsman join Images on ID_Image = idImages join Title on Title.idTitle = Sportsman.idTitle join Command on Command.idCommand = Sportsman.idCommand;").AsList()[i],
                        Name = connection.Query<string>($"SELECT Sportsman.Name FROM Sportsman join Images on ID_Image = idImages join Title on Title.idTitle = Sportsman.idTitle join Command on Command.idCommand = Sportsman.idCommand;").AsList()[i],
                        Image = connection.Query<string>($"SELECT Images.Name FROM Sportsman join Images on ID_Image = idImages join Title on Title.idTitle = Sportsman.idTitle join Command on Command.idCommand = Sportsman.idCommand;").AsList()[i],
                        Title = connection.Query<string>($"SELECT Title.Name FROM Sportsman join Images on ID_Image = idImages join Title on Title.idTitle = Sportsman.idTitle join Command on Command.idCommand = Sportsman.idCommand;").AsList()[i],
                        Height = connection.Query<int>($"SELECT Height FROM Sportsman join Images on ID_Image = idImages join Title on Title.idTitle = Sportsman.idTitle join Command on Command.idCommand = Sportsman.idCommand;").AsList()[i],
                        Cost = connection.Query<int>($"SELECT Cost FROM Sportsman join Images on ID_Image = idImages join Title on Title.idTitle = Sportsman.idTitle join Command on Command.idCommand = Sportsman.idCommand;").AsList()[i],
                        Command = connection.Query<string>($"SELECT Command.Name FROM Sportsman join Images on ID_Image = idImages join Title on Title.idTitle = Sportsman.idTitle join Command on Command.idCommand = Sportsman.idCommand;").AsList()[i]
                    });
                }
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }

            return sportsman;
        }

        public static Sportsman GetSportsmansId(int id)
        {
            Sportsman sportsman = null;

            try
            {
                sportsman = new Sportsman {
                 ID = connection.Query<int>($"SELECT ID FROM Sportsman join Images on ID_Image = idImages join Title on Title.idTitle = Sportsman.idTitle join Command on Command.idCommand = Sportsman.idCommand where Sportsman.ID = {id};").AsList().FirstOrDefault(),
                 Surname = connection.Query<string>($"SELECT Surname FROM Sportsman join Images on ID_Image = idImages join Title on Title.idTitle = Sportsman.idTitle join Command on Command.idCommand = Sportsman.idCommand where Sportsman.ID = {id};").AsList().FirstOrDefault(),
                 Name = connection.Query<string>($"SELECT Sportsman.Name FROM Sportsman join Images on ID_Image = idImages join Title on Title.idTitle = Sportsman.idTitle join Command on Command.idCommand = Sportsman.idCommand where Sportsman.ID = {id};").AsList().FirstOrDefault(),
                 Image = connection.Query<string>($"SELECT Images.Name FROM Sportsman join Images on ID_Image = idImages join Title on Title.idTitle = Sportsman.idTitle join Command on Command.idCommand = Sportsman.idCommand where Sportsman.ID = {id};").AsList().FirstOrDefault(),
                 Title = connection.Query<string>($"SELECT Title.Name FROM Sportsman join Images on ID_Image = idImages join Title on Title.idTitle = Sportsman.idTitle join Command on Command.idCommand = Sportsman.idCommand where Sportsman.ID = {id};").AsList().FirstOrDefault(),
                 Height = connection.Query<int>($"SELECT Height FROM Sportsman join Images on ID_Image = idImages join Title on Title.idTitle = Sportsman.idTitle join Command on Command.idCommand = Sportsman.idCommand where Sportsman.ID = {id};").AsList().FirstOrDefault(),
                 Cost = connection.Query<int>($"SELECT Cost FROM Sportsman join Images on ID_Image = idImages join Title on Title.idTitle = Sportsman.idTitle join Command on Command.idCommand = Sportsman.idCommand where Sportsman.ID = {id};").AsList().FirstOrDefault(),
                 Command = connection.Query<string>($"SELECT Command.Name FROM Sportsman join Images on ID_Image = idImages join Title on Title.idTitle = Sportsman.idTitle join Command on Command.idCommand = Sportsman.idCommand where Sportsman.ID = {id};").AsList().FirstOrDefault()
            };}

            catch // Exception исправить
            { 
                return null; 
            }

            return sportsman;
        }

        public static void RemoveSportsman(int id)
        {
            try
            {
                connection.Query($"DELETE from Sportsman WHERE (ID = '{id}')");
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AddSportsman(Sportsman sportsman)
        {
            try
            {//слишком длинная строка
                connection.Query($"INSERT Sportsman values('{sportsman.Surname}', '{sportsman.Name}', (select Images.idImages FROM Images where '{sportsman.Image}' = Images.Name), (select Title.idTitle FROM Title where '{sportsman.Title}' = Title.Name),{sportsman.Cost}, {sportsman.Height}, (select Command.idCommand from Command where Command.Name = '{sportsman.Command}'));");
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateSportsman(Sportsman sportsman)
        {
            try
            {//слишком длинная строка
                connection.Query($"update Sportsman set Sportsman.Surname='{sportsman.Surname}',Sportsman.Name='{sportsman.Name}', Sportsman.ID_Image = (select idImages  from Images where '{sportsman.Image}' = Images.Name), Sportsman.idTitle = (select idTitle from Title where '{sportsman.Title}' = Title.Name), Sportsman.Height = {sportsman.Height}, Sportsman.Cost = {sportsman.Cost},Sportsman.idCommand =(select Command.idCommand from Command where Command.Name = '{sportsman.Command}') where ID = {sportsman.ID};");
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}