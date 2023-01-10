
using uhlig.game.domain.ViewModels.Round.Request;
using uhlig.game.domain.ViewModels.Round.Response;

namespace uhlig.game.domain.Interfaces.Services
{
    public interface IRoundService
    {
        public RoundResponseViewModel GetLastRoundByRoomId(Guid roomId);
        public RoundResponseViewModel CreateNewRoundByRoomId(Guid roomId);
        public IEnumerable<RoundResponseViewModel> GetAllRoundsByRoomId(Guid roomId);
        public JoinRoundResponseViewModel JoinRound(Guid roundId, Guid playerId);
        public RoundPhrasesResponseViewModel RoundPhrases(Guid id);
        public RoundResultResponseViewModel RoundResult(Guid id);
        public SubmitResponseViewModel Submit(NewPhraseRequestViewModel submit);
        public bool Vote(Guid voterId, Guid phraseId);
    }
}