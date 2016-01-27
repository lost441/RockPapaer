
using Contracts.Common;

namespace TestProject.PoviderTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestData;
    using RockPaper.AdapterImplentations;
    using RockPaper.Providers;

    [TestClass]
    public class SimulatorProviderTests : AbstractTests
    {
        [TestMethod]
        public void RegisterSimnulatedGame()
        {
            var provider = ProviderFactory.GetGameProvider();
            var gameId = provider.GetNextAvailableGame(ObjectMother.TeamTestData.Team1Id, true);
    
            var gameAdapter = new GameAdapter();
            var game = gameAdapter.GetGameById(gameId);

            const string msg = "Could not find game";
            Assert.IsNotNull(game.Team1, msg);
            Assert.IsNotNull(game.Team2, msg);
            Assert.AreEqual(game.GameState, GameState.Player2Hand);
        }

        [TestMethod]
        public void RegisterSimnulatedGameAndPlayOneHand()
        {
            var gameProvider = ProviderFactory.GetGameProvider();
            var roundProvider = ProviderFactory.GetRoundProvider();
            var gameAdapter = AdapterFactory.GetGameAdapter();
            var myTeamId = ObjectMother.TeamTestData.Team1Id;

            var gameId = gameProvider.GetNextAvailableGame(myTeamId, true);

            Assert.IsTrue(gameProvider.IsItMyTurn(gameId, myTeamId));

            roundProvider.SumbitHand(Hand.Paper, myTeamId, gameId);
            
            var game = gameAdapter.GetGameById(gameId);

            Assert.AreEqual(GameState.Player2Hand, game.GameState);
        }
    }
}
