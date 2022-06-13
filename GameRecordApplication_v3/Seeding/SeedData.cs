using GameRecordApplication_v3.Constants;
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
            try
            {
                if (context.Players.Any()) return;

                context.Players.Add(new Player() { Name = "James", IconURL = "" });
                context.Players.Add(new Player() { Name = "Howard", IconURL = "" });
                context.Players.Add(new Player() { Name = "Patrick", IconURL = "" });
                context.Players.Add(new Player() { Name = "Russel", IconURL = "" });

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                LogWriting.WriteDBLog("SeedData", System.Reflection.MethodBase.GetCurrentMethod().Name, ex, LogFile.DBExceptionLog);
            }
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

        public static void SeedBilliardGameModes(DataContext context)
        {
            if (context.BilliardGameModes.Any()) return;

            context.BilliardGameModes.Add(new Models.Game.BilliardGameMode() { BilliardGameModeName = "Elimination", IsPlayoff = false, Remarks = "Winner +1 win, Loser +1 loss" });
            context.BilliardGameModes.Add(new Models.Game.BilliardGameMode() { BilliardGameModeName = "Step Ladder 1", IsPlayoff = true, Remarks = "Winner adv to SL2, Loser is 4th" });
            context.BilliardGameModes.Add(new Models.Game.BilliardGameMode() { BilliardGameModeName = "Step Ladder 2", IsPlayoff = true, Remarks = "Winner adv to Finals, Loser is 3rd" });
            context.BilliardGameModes.Add(new Models.Game.BilliardGameMode() { BilliardGameModeName = "3rd/4th Game", IsPlayoff = true, Remarks = "Winner is 3rd, Loser is 4th" });
            context.BilliardGameModes.Add(new Models.Game.BilliardGameMode() { BilliardGameModeName = "Semis - Best of 3", IsPlayoff = true, Remarks = "Winner adv to Finals, Loser to 3rd/4th game" });
            context.BilliardGameModes.Add(new Models.Game.BilliardGameMode() { BilliardGameModeName = "Semis - Twice to Beat", IsPlayoff = true, Remarks = "Winner adv to Finals, Loser to 3rd/4th game" });
            context.BilliardGameModes.Add(new Models.Game.BilliardGameMode() { BilliardGameModeName = "Finals - Best of 3", IsPlayoff = true, Remarks = "Winner is champ, Loser is 2nd" });
            context.BilliardGameModes.Add(new Models.Game.BilliardGameMode() { BilliardGameModeName = "Finals - Best of 5", IsPlayoff = true, Remarks = "Winner is champ, Loser is 2nd" });

            context.SaveChanges();

        }
    }
}