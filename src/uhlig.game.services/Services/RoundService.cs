using uhlig.game.domain.Entities;
using uhlig.game.domain.Interfaces.Repositories;
using uhlig.game.domain.Interfaces.Services;
using uhlig.game.domain.ViewModels.Round.Request;
using uhlig.game.domain.ViewModels.Round.Response;

namespace uhlig.game.services.Services
{
    public class RoundService : IRoundService
    {
        private readonly IEmojiService _emojiService;
        private readonly IBaseRepository<RoundEntity> _roundRepository;
        public RoundService(IEmojiService emojiService, IBaseRepository<RoundEntity> roundRepository)
        {
            _emojiService = emojiService;
            _roundRepository = roundRepository;
        }
        public RoundResponseViewModel CreateNewRoundByRoomId(Guid roomId)
        {
            var round = new RoundEntity(roomId, _emojiService.GetEmojisString(4), 60);
            _roundRepository.Insert(round);
            return new RoundResponseViewModel(round);
        }

        public string GetAllRoundsByRoomId(Guid roomId)
        {
            throw new NotImplementedException();
        }

        public RoundResponseViewModel GetLastRoundByRoomId(Guid roomId)
        {
            var round = _roundRepository.GetByExpression(x => x.RoomId == roomId)?.OrderByDescending(o => o.StartAt).FirstOrDefault();
            if (round == null)
                throw new ArgumentNullException("Nenhuma rodada encontrada para sua sala");

            return new RoundResponseViewModel(round);
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