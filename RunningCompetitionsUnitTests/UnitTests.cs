using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CoreFramework;

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
            ConnectionUser.AddUser(new Users { Email = "zaysev@mail.ru", Password = "fghj45!" }); // добавление пользователя
            ConnectionUser.AddSponsor(new Sponsor { Name = "Андрей", Surname = "Зайцев", Phone = "89566522" }); //добавление спонсора
        }

        [TestMethod]
        public void TestCommands()
        {
            Assert.IsTrue(ConnectionCommands.AddCommandTest(new Command { Name = "Алые Паруса", Count = 5, ID_city = 1 })); // добавление команды
            Assert.IsTrue(ConnectionCommands.RemoveCommandTest(1034)); //удаление команды
            Assert.IsTrue(ConnectionCommands.UpdateCommandTest(new Command { idCommand = 1035, Count = 10, Name = "Машины", ID_city = 2 })); // редактирование команды
        }

        [TestMethod]
        public void TestSportsmans()
        {
            ConnectionSportsmans.AddSportsman(new Sportsman { Surname = "Морозов", Name = "Сергей", Height = 185, idCommand = 23, idTitle = 1}); // добавление спортсмена
            ConnectionSportsmans.RemoveSportsman(41); // удаление спортсмена
            ConnectionSportsmans.UpdateSportsman(new Sportsman { ID = 39, Height = 180, Name = "Антон", Surname="Антипов", idTitle=1, idCommand=23 }); // редактирование спортсмена
        }

        [TestMethod]
        public void TestCompetitions()
        {
            ConnectionCompetitions.AddCompetition(new Competition { Name ="Кубок гагарина", Date=new DateTime(2022,8,25), NameVenue = "Физра", idCity = 2, Street ="Аграрная", Home=12 }); // добавление соревнования
            ConnectionCompetitions.RemoveCompetition(41); // удаление соревнования
            ConnectionCompetitions.UpdateCompet(new Competition { idCompetition = 39, Date = new DateTime(2022, 8, 25), NameVenue = "Физра", idCity = 2, Street = "Космонавтов", Home = 12 }); // редактирование соревнования
        }

        [TestMethod]
        public void TestResultCompetitions()
        {
            ConnectionResults.AddResult(new ResultCompetition { idCommand = 2, idCompetition = 5, Rank = 5 }); // добавление результата соревнований
            ConnectionResults.RemoveResult(1036,5); // удаление результата
            ConnectionResults.UpdateResult(new ResultCompetition { idCommand = 2, idCompetition = 5, Rank = 5 }); // редактирование результата
        }

        [TestMethod]
        public void TestSponsorships()
        {
            ConnectionSponsorship.AddSponsorship(new SponsorCommand { idCom = 1, idSponsor = 1, DateBegin = new DateTime(), DateEnd = new DateTime(), MutualBenefit="fdfd", Amount=5000}); // добавление команды для спонсирования
            ConnectionSponsorship.EndSponsorship(41); // завершение спонсирования
        }
    }
}
