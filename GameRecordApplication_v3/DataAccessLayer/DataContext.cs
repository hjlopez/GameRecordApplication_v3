using GameRecordApplication_v3.Models;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Player>()
                .HasKey(p => p.PlayerId);

            modelBuilder.Entity<BilliardGameType>()
                .HasKey(b => b.BilliardGameTypeId);
        }
    }
}