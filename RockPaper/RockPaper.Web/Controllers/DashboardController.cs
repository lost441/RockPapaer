namespace RockPaper.Web.Controllers
{
    using Contracts.Providers;
    using Contracts.Response;
    using Providers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Web.Models;



    /// <summary>
    /// Class DashboardController.
    /// </summary>
    public class DashboardController : Controller
    {



        // GET: Dashboard
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            var gameProvider = new GameProvider();

            var roundsProvider = new RoundProvider();
            var games = gameProvider.GetAllGamesForDashboardGames(12).ToList();

            List<GameResult> gameResults = new List<GameResult>();

            foreach (var game in games)
            {
                var gameRounds = roundsProvider.GetCompletedRoundByGameId(game.Id).ToList();

                gameResults.Add(new GameResult()
                {
                    Game = game,
                    Rounds = gameRounds,
                    LastRound = gameRounds.OrderByDescending(x => x.SequenceNumber).FirstOrDefault(),
                    Team1WinsCount = gameRounds.Where(x => x.Result == Contracts.Common.RoundResult.Team1Won).ToList().Count,
                    Team2WinsCount = gameRounds.Where(x => x.Result == Contracts.Common.RoundResult.Team2Won).ToList().Count,
                    DrawsCount = gameRounds.Where(x => x.Result == Contracts.Common.RoundResult.Draw).ToList().Count
                });
            }
            gameResults.Sort();
            ViewBag.Data = gameResults;

            return View();
        }


    }
}