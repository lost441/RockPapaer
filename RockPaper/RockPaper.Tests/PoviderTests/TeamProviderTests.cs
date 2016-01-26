using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaper.Providers;

namespace TestProject.PoviderTests
{
    [TestClass]
    public class TeamProviderTests
    {
        [TestMethod]
        public void RegisterATeamTest()
        {
            var provider = new TeamProvider();
            var team = provider.RegisterTeam("RegisterATeamTest");

            var fetchTeam = provider.GetTeamById(team.Id);

            Assert.AreEqual(fetchTeam.TeamName, team.TeamName);
        }

        [TestMethod]
        public void RegisterATeamThatAlreadyExisistTest()
        {
            var provider = new TeamProvider();
            var team = provider.RegisterTeam("RegisterATeamTest");

            var fetchTeam = provider.GetTeamById(team.Id);

            Assert.AreEqual(fetchTeam.TeamName, team.TeamName);
        }
    }
}
