
using Contracts.Providers;

namespace RockPaper.StubData.Builders
{
    using System;
    using Contracts;
    using Contracts.Common;

    /// <summary>
    /// The Game Builder
    /// </summary>
    public class GameBuilder : Game
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameBuilder"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public GameBuilder(Guid? id = null)
        {
            this.Id = id ?? Guid.NewGuid();
        }

        /// <summary>
        /// News the game.
        /// </summary>
        /// <param name="team">The team.</param>
        /// <returns>A new Game</returns>
        public GameBuilder New(Team team = null)
        {
            this.GameState = GameState.WaitingForPlayers;
            this.Team1 = team ?? new TeamBuilder().AlphaTeam().Build();
            this.IsComplete = false;

            return this;
        }

        /// <summary>
        /// Ins the progress.
        /// </summary>
        /// <returns>A game in progress</returns>
        public GameBuilder InProgress()
        {
            this.New();

            this.GameState = GameState.Player2Hand;
            this.Team2 = new TeamBuilder().BravoTeam().Build();
            this.IsComplete = false;

            return this;
        }

        /// <summary>
        /// Completes this instance.
        /// </summary>
        /// <returns>A completed Game</returns>
        public GameBuilder Complete()
        {
            this.InProgress();
            
            this.GameState = GameState.Complete;
            this.IsComplete = true;
            this.WinningTeam = this.Team1.Id.ToString();

            return this;
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns>The final Game object</returns>
        public Game Build()
        {
            return new Game
            {
                Id = this.Id,
                Team1 = this.Team1,
                Team2 = this.Team2,
                IsComplete = this.IsComplete,
                GameState = this.GameState,
                WinningTeam = this.WinningTeam
            };
        }
    }
}
