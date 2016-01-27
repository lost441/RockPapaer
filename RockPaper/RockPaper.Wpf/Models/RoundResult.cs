using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaper.Wpf.Models
{
    public enum RoundResult
    {
        /// <summary>
        /// The not complete
        /// </summary>
        NotComplete = 0,

        /// <summary>
        /// The team1 won
        /// </summary>
        Team1Won = 1,

        /// <summary>
        /// The team2 won
        /// </summary>
        Team2Won = 2,

        /// <summary>
        /// The draw
        /// </summary>
        Draw = 3
    }
}
