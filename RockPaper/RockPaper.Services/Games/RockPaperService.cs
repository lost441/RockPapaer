
namespace RockPaper.Services.Games
{
    using System;
    using Contracts.Response;
    using Providers;
    
    /// <summary>
    /// Dog Service
    /// </summary>
    public class RockPaperService : IRockPaperService
    {
        /// <summary>
        /// Finds a game.
        /// </summary>
        /// <param name="teamId">The team identifier.</param>
        /// <returns>The next available game</returns>
        public ResponseItem<Guid> GetNextAvailableGame(Guid teamId)
        {
            var provider = new GameProvider();
            var gameId = provider.GetNextAvailableGame(teamId);

            return new ResponseItem<Guid>(ResultCodeEnum.Success)
            {
                Data = gameId
            };
        }

        /// <summary>
        /// Determines whether [is it my turn] [the specified game identifier].
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="teamId">The team identifier.</param>
        /// <returns>A bool indicating if its the teams turn</returns>
        public ResponseItem<bool> IsItMyTurn(Guid gameId, Guid teamId)
        {
            var provider = new GameProvider();
            var isMyTurn = provider.IsItMyTurn(gameId, teamId);
            
            return new ResponseItem<bool>(ResultCodeEnum.Success)
            {
                Data = isMyTurn
            };
        }
    }
}
