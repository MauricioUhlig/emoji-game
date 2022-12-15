namespace uhlig.game.domain.Entities
{
    public class RoundPlayerPhraseEntity
    {
        public Guid Id { get; private set; }
        public Guid RoundId { get; private set; }
        public Guid PlayerId { get; private set; }
        public DateTime When { get; private set; }
        public string Phrase { get; set; }

        public RoundPlayerPhraseEntity(Guid roundId, Guid playerId, string phrase)
        {
            Id = Guid.NewGuid();
            
            RoundId = roundId;
            PlayerId = playerId;
            Phrase = phrase;

            When = DateTime.UtcNow;
        }
    }
}