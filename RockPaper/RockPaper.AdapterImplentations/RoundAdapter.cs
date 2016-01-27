// <copyright file="RoundAdapter.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

namespace RockPaper.AdapterImplentations
{
    using Adapter;
    using Contracts.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts.Providers;
    using Instrumentation.Logging;

    /// <summary>
    /// The Round Interface.
    /// </summary>
    public class RoundAdapter : IRoundAdapter
    {
        /// <summary>
        /// The context
        /// </summary>
        private DataSource.RockPapercContext context;

        /// <summary>
        /// The logger
        /// </summary>
        private Logging logger = LogFactory.Create();

        /// <summary>
        /// Initializes a new instance of the <see cref="RoundAdapter"/> class.
        /// </summary>
        public RoundAdapter()
        {
            context = new DataSource.RockPapercContext();
        }
        
        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }

        /// <summary>
        /// Creates the round.
        /// </summary>
        /// <param name="round">The round.</param>
        /// <returns>Created round</returns>
        public Round CreateRound(Round round)
        {
            var game = context.Games.Single(x => x.Id == round.GameId);

            var roundItem = new DataSource.Round
            {
                Id = Guid.NewGuid(),
                Result = round.Result.ToString(),
                SequenceNumber = round.SequenceNumber,
                Team1Hand = round.Team1Hand != null ? round.Team1Hand.ToString() : string.Empty,
                Team2Hand = round.Team2Hand != null ? round.Team2Hand.ToString() : string.Empty,
                Game = game
            };

            return context.Round.Add(roundItem).Map();
        }

        /// <summary>
        /// Updates the round.
        /// </summary>
        /// <param name="round">The round.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Round UpdateRound(Round round)
        {
            var roundItem = context.Round.Single(x => x.Id == round.Id);
            roundItem.Result = round.Result.ToString();
            roundItem.Team1Hand = round.Team1Hand.ToString();
            roundItem.Team2Hand = round.Team2Hand.ToString();
            return roundItem.Map();
        }

        /// <summary>
        /// Gets the round by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The completed round</returns>
        public IEnumerable<Round> GetCompletedRoundByGameId(Guid id)
        {
            var result = context.Round
                            .Where(x => x.Game.Id == id && (x.Result == "Team1Won" || x.Result == "Team2Won" || x.Result == "Draw"));                

            return result.Map();
        }

        /// <summary>
        /// Updates the team1 hand.
        /// </summary>
        /// <param name="roundId"></param>
        /// <param name="hand">The hand.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Round UpdateTeam1Hand(Guid roundId, Hand hand)
        {
            var round = context.Round.Single(x => x.Id == roundId);
            round.Team1Hand = hand.ToString();

            return round.Map();
        }

        /// <summary>
        /// Updates the team2 hand.
        /// </summary>
        /// <param name="roundId"></param>
        /// <param name="hand">The hand.</param>
        /// <returns>The updated round</returns>
        public Round UpdateTeam2Hand(Guid roundId, Hand hand)
        {
            var round = context.Round.Single(x => x.Id == roundId);
            round.Team2Hand = hand.ToString();

            return round.Map();
        }

        /// <summary>
        /// Gets the new round number.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns>The next sequence number in the round.</returns>
        public int GetNextRoundNumber(Guid gameId)
        {
            var count = context.Round.Count(x => x.Game.Id == gameId) + 1;
            return count;
        }

        /// <summary>
        /// Gets the round for player two.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns></returns>
        public Round GetRoundForPlayerTwo(Guid gameId)
        {
            return context.Round.Single(x => x.Team2Hand == string.Empty && x.Game.Id == gameId).Map();
        }

    }
}
