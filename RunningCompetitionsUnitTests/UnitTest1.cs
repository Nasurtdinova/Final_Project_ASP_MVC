using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CoreFramework;

namespace RunningCompetitionsUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIsLogin()
        {
            Assert.AreEqual(ConnectionUser.IsLogin("2003", "2003"), 1);
        }
    }
}
