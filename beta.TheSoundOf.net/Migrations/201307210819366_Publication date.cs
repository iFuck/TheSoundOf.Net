namespace beta.TheSoundOf.net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Publicationdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shows", "PublicationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shows", "PublicationDate");
        }
    }
}
