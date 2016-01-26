
namespace RockPaper.Wpf.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using RockPaper.Wpf.Common;
    using RockPaper.Wpf.Models;

    /// <summary>
    /// Game view model class.
    /// </summary>
    public class GameViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The team name to register
        /// </summary>
        private string teamNameToRegister;

        /// <summary>
        /// The registered team name
        /// </summary>
        private string registeredTeamName;

        /// <summary>
        /// The is active
        /// </summary>
        private bool isActive;

        /// <summary>
        /// The is registered
        /// </summary>
        private bool isRegistered;

        /// <summary>
        /// The is automatic refresh
        /// </summary>
        private bool isAutoRefresh;

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
        /// Gets or sets the team name to register.
        /// </summary>
        /// <value>
        /// The team name to register.
        /// </value>
        public string TeamNameToRegister
        {
            get { return this.teamNameToRegister; }
            set { this.teamNameToRegister = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Gets or sets the name of the registered team.
        /// </summary>
        /// <value>
        /// The name of the registered team.
        /// </value>
        public string RegisteredTeamName
        {
            get { return this.registeredTeamName; }
            set { this.registeredTeamName = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive
        {
            get { return this.isActive; }
            set { this.isActive = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is registered.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is registered; otherwise, <c>false</c>.
        /// </value>
        public bool IsRegistered
        {
            get { return this.isRegistered; }
            set { this.isRegistered = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is automatic refresh.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is automatic refresh; otherwise, <c>false</c>.
        /// </value>
        public bool IsAutoRefresh
        {
            get { return this.isAutoRefresh; }
            set { this.isAutoRefresh = value; OnPropertyChanged(); }
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
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

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

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;

            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
