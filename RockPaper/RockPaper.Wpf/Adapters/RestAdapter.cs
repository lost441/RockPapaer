using RockPaper.Wpf.Common;
using RockPaper.Wpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaper.Wpf.Adapters
{
    public class RestAdapter : IAdapter
    {
        public Result<Guid> GetNextAvailableGame(Guid teamId, bool? useSimulator)
        {
            throw new NotImplementedException();
        }

        public Result<bool> IsItMyTurn(Guid gameId, Guid teamId)
        {
            throw new NotImplementedException();
        }

        public Result<OperationOutcome> PlayHand(Guid gameId, Guid teamId, Hand hand)
        {
            throw new NotImplementedException();
        }

        public Result<Game> GetGamebyGameId(Guid gameId)
        {
            throw new NotImplementedException();
        }

        public Result<Team> RegisterTeam(string teamName)
        {
            throw new NotImplementedException();
        }

        public Result<Team> GetTeamByTeamName(string teamName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Round> GetCompletedRoundByGameId(Guid gameId)
        {
            throw new NotImplementedException();
        }        
    }
}
