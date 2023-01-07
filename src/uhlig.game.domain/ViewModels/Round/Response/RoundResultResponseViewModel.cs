using uhlig.game.domain.Entities;

namespace uhlig.game.domain.ViewModels.Round.Response
{
    public class RoundResultResponseViewModel : RoundPhrasesResponseViewModel
    {

        public RoundResultResponseViewModel(
                RoundEntity round,
                IEnumerable<PlayerPhraseResponseViewModel> playerPhrases
            ) : base(round, playerPhrases)
        { }
        public RoundResultResponseViewModel(
                Guid id,
                Guid roomId,
                string emojis,
                DateTime startAt,
                byte totalSeconds,
                IEnumerable<PlayerPhraseResponseViewModel> playerPhrases
            ) : base(id, roomId, emojis, startAt, totalSeconds, playerPhrases)
        { }
    }
}