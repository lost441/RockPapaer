namespace RockPaper.Wpf.Models
{
    /// <summary>
    /// The results class.
    /// </summary>
    public class GameResult 
    {
        /// <summary>
        /// Gets or sets the round.
        /// </summary>
        /// <value>
        /// The round.
        /// </value>
        public int Round { get; set; }

        /// <summary>
        /// Gets or sets my hand.
        /// </summary>
        /// <value>
        /// My hand.
        /// </value>
        public string MyHand{ get; set; }

        /// <summary>
        /// Gets or sets the opponents hand.
        /// </summary>
        /// <value>
        /// The opponents hand.
        /// </value>
        public string OpponentsHand { get; set; }

        /// <summary>
        /// Gets or sets the winning team.
        /// </summary>
        /// <value>
        /// The winning team.
        /// </value>
        public string WinningTeam { get; set; }
    }
}
