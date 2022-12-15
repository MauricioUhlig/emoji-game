using uhlig.game.domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace uhlig.game.infra.data.Context
{
    public class EmojiGameContext : DbContext
    {

        public EmojiGameContext(DbContextOptions options) : base(options)
        {
        }

#nullable disable
        public DbSet<PlayerEntity> Players { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<RoundEntity> Rounds { get; set; }
        public DbSet<RoundPlayerPhraseEntity> RoundPlayerPhrases { get; set; }
#nullable enable
    }
}