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
        private readonly IRoundPhraseRepository _roundPhraseRepository;
        public RoundService(
                IEmojiService emojiService,
                IBaseRepository<RoundEntity> roundRepository,
                IBaseRepository<RoundPlayerEntity> roundPlayerRepository,
                IBaseRepository<RoundPlayerPhraseEntity> roundPlayerPhraseRepository,
                IBaseRepository<PlayerEntity> playerRepository,
                IRoundPhraseRepository roundPhraseRepository
            )
        {
            _emojiService = emojiService;
            _roundRepository = roundRepository;
            _roundPlayerRepository = roundPlayerRepository;
            _roundPlayerPhraseRepository = roundPlayerPhraseRepository;
            _playerRepository = playerRepository;
            _roundPhraseRepository = roundPhraseRepository;
        }

        public RoundResponseViewModel CreateNewRoundByRoomId(Guid roomId)
        {
            var round = new RoundEntity(roomId, _emojiService.GetEmojisString(4), 60);
            _roundRepository.Insert(round);
            return new RoundResponseViewModel(round);
        }

        public IEnumerable<RoundResponseViewModel> GetAllRoundsByRoomId(Guid roomId)
        {
            var roundEntityList = _roundRepository.GetByExpression(x => x.RoomId == roomId);
            if (roundEntityList == null)
                throw new KeyNotFoundException();

            var result = new List<RoundResponseViewModel>();
            foreach (var item in roundEntityList)
            {
                result.Add(new RoundResponseViewModel(item.Id, item.RoomId, item.Emojis, item.StartAt, item.TotalSeconds));
            }
            return result;
        }

        public RoundResponseViewModel GetLastRoundByRoomId(Guid roomId)
        {
            var round = _roundRepository.GetByExpression(x => x.RoomId == roomId)?.OrderByDescending(o => o.StartAt).FirstOrDefault();
            if (round == null)
                throw new ArgumentNullException("Nenhuma rodada encontrada para sua sala");

            return new RoundResponseViewModel(round);
        }

        public JoinRoundResponseViewModel JoinRound(Guid roundId, Guid playerId)
        {
            if (!_roundRepository.Exists(roundId))
                throw new ArgumentException("Rodada não encontrada!");

            if (!_playerRepository.Exists(playerId))
                throw new ArgumentException("Player não encontrado!");

            var roundPlayer = new RoundPlayerEntity(roundId, playerId);
            _roundPlayerRepository.Insert(roundPlayer);

            return new JoinRoundResponseViewModel() { Success = true };
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
            var round = _roundRepository.GetById(id);
            if (round == null)
                throw new ArgumentException("Rodada não encontrada!");

            var phrases = _roundPhraseRepository.GetAllPhraseByRoundId(id);
            if (phrases == null)
                throw new ArgumentException("Nenhuma frase encontrada na rodada!");

            var playerPhrases = new List<PlayerPhraseResponseViewModel>();
            foreach (var phrase in phrases)
            {

                var player = _playerRepository.GetById(phrase.PlayerId);
                if (player == null)
                    throw new ArgumentNullException();

                // TODO: Implementar pontuações
                var playerPhrase = new PlayerPhraseResponseViewModel(player.Name, phrase.Phrase, phrase.Votes, player.Score);
                playerPhrases.Add(playerPhrase);

            }

            return new RoundResultResponseViewModel(round, playerPhrases);
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

        public bool Vote(Guid voterId, Guid phraseId)
        {
            var phrase = _roundPlayerPhraseRepository.GetById(phraseId);
            if (phrase == null)
                throw new KeyNotFoundException();

            var playerId = _roundPhraseRepository.GetPlayerIdByPhraseId(phraseId);

            var player = _playerRepository.GetById(playerId);
            if (player == null)
                throw new KeyNotFoundException();

            player.AddScore(1);
            _playerRepository.Update(player);

            var vote = new RoundPhraseVotesEntity(phraseId, voterId);
            _roundPhraseRepository.Insert(vote);

            return true;
        }
    }
}