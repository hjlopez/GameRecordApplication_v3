namespace GameRecordApplication_v3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BilliardGameType",
                c => new
                    {
                        BilliardGameTypeId = c.Int(nullable: false, identity: true),
                        BilliardGameTypeName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BilliardGameTypeId);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IconURL = c.String(),
                    })
                .PrimaryKey(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Player");
            DropTable("dbo.BilliardGameType");
        }
    }
}
