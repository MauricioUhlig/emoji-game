using System.Linq;
using uhlig.game.domain.Entities;
using uhlig.game.domain.Interfaces.Repositories;
using uhlig.game.domain.ViewModels.Round;
using uhlig.game.infra.data.Context;

namespace uhlig.game.infra.data.Repositories
{
    public class RoundPhraseRepository : BaseRepository<RoundPhraseVotesEntity>, IRoundPhraseRepository
    {
        public RoundPhraseRepository(EmojiGameContext context) : base(context)
        {

        }
        public IEnumerable<RoundVotesViewModel> GetAllPhraseByRoundId(Guid roundId)
        {
            var result = (from rpp in _context.RoundPlayerPhrases
                          join rp in _context.RoundPlayer on rpp.RoundPlayerId equals rp.Id
                          join p in _context.Players on rp.PlayerId equals p.Id
                          join rpv in Set on rpp.Id equals rpv.RoundPlayerPhraseId into df_rpv
                          from x in df_rpv.DefaultIfEmpty()
                          group x by new { rp.RoundId, rpp.Phrase, rp.PlayerId, p.Name, p.Score } into rpv_grouped
                          where rpv_grouped.Key.RoundId == roundId
                          select new RoundVotesViewModel(
                              rpv_grouped.Key.PlayerId,
                              rpv_grouped.Key.Name,
                              rpv_grouped.Key.Score,
                              rpv_grouped.Key.Phrase,
                              rpv_grouped.Count(x => !x.Id.Equals(Guid.Empty))
                          ));
            return result.ToList();
        }
        public Guid GetPlayerIdByPhraseId(Guid id)
        {
            return (from rpp in _context.RoundPlayerPhrases
                    join rp in _context.RoundPlayer on rpp.RoundPlayerId equals rp.Id
                    where rpp.Id == id
                    select rp.PlayerId).FirstOrDefault();
        }
    }
}