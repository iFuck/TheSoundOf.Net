namespace beta.TheSoundOf.net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Showsurladdedtoproducers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Producers", "ShowsUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Producers", "ShowsUrl");
        }
    }
}
