// <copyright file="RoundProvider.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>
namespace RockPaper.Providers
{
    using RockPaper.AdapterImplentations;
    using RockPaper.Contracts;
    using RockPaper.Contracts.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The round provider.
    /// </summary>
    public class RoundProvider
    {
        /// <summary>
        /// Submits the hand.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <param name="TeamId">The team identifier.</param>
        /// <param name="GameId">The game identifier.</param>
        /// <returns></returns>
        public OperationOutcome SumbitHand(Hand hand, Guid TeamId, Guid GameId)
        {
            var outcome = new OperationOutcome { Result = false, Error = "" };
            var gameAdapter = new GameAdapter();
            var roundAdapter = new RoundAdapter();
            var game = gameAdapter.GetGameById(GameId);

            var gameProvider = new GameProvider();

            if (game.GameState == GameState.Complete || game.GameState == GameState.WaitingForPlayers)
            {
                outcome.Error = "Game not in playable state.";
                return outcome;
            }

            if (game.GameState == GameState.Player1Hand)
            {
                if (game.Team1.Id == TeamId)
                {
                    var round = new Round
                    {
                        GameId = GameId,
                        Team1Hand = hand,
                        SequenceNumber = roundAdapter.GetNextRoundNumber(GameId)
                    };

                    roundAdapter.CreateRound(round);
                    gameAdapter.UpdateGameState(GameState.Player2Hand, GameId);
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
                if (game.Team2.Id == TeamId)
                {
                    var round = roundAdapter.GetRoundForPlayerTwo(GameId);
                    round.Team2Hand = hand;
                    round.Result = DetermineWinner(round.Team1Hand , round.Team2Hand);
                    roundAdapter.UpdateRound(round);

                    gameAdapter.UpdateGameState(GameState.Player1Hand, GameId);
                }
                else
                {
                    outcome.Error = "Not team 2's turn.";
                    return outcome;
                }
            }

            roundAdapter.SaveChanges();
            gameAdapter.SaveChanges();

            gameProvider.GameProcesssing(GameId);

            outcome.Result = true;
            return outcome;
        }

        /// <summary>
        /// Determines the winner.
        /// </summary>
        /// <param name="round">The round.</param>
        /// <returns></returns>
        private RoundResult DetermineWinner(Hand? Hand1, Hand? Hand2)
        {
            var team2Hand = Hand2;
            if (team2Hand == Hand.None)
            {
                return RoundResult.Team1Won;
            }


            switch (Hand1)
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
    }
}
