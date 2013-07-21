namespace beta.TheSoundOf.net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParentIdaddedtoShowmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shows", "Producer_Id", "dbo.Producers");
            DropIndex("dbo.Shows", new[] { "Producer_Id" });
            AddColumn("dbo.Shows", "ProducerId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Shows", "ProducerId", "dbo.Producers", "Id", cascadeDelete: true);
            CreateIndex("dbo.Shows", "ProducerId");
            DropColumn("dbo.Shows", "Producer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shows", "Producer_Id", c => c.Int());
            DropIndex("dbo.Shows", new[] { "ProducerId" });
            DropForeignKey("dbo.Shows", "ProducerId", "dbo.Producers");
            DropColumn("dbo.Shows", "ProducerId");
            CreateIndex("dbo.Shows", "Producer_Id");
            AddForeignKey("dbo.Shows", "Producer_Id", "dbo.Producers", "Id");
        }
    }
}
