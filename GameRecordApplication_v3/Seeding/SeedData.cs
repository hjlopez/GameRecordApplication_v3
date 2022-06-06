using GameRecordApplication_v3.DataAccessLayer;
using GameRecordApplication_v3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GameRecordApplication_v3.Seeding
{
    public class SeedData : CreateDatabaseIfNotExists<DataContext>
    {
        public static void SeedPlayers(DataContext context)
        {
            if (context.Players.Any()) return;

            context.Players.Add(new Player() { Name = "James", IconURL = "" });
            context.Players.Add(new Player() { Name = "Howard", IconURL = "" });
            context.Players.Add(new Player() { Name = "Patrick", IconURL = "" });
            context.Players.Add(new Player() { Name = "Russel", IconURL = "" });

            context.SaveChanges();
        }

        public static void SeedBilliardGameTypes(DataContext context)
        {
            if (context.BilliardGameTypes.Any()) return;

            context.BilliardGameTypes.Add(new BilliardGameType() { BilliardGameTypeName = "8 Ball", IsActive = true });
            context.BilliardGameTypes.Add(new BilliardGameType() { BilliardGameTypeName = "9 Ball", IsActive = true });
            context.BilliardGameTypes.Add(new BilliardGameType() { BilliardGameTypeName = "10 Ball", IsActive = true });
            context.BilliardGameTypes.Add(new BilliardGameType() { BilliardGameTypeName = "15 Ball", IsActive = true });

            context.SaveChanges();
        }
    }
}