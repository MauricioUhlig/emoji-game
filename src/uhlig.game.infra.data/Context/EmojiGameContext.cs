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
        public DbSet<RoundPlayerEntity> RoundPlayer { get; set; }
        public DbSet<RoundPlayerPhraseEntity> RoundPlayerPhrases { get; set; }
#nullable enable

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<RoundEntity>()
               .HasOne(x => x.Room)
               .WithMany()
               .HasForeignKey(x => x.RoomId);

            modelBuilder.Entity<RoundPlayerEntity>()
                .HasOne(x => x.Round)
                .WithMany()
                .HasForeignKey(x => x.RoundId);
            modelBuilder.Entity<RoundPlayerEntity>()
                .HasOne(x => x.Player)
                .WithMany()
                .HasForeignKey(x => x.PlayerId);

            modelBuilder.Entity<RoundPlayerPhraseEntity>()
                .HasOne(x => x.RoundPlayer)
                .WithMany()
                .HasForeignKey(x => x.RoundPlayerId);

            //seeds
            modelBuilder.Entity<PlayerEntity>()
                .HasData(new PlayerEntity(Guid.Parse("bfce80db-3143-4594-91f2-7e1a74fa3b19"), "Fulano de Teste", 550));

            modelBuilder.Entity<RoomEntity>()
                .HasData(new RoomEntity(Guid.Parse("b5212d38-9600-47c6-a5ab-8a7e7d2b3421"), "code", true));

            modelBuilder.Entity<RoundEntity>()
                .HasData(new RoundEntity(Guid.Parse("10de598e-5bfd-4c6c-95d7-a64c83a5fdf1"), Guid.Parse("b5212d38-9600-47c6-a5ab-8a7e7d2b3421"), "emojis", DateTime.Now, 60));

            modelBuilder.Entity<RoundPlayerEntity>()
                .HasData(new RoundPlayerEntity(Guid.Parse("c587c4cd-a065-436b-abe9-22fa804dfd20"), Guid.Parse("10de598e-5bfd-4c6c-95d7-a64c83a5fdf1"), Guid.Parse("bfce80db-3143-4594-91f2-7e1a74fa3b19")));

            modelBuilder.Entity<RoundPlayerPhraseEntity>()
                .HasData(new RoundPlayerPhraseEntity(Guid.Parse("9031e8c3-9452-4087-8189-fb380a7f255a"), Guid.Parse("c587c4cd-a065-436b-abe9-22fa804dfd20"), "Um conjunto de caracteres", DateTime.Now));

        }

    }
}