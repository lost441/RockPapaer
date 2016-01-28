
namespace RockPaper.Web.Models
{
    using Contracts.Providers;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class GameResult.
    /// </summary>
    public class GameResult  : IEquatable<GameResult>, IComparable<GameResult>
    {
        public Game Game { get; set; }
        public List<Round> Rounds { get; set; }
        public Round LastRound { get; set; }
        public int Team1WinsCount { get; set; }
        public int Team2WinsCount { get; set; }
        public int DrawsCount { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GameResult) obj);
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other" /> parameter.Zero This object is equal to <paramref name="other" />. Greater than zero This object is greater than <paramref name="other" />.</returns>
        public int CompareTo(GameResult other)
        {
            if (other == null)
            {
                return 1;
            }

            return ((int)this.Game.GameState) - ((int)other.Game.GameState);

        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
        public bool Equals(GameResult other)
        {
            return Equals(Game, other.Game) && Equals(Rounds, other.Rounds) && Equals(LastRound, other.LastRound) && Team1WinsCount == other.Team1WinsCount && Team2WinsCount == other.Team2WinsCount && DrawsCount == other.DrawsCount;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Game != null ? Game.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Rounds != null ? Rounds.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (LastRound != null ? LastRound.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ Team1WinsCount;
                hashCode = (hashCode*397) ^ Team2WinsCount;
                hashCode = (hashCode*397) ^ DrawsCount;
                return hashCode;
            }
        }
    }




}