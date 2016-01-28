// <copyright file="Game.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

namespace Contracts.Providers
{
    using System;
    using Common;

    /// <summary>
    /// The Game class.
    /// </summary>
    public class Game
    {
        protected bool Equals(Game other)
        {
            return Id.Equals(other.Id) && Equals(Team1, other.Team1) && Equals(Team2, other.Team2) && GameState == other.GameState && IsComplete == other.IsComplete && string.Equals(WinningTeam, other.WinningTeam) && IsSimulatedGame == other.IsSimulatedGame && CreatedDate.Equals(other.CreatedDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Game) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode*397) ^ (Team1 != null ? Team1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Team2 != null ? Team2.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) GameState;
                hashCode = (hashCode*397) ^ IsComplete.GetHashCode();
                hashCode = (hashCode*397) ^ (WinningTeam != null ? WinningTeam.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ IsSimulatedGame.GetHashCode();
                hashCode = (hashCode*397) ^ CreatedDate.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the team1 identifier.
        /// </summary>
        /// <value>
        /// The team1 identifier.
        /// </value>
        public Team Team1 { get; set; }

        /// <summary>
        /// Gets or sets the team2 identifier.
        /// </summary>
        /// <value>
        /// The team2 identifier.
        /// </value>
        public Team Team2 { get; set; }

        /// <summary>
        /// Gets or sets the state of the game.
        /// </summary>
        /// <value>
        /// The state of the game.
        /// </value>
        public GameState GameState { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is complete.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is complete; otherwise, <c>false</c>.
        /// </value>
        public bool IsComplete { get; set; }

        /// <summary>
        /// Gets or sets the winning team.
        /// </summary>
        /// <value>
        /// The winning team.
        /// </value>
        public string WinningTeam { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is simulated game.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is simulated game; otherwise, <c>false</c>.
        /// </value>
        public bool IsSimulatedGame { get; set; }


        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        public DateTime CreatedDate { get; set; }
    }
}
