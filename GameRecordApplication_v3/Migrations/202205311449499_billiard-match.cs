namespace GameRecordApplication_v3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billiardmatch : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BilliardMatch",
                c => new
                    {
                        BilliardMatchId = c.Long(nullable: false, identity: true),
                        PlayerWinId = c.Int(nullable: false),
                        PlayerLoseId = c.Int(nullable: false),
                        WinnerWins = c.Int(nullable: false),
                        LoserWins = c.Int(nullable: false),
                        Season = c.Int(nullable: false),
                        BilliardGameTypeId = c.Int(nullable: false),
                        BilliardGameModeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BilliardMatchId)
                .ForeignKey("dbo.BilliardGameMode", t => t.BilliardGameModeId, cascadeDelete: true)
                .ForeignKey("dbo.BilliardGameType", t => t.BilliardGameTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Player", t => t.PlayerLoseId)
                .ForeignKey("dbo.Player", t => t.PlayerWinId)
                .Index(t => t.PlayerWinId)
                .Index(t => t.PlayerLoseId)
                .Index(t => t.BilliardGameTypeId)
                .Index(t => t.BilliardGameModeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BilliardMatch", "PlayerWinId", "dbo.Player");
            DropForeignKey("dbo.BilliardMatch", "PlayerLoseId", "dbo.Player");
            DropForeignKey("dbo.BilliardMatch", "BilliardGameTypeId", "dbo.BilliardGameType");
            DropForeignKey("dbo.BilliardMatch", "BilliardGameModeId", "dbo.BilliardGameMode");
            DropIndex("dbo.BilliardMatch", new[] { "BilliardGameModeId" });
            DropIndex("dbo.BilliardMatch", new[] { "BilliardGameTypeId" });
            DropIndex("dbo.BilliardMatch", new[] { "PlayerLoseId" });
            DropIndex("dbo.BilliardMatch", new[] { "PlayerWinId" });
            DropTable("dbo.BilliardMatch");
        }
    }
}
