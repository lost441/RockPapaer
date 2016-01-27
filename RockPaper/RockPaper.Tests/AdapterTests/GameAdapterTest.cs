using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaper.Adapter;
using RockPaper.AdapterImplentations;
using System.Linq;
using TestProject.TestData;
using Contracts.Common;
using Contracts;

namespace TestProject
{
    [TestClass]
    public class GameAdapterTest : AbstractTests
    {
        [TestMethod]
        public void GetAllGamesTest()
        {
            var adapter = new GameAdapter();
            var game = adapter.GetAllGames();

            Assert.AreNotEqual(0, game.Count());

        }
    }
}
