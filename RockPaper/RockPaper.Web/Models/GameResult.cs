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
    public class GameResult
    {
        public Game Game { get; set; }
        public List<Round> Rounds { get; set; }
        public Round LastRound { get; set; }
        public int Team1WinsCount { get; set; }
        public int Team2WinsCount { get; set; }
        public int DrawsCount { get; set; }
        
    }
}