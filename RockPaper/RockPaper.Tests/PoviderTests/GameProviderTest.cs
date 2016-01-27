using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaper.Providers;
using TestProject.TestData;
using RockPaper.AdapterImplentations;
using Contracts.Common;

namespace TestProject
{
    [TestClass]
    public class GameProviderTest : AbstractTests
    {
        [TestMethod]
        public void FindAGameTest()
        {
            var provider = new GameProvider();
            provider.GetNextAvailableGame(ObjectMother.TeamTestData.Team1Id);
            var gameId = provider.GetNextAvailableGame(ObjectMother.TeamTestData.Team2Id);

            var gameAdapter = new GameAdapter();
            var game = gameAdapter.GetGameById(gameId);

            if (game.Team1 == null || game.Team2 == null)
            {
                Assert.Fail("Could not find game.");
            }
        }

        [TestMethod]
        public void FullGameTest()
        {
            var gameProvider = new GameProvider();
            var roundProvider = new RoundProvider();

            gameProvider.GetNextAvailableGame(ObjectMother.TeamTestData.Team1Id);
            var gameId = gameProvider.GetNextAvailableGame(ObjectMother.TeamTestData.Team2Id);

            // Round 1 - 0 1
            roundProvider.SumbitHand(Hand.Rock, ObjectMother.TeamTestData.Team1Id, gameId);
            roundProvider.SumbitHand(Hand.Paper, ObjectMother.TeamTestData.Team2Id, gameId);

            // Round 2 Draw
            roundProvider.SumbitHand(Hand.Rock, ObjectMother.TeamTestData.Team1Id, gameId);
            roundProvider.SumbitHand(Hand.Rock, ObjectMother.TeamTestData.Team2Id, gameId);

            // Round 3 - 0 2
            roundProvider.SumbitHand(Hand.Spock, ObjectMother.TeamTestData.Team1Id, gameId);
            roundProvider.SumbitHand(Hand.Paper, ObjectMother.TeamTestData.Team2Id, gameId);

            // Round 4 - 1 2 
            roundProvider.SumbitHand(Hand.Lizard, ObjectMother.TeamTestData.Team1Id, gameId);
            roundProvider.SumbitHand(Hand.Spock, ObjectMother.TeamTestData.Team2Id, gameId);

            // Round 5 Draw
            roundProvider.SumbitHand(Hand.Lizard, ObjectMother.TeamTestData.Team1Id, gameId);
            roundProvider.SumbitHand(Hand.Lizard, ObjectMother.TeamTestData.Team2Id, gameId);

            // Round 6 Draw
            roundProvider.SumbitHand(Hand.Paper, ObjectMother.TeamTestData.Team1Id, gameId);
            roundProvider.SumbitHand(Hand.Paper, ObjectMother.TeamTestData.Team2Id, gameId);

            // Round 7 - 2 2
            roundProvider.SumbitHand(Hand.Scissor, ObjectMother.TeamTestData.Team1Id, gameId);
            roundProvider.SumbitHand(Hand.Paper, ObjectMother.TeamTestData.Team2Id, gameId);

            // Round 7 - 2 3
            roundProvider.SumbitHand(Hand.Rock, ObjectMother.TeamTestData.Team1Id, gameId);
            roundProvider.SumbitHand(Hand.Paper, ObjectMother.TeamTestData.Team2Id, gameId);


        }
    }
}
