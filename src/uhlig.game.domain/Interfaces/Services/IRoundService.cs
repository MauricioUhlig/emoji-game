
using uhlig.game.domain.ViewModels.Round.Request;
using uhlig.game.domain.ViewModels.Round.Response;

namespace uhlig.game.domain.Interfaces.Services
{
    public interface IRoundService
    {
        public RoundResponseViewModel GetLastRoundByRoomId(Guid roomId);
        public RoundResponseViewModel CreateNewRoundByRoomId(Guid roomId);
        public string GetAllRoundsByRoomId(Guid roomId);
        public string RoundResult(Guid id);
        public string Submit(NewPhraseRequestViewModel submit);
    }
}