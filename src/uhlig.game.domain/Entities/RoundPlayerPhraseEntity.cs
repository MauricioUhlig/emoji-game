namespace uhlig.game.domain.Entities
{
    public class RoundPlayerPhraseEntity : BaseEntity
    {
        public Guid RoundPlayerId { get; private set; }
        public DateTime When { get; private set; }
        public string Phrase { get; set; }

        public RoundPlayerEntity? RoundPlayer { get; set; }
        public IEnumerable<RoundPhraseVotesEntity>? RoundPhraseVotes { get; set; }

        public RoundPlayerPhraseEntity(Guid roundPlayerId, string phrase) : base()
        {
            RoundPlayerId = roundPlayerId;
            Phrase = phrase;

            When = DateTime.UtcNow;
        }
        public RoundPlayerPhraseEntity(Guid id, Guid roundPlayerId, string phrase, DateTime when) : base(id)
        {
            RoundPlayerId = roundPlayerId;
            Phrase = phrase;

            When = when;
        }
    }
}