namespace beta.TheSoundOf.net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedguidtosjowsforuniqueness : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shows", "Guid", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shows", "Guid");
        }
    }
}
