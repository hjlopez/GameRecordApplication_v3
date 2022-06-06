namespace GameRecordApplication_v3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gamemode : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BilliardGameMode",
                c => new
                    {
                        BilliardGameModeId = c.Int(nullable: false, identity: true),
                        BilliardGameModeName = c.String(nullable: false),
                        IsPlayoff = c.Boolean(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.BilliardGameModeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BilliardGameMode");
        }
    }
}
