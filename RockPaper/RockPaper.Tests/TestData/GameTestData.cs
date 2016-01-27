using RockPaper.AdapterImplentations;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Providers;

namespace TestProject.TestData
{
    internal sealed partial class ObjectMother
    {
        internal static class GameTestData
        {
            public static Game Game1 { get; set; }
            public static Game Game2 { get; set; }
            public static Game Game3 { get; set; }


            public static void Create()
            {
                var adapter = new GameAdapter();
                Game1 = adapter.RegisiterNewGame();
                Game2 = adapter.RegisiterNewGame();
                Game3 = adapter.RegisiterNewGame();

                adapter.SaveChanges();

                var teamAdapter = new TeamAdapter();
                var team1 = teamAdapter.GetTeamById(ObjectMother.TeamTestData.Team1Id);
                var team2 = teamAdapter.GetTeamById(ObjectMother.TeamTestData.Team2Id);
                var team3 = teamAdapter.GetTeamById(ObjectMother.TeamTestData.Team3Id);

                var gameAdapter = new GameAdapter();
                gameAdapter.JoinExistingGame(team1, ObjectMother.GameTestData.Game1.Id);
                gameAdapter.JoinExistingGame(team2, ObjectMother.GameTestData.Game1.Id);

                gameAdapter.JoinExistingGame(team1, ObjectMother.GameTestData.Game2.Id);
                gameAdapter.JoinExistingGame(team2, ObjectMother.GameTestData.Game2.Id);

                gameAdapter.SaveChanges();
            }

        }
    }
}
