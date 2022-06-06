using GameRecordApplication_v3.Constants;
using GameRecordApplication_v3.Models;
using GameRecordApplication_v3.Models.Game;
using GameRecordApplication_v3.Seeding;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GameRecordApplication_v3.DataAccessLayer
{
    public class DataContext : DbContext
    {
        public DataContext(): base("GameRecordsConnection")
        {
            Database.SetInitializer(new SeedData());
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<BilliardGameType> BilliardGameTypes { get; set; }
        public DbSet<BilliardGameMode> BilliardGameModes { get; set; }
        public DbSet<BilliardMatch> BilliardMatches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            try
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

                modelBuilder.Entity<Player>()
                    .HasKey(p => p.PlayerId);

                modelBuilder.Entity<BilliardGameType>()
                    .HasKey(b => b.BilliardGameTypeId);

                modelBuilder.Entity<BilliardGameMode>()
                    .HasKey(b => b.BilliardGameModeId);

                modelBuilder.Entity<BilliardMatch>()
                    .HasRequired(p => p.PlayerWin)
                    .WithMany(b => b.WinningPlayer)
                    .HasForeignKey(p => p.PlayerWinId)
                    .WillCascadeOnDelete(false);

                modelBuilder.Entity<BilliardMatch>()
                    .HasRequired(p => p.PlayerLose)
                    .WithMany(b => b.LosingPlayer)
                    .HasForeignKey(p => p.PlayerLoseId)
                    .WillCascadeOnDelete(false);

                modelBuilder.Entity<BilliardMatch>()
                    .HasRequired(p => p.BilliardGameMode)
                    .WithMany(b => b.BilliardMatches)
                    .HasForeignKey(p => p.BilliardGameModeId);

                modelBuilder.Entity<BilliardMatch>()
                    .HasRequired(p => p.BilliardGameType)
                    .WithMany(b => b.BilliardMatches)
                    .HasForeignKey(p => p.BilliardGameTypeId);
            }
            catch (Exception e)
            {
                
            }
        }
    }
}