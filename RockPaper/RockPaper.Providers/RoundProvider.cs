// <copyright file="RoundProvider.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

using Contracts.Exceptions;

namespace RockPaper.Providers
{
    using AdapterImplentations;
    using Contracts;
    using Contracts.Common;
    using System;
    using System.Collections.Generic;
    using Contracts.Providers;
    using System.Linq;

    /// <summary>
    /// The round provider.
    /// </summary>
    public class RoundProvider : IRoundProvider
    {
        /// <summary>
        /// Submits the hand.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <param name="teamId">The team identifier.</param>
        /// <param name="gameId">The game identifier.</param>
        /// <returns></returns>
        public OperationOutcome SumbitHand(Hand hand, Guid teamId, Guid gameId)
        {
            var gameAdapter = AdapterFactory.GetGameAdapter();
            var game = gameAdapter.GetGameById(gameId);

            if (game == null)
            {
                throw new BadRequestException();
            }

            var response = this.SubmitHandGeneric(hand, teamId, game);

            if (!game.IsSimulatedGame)
            {
                return response;
            }

            gameAdapter = AdapterFactory.GetGameAdapter();
            game = gameAdapter.GetGameById(gameId);

            if (!game.IsComplete)
            {
                this.SumbitSimulatedHand(game);
            }

            return response;
        }

        /// <summary>
        /// Sumbits the simulated hand.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <returns>The opperation outcome</returns>
        public OperationOutcome SumbitSimulatedHand(Game game)
        {
            var teamAdapter = AdapterFactory.GetTeamAdapter();

            var randomHand = this.GetRandomHand();
            var team = teamAdapter.GetTeamByName(Properties.Settings.Default.SimulatorTeamName);

            return this.SubmitHandGeneric(randomHand, team.Id, game);
        }

        /// <summary>
        /// Determines the winner.
        /// </summary>
        /// <param name="teamOneHane">The team one hane.</param>
        /// <param name="teamTwoHand">The team two hand.</param>
        /// <returns>The winner</returns>
        private RoundResult DetermineWinner(Hand? teamOneHane, Hand? teamTwoHand)
        {
            var team2Hand = teamTwoHand;
            if (team2Hand == Hand.None)
            {
                return RoundResult.Team1Won;
            }

            switch (teamOneHane)
            {
                case Hand.Rock:
                    if (team2Hand == Hand.Rock)
                    {
                        return RoundResult.Draw;
                    }

                    if (team2Hand == Hand.Paper)
                    {
                        return RoundResult.Team2Won;
                    }

                    if (team2Hand == Hand.Scissor)
                    {
                        return RoundResult.Team1Won;
                    }

                    if (team2Hand == Hand.Lizard)
                    {
                        return RoundResult.Team1Won;
                    }

                    if (team2Hand == Hand.Spock)
                    {
                        return RoundResult.Team2Won;
                    }

                    break;

                case Hand.Paper:
                    if (team2Hand == Hand.Rock)
                    {
                        return RoundResult.Team1Won;
                    }

                    if (team2Hand == Hand.Paper)
                    {
                        return RoundResult.Draw;
                    }

                    if (team2Hand == Hand.Scissor)
                    {
                        return RoundResult.Team2Won;
                    }

                    if (team2Hand == Hand.Lizard)
                    {
                        return RoundResult.Team2Won;
                    }

                    if (team2Hand == Hand.Spock)
                    {
                        return RoundResult.Team1Won;
                    }
                    break;

                case Hand.Scissor:
                    if (team2Hand == Hand.Rock)
                    {
                        return RoundResult.Team2Won;
                    }

                    if (team2Hand == Hand.Paper)
                    {
                        return RoundResult.Team1Won;
                    }

                    if (team2Hand == Hand.Scissor)
                    {
                        return RoundResult.Draw;
                    }

                    if (team2Hand == Hand.Lizard)
                    {
                        return RoundResult.Team1Won;
                    }

                    if (team2Hand == Hand.Spock)
                    {
                        return RoundResult.Team2Won;
                    }
                    break;

                case Hand.Lizard:
                    if (team2Hand == Hand.Rock)
                    {
                        return RoundResult.Team2Won;
                    }

                    if (team2Hand == Hand.Paper)
                    {
                        return RoundResult.Team1Won;
                    }

                    if (team2Hand == Hand.Scissor)
                    {
                        return RoundResult.Team2Won;
                    }

                    if (team2Hand == Hand.Lizard)
                    {
                        return RoundResult.Draw;
                    }

                    if (team2Hand == Hand.Spock)
                    {
                        return RoundResult.Team1Won;
                    }
                    break;

                case Hand.Spock:
                    if (team2Hand == Hand.Rock)
                    {
                        return RoundResult.Team1Won;
                    }

                    if (team2Hand == Hand.Paper)
                    {
                        return RoundResult.Team2Won;
                    }

                    if (team2Hand == Hand.Scissor)
                    {
                        return RoundResult.Team1Won;
                    }

                    if (team2Hand == Hand.Lizard)
                    {
                        return RoundResult.Team2Won;
                    }

                    if (team2Hand == Hand.Spock)
                    {
                        return RoundResult.Draw;
                    }
                    break;

                case Hand.None:
                    return RoundResult.Team2Won;
                default:
                    return RoundResult.Draw;
            }

            return RoundResult.Draw;
        }
        
        /// <summary>
        /// Gets the completed round by game identifier.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns></returns>
        public IEnumerable<Round> GetCompletedRoundByGameId(Guid gameId)
        {
            var adapter = new RoundAdapter();
            return adapter.GetCompletedRoundByGameId(gameId).OrderBy(x => x.SequenceNumber);
        }

        /// <summary>
        /// Submits the hand generic.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <param name="teamId">The team identifier.</param>
        /// <param name="game">The game.</param>
        /// <returns></returns>
        private OperationOutcome SubmitHandGeneric(Hand hand, Guid teamId, Game game)
        {
            System.Threading.Thread.Sleep(Properties.Settings.Default.ThinkTimeInMiliSeconds);
            
            var outcome = new OperationOutcome { Result = false, Error = "" };
            var gameAdapter = new GameAdapter();
            var roundAdapter = new RoundAdapter();

            var gameProvider = new GameProvider();

            if (game.GameState == GameState.Complete || game.GameState == GameState.WaitingForPlayers)
            {
                outcome.Error = "Game not in playable state.";
                return outcome;
            }

            if (game.GameState == GameState.Player1Hand)
            {
                if (game.Team1.Id == teamId)
                {
                    var round = new Round
                    {
                        GameId = game.Id,
                        Team1Hand = hand,
                        SequenceNumber = roundAdapter.GetNextRoundNumber(game.Id)
                    };

                    roundAdapter.CreateRound(round);
                    gameAdapter.UpdateGameState(GameState.Player2Hand, game.Id);
                    outcome.Result = true;
                }
                else
                {
                    outcome.Error = "Not team 1's turn.";
                    return outcome;
                }
            }
            else if(game.GameState == GameState.Player2Hand)
            {
                if (game.Team2.Id == teamId)
                {
                    var round = roundAdapter.GetRoundForPlayerTwo(game.Id);
                    round.Team2Hand = hand;
                    round.Result = DetermineWinner(round.Team1Hand , round.Team2Hand);
                    roundAdapter.UpdateRound(round);

                    gameAdapter.UpdateGameState(GameState.Player1Hand, game.Id);
                }
                else
                {
                    outcome.Error = "Not team 2's turn.";
                    return outcome;
                }
            }

            roundAdapter.SaveChanges();
            gameAdapter.SaveChanges();

            gameProvider.CompleteRound(game.Id);

            outcome.Result = true;
            return outcome;
        }

        /// <summary>
        /// Gets the random hand.
        /// </summary>
        /// <returns></returns>
        private Hand GetRandomHand()
        {
            var rnd = new Random();
            var handNumber = rnd.Next(1, 5);

            return (Hand)handNumber;
        }
    }
}
