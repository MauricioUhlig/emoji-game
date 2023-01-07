using uhlig.game.domain.Entities;

namespace uhlig.game.domain.ViewModels.Round.Response
{
    public class RoundPhrasesResponseViewModel : RoundResponseViewModel
    {
        public IEnumerable<PlayerPhraseResponseViewModel> PlayerPhrases { get; set; }

        public RoundPhrasesResponseViewModel(
                RoundEntity round,
                IEnumerable<PlayerPhraseResponseViewModel> playerPhrases
            ) : base(round)
        {
            PlayerPhrases = playerPhrases;
        }
        public RoundPhrasesResponseViewModel(
                Guid id,
                Guid roomId,
                string emojis,
                DateTime startAt,
                byte totalSeconds,
                IEnumerable<PlayerPhraseResponseViewModel> playerPhrases
            ) : base(id, roomId, emojis, startAt, totalSeconds)
        {
            PlayerPhrases = playerPhrases;
        }
    }
}