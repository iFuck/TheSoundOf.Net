namespace beta.TheSoundOf.net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShowStatistics : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        ShowsUrl = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Details = c.String(),
                        Mp3Url = c.String(),
                        ProducerId = c.Int(nullable: false),
                        Guid = c.String(),
                        PublicationDate = c.DateTime(),
                        PlayedOnReleasDate = c.Int(nullable: false),
                        PlayedTotal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Producers", t => t.ProducerId, cascadeDelete: true)
                .Index(t => t.ProducerId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Shows", new[] { "ProducerId" });
            DropForeignKey("dbo.Shows", "ProducerId", "dbo.Producers");
            DropTable("dbo.Shows");
            DropTable("dbo.Producers");
        }
    }
}
