
namespace RockPaper.StubData.Builders
{
    using System;
    using Contracts.Providers;
    using Contracts.Common;

    /// <summary>
    /// The round builder
    /// </summary>
    public class RoundBuilder : Round
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoundBuilder"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public RoundBuilder(Guid? id = null)
        {
            this.Id = id ?? Guid.NewGuid();
        }

        /// <summary>
        /// Completes the round.
        /// </summary>
        /// <param name="seq">The seq.</param>
        /// <param name="gameId">The game identifier.</param>
        /// <returns>Set complete round</returns>
        public RoundBuilder CompleteRound(int? seq = null, Guid? gameId = null)
        {
            this.GameId = gameId ?? Guid.NewGuid();
            this.SequenceNumber = seq ?? 0;

            
            this.Team1Hand = Hand.Paper;
            this.Team1Hand = Hand.Rock;

            SetRandomResult();

            return this;
        }
        
        /// <summary>
        /// Games a round one.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="seq">The seq.</param>
        /// <returns>The round</returns>
        public RoundBuilder DefaultRound(int? seq = null, Guid? gameId = null)
        {
            this.GameId = gameId ?? Guid.NewGuid();
            this.SequenceNumber = seq ?? 0;

            this.Result = RoundResult.NotComplete;
            this.Team1Hand = Hand.None;
            this.Team1Hand = Hand.None;
  
            return this;
        }

        /// <summary>
        /// Alphas the team.
        /// </summary>
        /// <returns>Hand One</returns>
        public RoundBuilder SetHandOne(Hand hand)
        {
            this.Team1Hand = hand;

            return this;
        }

        /// <summary>
        /// Alphas the team.
        /// </summary>
        /// <returns>The aplha team</returns>
        public RoundBuilder SetHandTwo(Hand hand)
        {
            this.Team2Hand = hand;
            SetRandomResult();

            return this;
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns>The Team</returns>
        public Round Build()
        {
            return new RoundBuilder
            {
                Id = this.Id,
                GameId = this.GameId,
                SequenceNumber = this.SequenceNumber,
                Result = this.Result,
                Team1Hand = this.Team1Hand,
                Team2Hand = this.Team2Hand
            };
        }

        /// <summary>
        /// Gets the random result.
        /// </summary>
        /// <returns>Random round result</returns>
        private void SetRandomResult()
        {
            var rnd = new Random();
            var resultNumber = rnd.Next(1, 3);

            this.Result = (RoundResult)resultNumber;
        }
    }
}
