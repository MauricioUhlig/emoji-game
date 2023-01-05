using uhlig.game.domain.Interfaces.Services;
using uhlig.game.domain.ViewModels.Round.Request;
using uhlig.game.domain.ViewModels.Round.Response;

namespace uhlig.game.services.Services
{
    public class RoundService : IRoundService
    {
        public string CreateNewRoundByRoomId(Guid roomId)
        {
            throw new NotImplementedException();
        }

        public string GetAllRoundsByRoomId(Guid roomId)
        {
            throw new NotImplementedException();
        }

        public RoundResponseViewModel GetLastRoundByRoomId(Guid roomId)
        {
            throw new NotImplementedException();
        }

        public string Submit(NewPhraseRequestViewModel submit)
        {
            throw new NotImplementedException();
        }

        public string RoundResult(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}