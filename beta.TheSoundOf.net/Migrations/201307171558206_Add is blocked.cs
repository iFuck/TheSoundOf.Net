namespace beta.TheSoundOf.net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addisblocked : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Producers", "IsBlocked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Producers", "IsBlocked");
        }
    }
}
