using System;
using AthleteRace;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Get_Payout()
        {
            // Arrange
            var pay = new Bet();

            // Act
            var actual = pay.Payout(1);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Check_Bet_Placed()
        {
            // Arrange
            var bettor = new Bettor();

            // Act
            var actual = bettor.PlaceABet(50, 1);

            // Assert
            Assert.AreEqual(false, actual);
        }
    }
}
