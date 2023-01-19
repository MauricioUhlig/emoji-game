using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace uhlig.game.domain.ViewModels.Round.Request
{
    public class NewPhraseRequestViewModel
    {
        [Required]
        public Guid RoundId { get; private set; }
        [JsonIgnore]
        public Guid PlayerId { get; set; }

        [Required]
        public string Phrase { get; set; }

        public NewPhraseRequestViewModel(Guid roundId, Guid playerId, string phrase)
        {
            RoundId = roundId;
            PlayerId = playerId;
            Phrase = phrase;
        }
    }
}