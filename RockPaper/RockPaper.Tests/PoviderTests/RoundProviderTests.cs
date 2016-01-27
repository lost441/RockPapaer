using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject.TestData;
using RockPaper.Providers;
using Contracts.Common;
using Contracts;
using RockPaper.AdapterImplentations;
using System.Linq;

namespace TestProject.PoviderTests
{
    [TestClass]
    public class RoundProviderTests : AbstractTests
    {
        /// <summary>
        /// Sumbits the hand test.
        /// </summary>
        [TestMethod]
        public void SumbitHandTest()
        {
            var gameProvider = new GameProvider();
            gameProvider.GetNextAvailableGame(ObjectMother.TeamTestData.Team1Id);
            var gameId = gameProvider.GetNextAvailableGame(ObjectMother.TeamTestData.Team2Id);

            var roundProvider = new RoundProvider();
            roundProvider.SumbitHand(Hand.Rock, ObjectMother.TeamTestData.Team1Id, gameId);
            roundProvider.SumbitHand(Hand.Paper, ObjectMother.TeamTestData.Team2Id, gameId);

            var roundAdapter = new RoundAdapter();

            var finalRoundResult = roundAdapter.GetCompletedRoundByGameId(gameId);
            if (finalRoundResult.Count() != 1) 
            {
                Assert.Fail("Error linking round.");
            }

            foreach (var round in finalRoundResult)
            {
                Assert.AreEqual(round.Result, RoundResult.Team2Won);
            }
            
        }
    }
}
