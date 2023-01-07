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
        private readonly IBaseRepository<RoundPlayerEntity> _roundPlayerRepository;
        private readonly IBaseRepository<RoundPlayerPhraseEntity> _roundPlayerPhraseRepository;
        private readonly IBaseRepository<PlayerEntity> _playerRepository;

        public RoundService(
                IEmojiService emojiService,
                IBaseRepository<RoundEntity> roundRepository,
                IBaseRepository<RoundPlayerEntity> roundPlayerRepository,
                IBaseRepository<RoundPlayerPhraseEntity> roundPlayerPhraseRepository,
                IBaseRepository<PlayerEntity> playerRepository
            )
        {
            _emojiService = emojiService;
            _roundRepository = roundRepository;
            _roundPlayerRepository = roundPlayerRepository;
            _roundPlayerPhraseRepository = roundPlayerPhraseRepository;
            _playerRepository = playerRepository;
        }

        public RoundResponseViewModel CreateNewRoundByRoomId(Guid roomId)
        {
            var round = new RoundEntity(roomId, _emojiService.GetEmojisString(4), 60);
            _roundRepository.Insert(round);
            return new RoundResponseViewModel(round);
        }

        public RoundListResponseViewModel GetAllRoundsByRoomId(Guid roomId)
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

        public RoundPhrasesResponseViewModel RoundPhrases(Guid id)
        {
            var round = _roundRepository.GetById(id);
            if (round == null)
                throw new ArgumentException("Rodada não encontrada!");


            var roundPlayers = _roundPlayerRepository.GetByExpression(x => x.RoundId == id);

            if (roundPlayers == null || roundPlayers.Count() == 0)
                throw new ArgumentException("Não existe players nesta rodada!");

            var playerPhrases = new List<PlayerPhraseResponseViewModel>();
            foreach (var roundPlayer in roundPlayers)
            {
                var phrase = _roundPlayerPhraseRepository.GetByExpression(x => x.RoundPlayerId == roundPlayer.Id)?.FirstOrDefault();
                if (phrase != null)
                {
                    var player = _playerRepository.GetById(roundPlayer.PlayerId);
                    var playerPhrase = new PlayerPhraseResponseViewModel(player?.Name ?? "<Sem Nome>", phrase.Phrase);
                    playerPhrases.Add(playerPhrase);
                }
            }
            
            return new RoundPhrasesResponseViewModel(round, playerPhrases);
        }

        public RoundResultResponseViewModel RoundResult(Guid id)
        {
            throw new NotImplementedException();
        }

        public SubmitResponseViewModel Submit(NewPhraseRequestViewModel submit)
        {
            var roundPlayer = _roundPlayerRepository.GetByExpression(x => x.PlayerId == submit.PlayerId && x.RoundId == submit.RoundId)?
                .FirstOrDefault();
            if (roundPlayer == null)
                return new SubmitResponseViewModel() { Success = false, Error = "Você não está participando desta rodada" };

            var round = _roundRepository.GetById(submit.RoundId);
            if (round == null) return new SubmitResponseViewModel() { Success = false, Error = "Rodada não encontrada" };

            if (round.StartAt < DateTime.UtcNow.AddSeconds(-round.TotalSeconds))
                return new SubmitResponseViewModel() { Success = false, Error = "O tempo da rodada já finalizou" };

            var roundPlayerPhrase = new RoundPlayerPhraseEntity(roundPlayer.Id, submit.Phrase);
            _roundPlayerPhraseRepository.Insert(roundPlayerPhrase);

            return new SubmitResponseViewModel() { Success = true };
        }
    }
}