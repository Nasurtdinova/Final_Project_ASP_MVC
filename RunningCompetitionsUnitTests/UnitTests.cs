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
        public void TestCommands()
        {
            Assert.AreEqual(ConnectionUser.IsCorrectUser("2003", "2003"), 1); //проверка на правильность логина и пароля админа
            Assert.AreEqual(ConnectionUser.IsCorrectUser("0", "0"), 0); //проверка на неправильность логина и пароля

            Assert.AreEqual(ConnectionUser.IsCoinsLogin("2003"), true); //проверка на существование такого логина

            Assert.AreEqual(ConnectionUser.IsCorrectPassword("guzelka2016!"), true); //проверка на корректность такого пароля
            Assert.AreEqual(ConnectionUser.IsCorrectPassword("guz2"), false); //проверка на некорректность такого пароля
        }

        [TestMethod]
        public void TestSportsmans()
        {
            Assert.AreEqual(ConnectionUser.IsCorrectUser("2003", "2003"), 1); //проверка на правильность логина и пароля админа
            Assert.AreEqual(ConnectionUser.IsCorrectUser("0", "0"), 0); //проверка на неправильность логина и пароля

            Assert.AreEqual(ConnectionUser.IsCoinsLogin("2003"), true); //проверка на существование такого логина

            Assert.AreEqual(ConnectionUser.IsCorrectPassword("guzelka2016!"), true); //проверка на корректность такого пароля
            Assert.AreEqual(ConnectionUser.IsCorrectPassword("guz2"), false); //проверка на некорректность такого пароля
        }
    }
}
