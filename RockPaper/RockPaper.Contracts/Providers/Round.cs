// <copyright file="Round.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

namespace Contracts.Providers
{
    using System;
    using Common;

    /// <summary>
    /// The round class.
    /// </summary>
    public class Round
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        protected bool Equals(Round other)
        {
            return Id.Equals(other.Id) && GameId.Equals(other.GameId) && Team1Hand == other.Team1Hand && Team2Hand == other.Team2Hand && Result == other.Result && SequenceNumber == other.SequenceNumber;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Round) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode*397) ^ GameId.GetHashCode();
                hashCode = (hashCode*397) ^ Team1Hand.GetHashCode();
                hashCode = (hashCode*397) ^ Team2Hand.GetHashCode();
                hashCode = (hashCode*397) ^ (int) Result;
                hashCode = (hashCode*397) ^ SequenceNumber;
                return hashCode;
            }
        }

        /// <summary>
        /// Gets or sets the game identifier.
        /// </summary>
        /// <value>
        /// The game identifier.
        /// </value>
        public Guid GameId { get; set; }

        /// <summary>
        /// Gets or sets the team1 hand.
        /// </summary>
        /// <value>
        /// The team1 hand.
        /// </value>
        public Hand? Team1Hand { get; set; }

        /// <summary>
        /// Gets or sets the team2 hand.
        /// </summary>
        /// <value>
        /// The team2 hand.
        /// </value>
        public Hand? Team2Hand { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public RoundResult Result { get; set; }

        /// <summary>
        /// Gets or sets the sequence number.
        /// </summary>
        /// <value>
        /// The sequence number.
        /// </value>
        public int SequenceNumber { get; set; }
    }
}
