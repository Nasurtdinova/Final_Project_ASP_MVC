using CoreFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RunningCompetitionsUnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestIsCorrectUser()
        {
            Assert.AreEqual(ConnectionUser.IsCorrectUser("2003", "2003"), 1); //проверка на правильность логина и пароля админа
            Assert.AreEqual(ConnectionUser.IsCorrectUser("0", "0"), 0); //проверка на неправильность логина и пароля

            Assert.AreEqual(ConnectionUser.IsCoinsLogin("2003"), true); //проверка на существование такого логина

            Assert.AreEqual(ConnectionUser.IsCorrectPassword("guzelka2016!"), true); //проверка на корректность такого пароля
            Assert.AreEqual(ConnectionUser.IsCorrectPassword("guz2"), false); //проверка на некорректность такого пароля
        }

        [TestMethod]
        public void TestRegistrationUser()
        {
            Users user = new Users { Email = "zaysev@mail.ru", Password = "fghj45!" };
            ConnectionUser.AddUser(user); // добавление пользователя
            List<Users> users = ConnectionUser.GetUsers();
            Assert.IsTrue(users.Contains(user));

            Sponsor spon = new Sponsor() { Name = "Андрей", Surname = "Зайцев", Phone = "89566522" };
            ConnectionUser.AddSponsor(spon); //добавление спонсора
            List<Sponsor> sponsors = ConnectionUser.GetSponsors();
            Assert.IsTrue(sponsors.Contains(spon));
        }

        [TestMethod]
        public void TestCommands()
        {
            Command com = new Command { Name = "Алые Паруса", Count = 7, ID_city = 1};
            ConnectionCommands.AddCommand(com); // добавление команды
            ObservableCollection<Command> commands = ConnectionCommands.GetCommands();
            Assert.IsTrue(commands.Contains(com));

            ConnectionCommands.RemoveCommand(commands.Last().idCommand); // удаление команды
            commands = ConnectionCommands.GetCommands();
            Assert.IsFalse(commands.Contains(com));

            Command updateCommand = new Command { idCommand = 1035, Count = 10, Name = "Машины", ID_city = 2 };
            ConnectionCommands.UpdateCommand(updateCommand); // редактирование команды
            commands = ConnectionCommands.GetCommands();
            Assert.IsFalse(commands.Contains(updateCommand));
        }

        [TestMethod]
        public void TestSportsmans()
        {
            Sportsman sports = new Sportsman { Surname = "Морозов", Name = "Сергей", Height = 185, idCommand = 23, idTitle = 1 };
            ConnectionSportsmans.AddSportsman(sports); // добавление спортсмена
            ObservableCollection<Sportsman> sportsmans = ConnectionSportsmans.GetSportsmans();
            Assert.IsTrue(sportsmans.Contains(sports));

            ConnectionSportsmans.RemoveSportsman(sportsmans.Last().ID); // удаление спортсмена
            sportsmans = ConnectionSportsmans.GetSportsmans();
            Assert.IsFalse(sportsmans.Contains(sports));

            Sportsman updateSportsman = new Sportsman { ID = 57, Height = 180, Name = "Антон", Surname = "Антипов", idTitle = 1, idCommand = 23, IsDeleted = false };
            ConnectionSportsmans.UpdateSportsman(updateSportsman); // редактирование спортсмена
            sportsmans = ConnectionSportsmans.GetSportsmans();
            Assert.IsFalse(sportsmans.Contains(updateSportsman));
        }

        [TestMethod]
        public void TestCompetitions()
        {
            Competition compet = new Competition { Name = "Кубок гагарина", Date = new DateTime(2022, 8, 25), NameVenue = "Физра", idCity = 2, Street = "Аграрная", Home = 12 };
            ConnectionCompetitions.AddCompetition(compet); // добавление соревнования
            ObservableCollection<Competition> compets = ConnectionCompetitions.GetCompetitions();
            Assert.IsTrue(compets.Contains(compet));

            ConnectionCompetitions.RemoveCompetition(compets.Last().idCompetition); // удаление соревнования
            compets = ConnectionCompetitions.GetCompetitions();
            Assert.IsFalse(compets.Contains(compet));

            Competition updateCompet = new Competition(){ idCompetition = 1039, Date = new DateTime(2022, 8, 25), Name = "Веселые старты", NameVenue = "Физра", idCity = 2, Street = "Космонавтов", Home = 12 };
            ConnectionCompetitions.UpdateCompet(updateCompet); // редактирование соревнования
            compets = ConnectionCompetitions.GetCompetitions();
            Assert.IsFalse(compets.Contains(updateCompet));
        }

        [TestMethod]
        public void TestResultCompetitions()
        {
            ResultCompetition res = new ResultCompetition() { idCommand = 31, idCompetition = 29, Rank = 13 };
            ConnectionResults.AddResult(res); // добавление результата соревнований
            ObservableCollection<ResultCompetition> results = ConnectionResults.GetResults();
            Assert.IsTrue(results.Contains(res));

            ConnectionResults.RemoveResult(31, 29); // удаление результата
            results = ConnectionResults.GetResults();
            Assert.IsFalse(results.Contains(res));
        }

        [TestMethod]
        public void TestSponsorships()
        {
            SponsorCommand sponCom = new SponsorCommand() { idCom = 31, idSponsor = 7, DateBegin = new DateTime(2022, 8, 25), DateEnd = new DateTime(2022, 8, 25), MutualBenefit = "fdfd", Amount = 5000 };
            ConnectionSponsorship.AddSponsorship(sponCom); // добавление команды для спонсирования
            List<SponsorCommand> sponComs = ConnectionSponsorship.GetSponsorships();
            Assert.IsTrue(sponComs.Contains(sponCom));

            ConnectionSponsorship.EndSponsorship(6); // завершение спонсирования
        }
    }
}
