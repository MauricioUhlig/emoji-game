namespace uhlig.game.domain.ViewModels.Round.Response
{
    public class RoundListResponseViewModel
    {
        public IEnumerable<RoundResponseViewModel> Rounds { get; set; }
        public RoundListResponseViewModel(IEnumerable<RoundResponseViewModel> rounds)
        {
            Rounds = rounds;
        }
        public RoundListResponseViewModel()
        {
            Rounds = new List<RoundResponseViewModel>();
        }
    }
}