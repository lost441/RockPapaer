/// <summary>
/// The Models namespace.
/// </summary>
namespace RockPaper.Web.Models
{
    using Contracts.Providers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using RockPaper.Web.Extensions;


    /// <summary>
    /// Class GameResult.
    /// </summary>
    public class GameResult : IEquatable<GameResult>, IComparable<GameResult>
    {
        public Game Game { get; set; }
        public List<Round> Rounds { get; set; }
        public Round LastRound { get; set; }
        public int Team1WinsCount { get; set; }
        public int Team2WinsCount { get; set; }
        public int DrawsCount { get; set; }



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
            if (other == null)
            {
                return false;
            }
            return this.Game.GameState == other.Game.GameState;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return this.Game.GetHashCode();
        }
    }




}