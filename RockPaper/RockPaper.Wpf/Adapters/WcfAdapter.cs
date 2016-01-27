
namespace RockPaper.Wpf.Adapters
{
    using System;
    using AutoMapper;
    using RockPaper.Wpf.Common;
    using RockPaper.Wpf.Models;

    /// <summary>
    /// WCF implementation of adapter.
    /// </summary>
    class WcfAdapter : IAdapter
    {
        /// <summary>
        /// The client
        /// </summary>
        private readonly RockPaperServiceReference.RockPaperServiceClient client = new RockPaperServiceReference.RockPaperServiceClient();

        /// <summary>
        /// Gets the next available game.
        /// </summary>
        /// <param name="teamId">The team identifier.</param>
        /// <returns>
        /// Game identifier
        /// </returns>
        public Result<Guid> GetNextAvailableGame(Guid teamId)
        {
            var result = client.GetNextAvailableGame(teamId);
            Mapper.CreateMap<Result<Guid>, RockPaperServiceReference.ResponseItemOfguid>();
            return Mapper.Map<Result<Guid>>(result);
        }

        /// <summary>
        /// Determines whether [is it my turn] [the specified game identifier].
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="teamId">The team identifier.</param>
        /// <returns>
        /// A bool indicating if its the teams turn.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Result<bool> IsItMyTurn(Guid gameId, Guid teamId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Plays the hand.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="teamId">The team identifier.</param>
        /// <param name="hand">The hand.</param>
        /// <returns>
        /// The outcome
        /// </returns>
        public Result<OperationOutcome> PlayHand(Guid gameId, Guid teamId, Hand hand)
        {
            Mapper.CreateMap<RockPaperServiceReference.Hand, Hand>();
            var result = client.PlayHand(gameId, teamId, Mapper.Map<RockPaperServiceReference.Hand>(hand));
            Mapper.CreateMap<Result<OperationOutcome>, RockPaperServiceReference.ResponseItemOfOperationOutcome_ShMyOgxf>();
            return Mapper.Map<Result<OperationOutcome>>(result);
        }

        /// <summary>
        /// Gets the gameby game identifier.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns>
        /// The game
        /// </returns>
        public Result<Game> GetGamebyGameId(Guid gameId)
        {
            Mapper.CreateMap<RockPaperServiceReference.Hand, Hand>();
            var result = client.GetGamebyGameId(gameId);
            Mapper.CreateMap<Result<Game>, RockPaperServiceReference.ResponseItemOfGameiiBVlPgH>();
            return Mapper.Map<Result<Game>>(result);
        }

        /// <summary>
        /// Registers the team.
        /// </summary>
        /// <param name="teamName">Name of the team.</param>
        /// <returns>
        /// The team
        /// </returns>
        public Result<Team> RegisterTeam(string teamName)
        {
            var result = client.RegisterTeam(teamName);
            Mapper.CreateMap<Result<Team>, RockPaperServiceReference.ResponseItemOfTeamthdB4o0U>();
            return Mapper.Map<Result<Team>>(result);
        }

        /// <summary>
        /// Gets the name of the team by team.
        /// </summary>
        /// <param name="teamName">Name of the team.</param>
        /// <returns>
        /// The team
        /// </returns>
        public Result<Team> GetTeamByTeamName(string teamName)
        {
            var result = client.GetTeamByTeamName(teamName);
            Mapper.CreateMap<Result<Team>, RockPaperServiceReference.ResponseItemOfTeamthdB4o0U>();
            return Mapper.Map<Result<Team>>(result);
        }
    }
}
