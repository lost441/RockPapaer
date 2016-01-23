using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaper.AdapterImplentations;
using TestProject.TestData;

namespace TestProject
{
    [TestClass]
    public class TeamAdapterTest : AbstractTests
    {
        [TestMethod]
        public void RegsiterNewTeamTest()
        {
            var adapter = new TeamAdapter();
            var newTeamLoaded = adapter.RegisterNewTeam("Test Team Name");
            adapter.SaveChanges();
            var loadedItem = adapter.GetTeamById(newTeamLoaded.Id);

            Assert.AreEqual(newTeamLoaded.Id, loadedItem.Id);
        }
    }
}
