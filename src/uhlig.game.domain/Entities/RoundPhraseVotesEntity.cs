namespace uhlig.game.domain.Entities
{
    public class RoundPhraseVotesEntity : BaseEntity
    {
        public Guid RoundPlayerPhraseId { get; set; }
        public Guid PlayerId { get; set; }

        public RoundPlayerPhraseEntity? RoundPlayerPhrase { get; set; }
        public RoundPhraseVotesEntity(Guid roundPlayerPhraseId, Guid playerId) : base()
        {
            RoundPlayerPhraseId = roundPlayerPhraseId;
            PlayerId = playerId;
        }
        public RoundPhraseVotesEntity(Guid id, Guid roundPlayerPhraseId, Guid playerId) : base(id)
        {
            RoundPlayerPhraseId = roundPlayerPhraseId;
            PlayerId = playerId;
        }
    }
}