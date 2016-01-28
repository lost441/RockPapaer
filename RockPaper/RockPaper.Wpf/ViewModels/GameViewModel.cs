
using RockPaper.Wpf.Properties;

namespace RockPaper.Wpf.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using RockPaper.Wpf.Common;
    using RockPaper.Wpf.Models;
    using RockPaper.Wpf.Providers;

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
        /// The registration result
        /// </summary>
        private string registrationResult;

        /// <summary>
        /// The hand
        /// </summary>
        private string hand;

        /// <summary>
        /// The game state
        /// </summary>
        private string gameState;

        /// <summary>
        /// The registered team name
        /// </summary>
        private Team team;

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
        /// The is rest call
        /// </summary>
        private bool isRestCall;

        /// <summary>
        /// The is my turn
        /// </summary>
        private bool isMyTurn;

        /// <summary>
        /// The is registration enabled
        /// </summary>
        private bool isRegistrationEnabled;

        /// <summary>
        /// The game
        /// </summary>
        private Game game;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameViewModel"/> class.
        /// </summary>
        public GameViewModel()
        {
            this.EnableRegistration = true;
            this.GameResults = new ObservableCollection<Round>();
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
        /// Gets or sets the hand.
        /// </summary>
        /// <value>
        /// The hand.
        /// </value>
        public string Hand
        {
            get { return this.hand; }
            set { this.hand = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Gets or sets the team.
        /// </summary>
        /// <value>
        /// The team.
        /// </value>
        public Team Team
        {
            get { return this.team; }
            set { this.team = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Gets or sets the registration result.
        /// </summary>
        /// <value>
        /// The registration result.
        /// </value>
        public string RegistrationResult
        {
            get { return this.registrationResult; }
            set { this.registrationResult = value; OnPropertyChanged(); }
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
            set 
            { 
                this.isRegistered = value;
                this.EnableRegistration = !this.isRegistered;
                OnPropertyChanged(); 
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [enable registration].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable registration]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableRegistration
        {
            private set { this.isRegistrationEnabled = value; OnPropertyChanged(); }
            get { return this.isRegistrationEnabled; }
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
        /// Gets or sets a value indicating whether this instance is rest call.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is rest call; otherwise, <c>false</c>.
        /// </value>
        public bool IsRestCall
        {
            get { return this.isRestCall; }
            set { this.isRestCall = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is my turn.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is my turn; otherwise, <c>false</c>.
        /// </value>
        public bool IsMyTurn
        {
            get { return this.isMyTurn; }
            set { this.isMyTurn = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Gets or sets the state of the game.
        /// </summary>
        /// <value>
        /// The state of the game.
        /// </value>
        public string GameState
        {
            get { return this.gameState; }
            set { this.gameState = value; OnPropertyChanged(); }
        }

        private string competingTeam;
        public string CompetingTeam
        {
            get { return this.competingTeam; }
            set { this.competingTeam = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// The game results
        /// </summary>
        private ObservableCollection<Round> gameResults;

        /// <summary>
        /// Gets a value indicating whether [play against simulator].
        /// </summary>
        /// <value>
        /// <c>true</c> if [play against simulator]; otherwise, <c>false</c>.
        /// </value>
        private bool PlayAgainstSimulator
        {
            get { return Settings.Default.PlayAgainstSimulator; }
        }

        /// <summary>
        /// Gets the game results.
        /// </summary>
        /// <value>
        /// The game results.
        /// </value>
        public ObservableCollection<Round> GameResults 
        { 
            get { return this.gameResults; }
            private set { this.gameResults = value; OnPropertyChanged(); } 
        }

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
            var provider = new GameProvider(this.IsRestCall);
            if (string.IsNullOrWhiteSpace(this.TeamNameToRegister))
            {
                RegistrationResult = string.Format("Enter team name");
                return;
            }

            var getResponse = provider.GetTeamByTeamName(this.TeamNameToRegister);
            if (getResponse.Data != null)
            {
                Team = getResponse.Data;
                RegistrationResult = string.Format("Team found");
                IsRegistered = true;
                return;
            }

            var registerResponse = provider.RegisterTeam(this.TeamNameToRegister);
            if (registerResponse.Data != null)
            {
                IsRegistered = true;
                RegistrationResult = string.Format("Team registered successfully");
                Team = registerResponse.Data;
                return;
            }

            RegistrationResult = string.Format("Error: Could not register team");
            IsRegistered = false;
        }

        /// <summary>
        /// Joins the game.
        /// </summary>
        private void JoinGame()
        {
            var provider = new GameProvider(this.IsRestCall);
            var result = provider.GetNextAvailableGame(this.Team.Id, this.PlayAgainstSimulator);
            if (!result.IsSuccessfull)
            {
                throw new ApplicationException("No game");
            }

            var gameResult = provider.GetGamebyGameId(result.Data);
            if (!gameResult.IsSuccessfull)
            {
                throw new ApplicationException("No game");
            }
                        
            this.game = gameResult.Data;
            this.IsActive = true;
            this.GameState = this.game != null ? this.game.GameState: string.Empty;
            this.CompetingTeam = this.game != null 
                ? (this.game.TeamName1 == this.Team.TeamName 
                    ? this.game.TeamName2 
                    : this.game.TeamName1)
                : string.Empty;
        }

        /// <summary>
        /// Gets the game results.
        /// </summary>
        private void GetGameResults()
        {
            var provider = new GameProvider(this.IsRestCall);
            var results = provider.GetCompletedRoundByGameId(this.game.Id);
            this.GameResults = new ObservableCollection<Round>(results);
        }

        /// <summary>
        /// Plays the hand.
        /// </summary>
        private void PlayHand()
        {
            var provider = new GameProvider(this.IsRestCall);
            this.Hand = "Rock";
            var selectedHand = this.Hand.ToEnum<Hand>();
            provider.PlayHand(this.game.Id, this.Team.Id, selectedHand);
            this.GetGameResults();
            this.CheckTurn();
        }

        /// <summary>
        /// Checks the turn.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private void CheckTurn()
        {
            var provider = new GameProvider(this.IsRestCall);
            var result = provider.IsItMyTurn(this.game.Id, this.Team.Id);
            if (!result.IsSuccessfull)
            {
                throw new ApplicationException("No game");
            }
            this.IsMyTurn = result.Data;
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
