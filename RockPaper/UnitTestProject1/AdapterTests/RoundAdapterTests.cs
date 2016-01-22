using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaper.AdapterImplentations;
using TestProject.TestData;
using System.Linq;

namespace TestProject.AdapterTests
{
    [TestClass]
    public class RoundAdapterTests : AbstractTests
    {
        [TestMethod]
        public void GetCompletedRoundByGameIdTests()
        {
            var roundAdapter = new RoundAdapter();
            var roundsPlayed = roundAdapter.GetCompletedRoundByGameId(ObjectMother.GameTestData.Game2.Id);

            Assert.AreEqual(4, roundsPlayed.Count());
        
        }
    }
}
