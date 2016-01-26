
namespace RockPaper.Wpf.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using RockPaper.Wpf.Common;
    using RockPaper.Wpf.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Game view model class.
    /// </summary>
    public class GameViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameViewModel"/> class.
        /// </summary>
        public GameViewModel()
        {
            //TODO: Remove list when done.
            var list = new List<GameResult>
            {
                new GameResult { Round = 1, MyHand = "Rock", OpponentsHand = "Paper", WinningTeam = "Them" },   
                new GameResult { Round = 2, MyHand = "Paper", OpponentsHand = "Rock", WinningTeam = "Me" },   
                new GameResult { Round = 3, MyHand = "Rock", OpponentsHand = "Scissor", WinningTeam = "Me" },   
            };
            this.GameResults = new ObservableCollection<GameResult>(list);
            this.RegisterTeamCommand = new Command(() => true, this.RegisterTeam);
            this.JoinTeamCommand = new Command(() => true, this.JoinGame);
            this.RefreshGameResultsCommand = new Command(() => true, this.GetGameResults);
            this.PlayHandCommand = new Command(() => true, this.PlayHand);
            this.CheckTurnCommand = new Command(() => true, this.CheckTurn);
        }

        /// <summary>
        /// Gets the game results.
        /// </summary>
        /// <value>
        /// The game results.
        /// </value>
        public ObservableCollection<GameResult> GameResults { get; private set; }

        /// <summary>
        /// Gets the register team command.
        /// </summary>
        /// <value>
        /// The register team command.
        /// </value>
        public Command RegisterTeamCommand { get; private set; }

        /// <summary>
        /// Gets the join team command.
        /// </summary>
        /// <value>
        /// The join team command.
        /// </value>
        public Command JoinTeamCommand { get; private set; }

        /// <summary>
        /// Gets the refresh game results command.
        /// </summary>
        /// <value>
        /// The refresh game results command.
        /// </value>
        public Command RefreshGameResultsCommand { get; private set; }

        /// <summary>
        /// Gets the play hand command.
        /// </summary>
        /// <value>
        /// The play hand command.
        /// </value>
        public Command PlayHandCommand { get; private set; }

        /// <summary>
        /// Gets the check turn command.
        /// </summary>
        /// <value>
        /// The check turn command.
        /// </value>
        public Command CheckTurnCommand { get; private set; }
        
        /// <summary>
        /// Registers the team.
        /// </summary>
        private void RegisterTeam()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Joins the game.
        /// </summary>
        private void JoinGame()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the game results.
        /// </summary>
        private void GetGameResults()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Plays the hand.
        /// </summary>
        private void PlayHand()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks the turn.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private void CheckTurn()
        {
            throw new NotImplementedException();
        }
    }
}
