namespace uhlig.game.domain.ViewModels.Round
{
    public class RoundVotesViewModel
    {
        public Guid PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int PlayerScore { get; set; }
        public string Phrase { get; set; }
        public int Votes { get; set; }


        public RoundVotesViewModel(Guid playerId, string playerName, int playerScore, string phrase, int votes)
        {
            PlayerId = playerId;
            PlayerName = playerName;
            PlayerScore = playerScore;
            Phrase = phrase;
            Votes = votes;
        }
    }
}