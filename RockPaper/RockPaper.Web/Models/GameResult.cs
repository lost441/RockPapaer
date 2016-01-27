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



        public int CompareTo(GameResult other)
        {
            if (other == null)
            {
                return 1;
            }

            return ((int)this.Game.GameState) - ((int)other.Game.GameState);
        }


        public bool Equals(GameResult other)
        {
            if (other == null)
            {
                return false;
            }
            return this.Game.GameState == other.Game.GameState;
        }

        public override int GetHashCode()
        {
            return this.Game.GetHashCode();
        }
    }




}