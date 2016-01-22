// <copyright file="RoundAdapter.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>
namespace RockPaper.AdapterImplentations
{
    using RockPaper.Adapter;
    using RockPaper.Contracts.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The Round Interface.
    /// </summary>
    public class RoundAdapter : IRoundAdapter
    {
        /// <summary>
        /// The context
        /// </summary>
        private RockPaper.DataSource.RockPapercContext context;

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
                //TODO: Logging
            }
        }

        /// <summary>
        /// Creates the round.
        /// </summary>
        /// <param name="round">The round.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RockPaper.Contracts.Round CreateRound(RockPaper.Contracts.Round round)
        {
            var game = context.Games.Single(x => x.Id == round.GameId);

            var roundItem = new RockPaper.DataSource.Round
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
        public RockPaper.Contracts.Round UpdateRound(RockPaper.Contracts.Round round)
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
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<RockPaper.Contracts.Round> GetCompletedRoundByGameId(Guid Id)
        {
            var result = context.Round
                            .Where(x => x.Game.Id == Id && (x.Result == "Team1Won" || x.Result == "Team2Won"));                

            return result.Map();
        }

        /// <summary>
        /// Updates the team1 hand.
        /// </summary>
        /// <param name="RoundId"></param>
        /// <param name="hand">The hand.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RockPaper.Contracts.Round UpdateTeam1Hand(Guid RoundId, Hand hand)
        {
            var round = context.Round.Single(x => x.Id == RoundId);
            round.Team1Hand = hand.ToString();

            return round.Map();
        }

        /// <summary>
        /// Updates the team2 hand.
        /// </summary>
        /// <param name="RoundId"></param>
        /// <param name="hand">The hand.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RockPaper.Contracts.Round UpdateTeam2Hand(Guid RoundId, Hand hand)
        {
            var round = context.Round.Single(x => x.Id == RoundId);
            round.Team2Hand = hand.ToString();

            return round.Map();
        }

        /// <summary>
        /// Gets the new round number.
        /// </summary>
        /// <param name="GameId">The game identifier.</param>
        /// <returns>The next sequence number in the round.</returns>
        public int GetNextRoundNumber(Guid GameId)
        {
            var count = context.Round.Count(x => x.Game.Id == GameId) + 1;
            return count;
        }

        /// <summary>
        /// Gets the round for player two.
        /// </summary>
        /// <param name="GameId">The game identifier.</param>
        /// <returns></returns>
        public RockPaper.Contracts.Round GetRoundForPlayerTwo(Guid GameId)
        {
            return context.Round.Single(x => x.Team2Hand == string.Empty && x.Game.Id == GameId).Map();
        }

    }
}
