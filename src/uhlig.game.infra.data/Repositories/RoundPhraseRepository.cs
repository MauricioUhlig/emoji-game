using System.Linq;
using uhlig.game.domain.Entities;
using uhlig.game.infra.data.Context;

namespace uhlig.game.infra.data.Repositories
{
    public class RoundPhraseRepository : BaseRepository<RoundPlayerPhraseEntity>
    {
        public RoundPhraseRepository(EmojiGameContext context) : base(context)
        {

        }
        public IEnumerable<object> GetAllPhraseByRoundId(Guid roundId)
        {
            var result = (from rpp in Set
                          join rp in _context.RoundPlayer on rpp.RoundPlayerId equals rp.Id
                          join p in _context.Players on rp.PlayerId equals p.Id
                          join rpv in _context.RoundPhraseVotes on rpp.Id equals rpv.RoundPlayerPhraseId into df_rpv
                          from x in df_rpv.DefaultIfEmpty()
                          group x by new { rp.RoundId, rpp.Phrase, rp.PlayerId, p.Name, p.Score } into rpv_grouped
                          where rpv_grouped.Key.RoundId == roundId
                          select new
                          {
                              Id = rpv_grouped.Key.RoundId,
                              PlayerId = rpv_grouped.Key.PlayerId,
                              PlayerName = rpv_grouped.Key.Name,
                              PlayerScore = rpv_grouped.Key.Score,
                              Phrase = rpv_grouped.Key.Phrase,
                              votes = rpv_grouped.Count(x => x.Id != null)
                          });
            return result.ToList();
        }
    }
}