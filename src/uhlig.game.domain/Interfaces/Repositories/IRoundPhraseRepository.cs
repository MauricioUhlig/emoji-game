using uhlig.game.domain.Entities;
using uhlig.game.domain.ViewModels.Round;

namespace uhlig.game.domain.Interfaces.Repositories
{
    public interface IRoundPhraseRepository : IBaseRepository<RoundPhraseVotesEntity>
    {
        public IEnumerable<RoundVotesViewModel> GetAllPhraseByRoundId(Guid roundId);
        public Guid GetPlayerIdByPhraseId(Guid id);
    }

}