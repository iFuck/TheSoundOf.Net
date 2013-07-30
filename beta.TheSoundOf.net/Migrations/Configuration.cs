namespace beta.TheSoundOf.net.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using beta.TheSoundOf.net.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<beta.TheSoundOf.net.Models.DB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(beta.TheSoundOf.net.Models.DB context)
        {
            var producers = new List<Producer>{
                new Producer{ Name ="Dot Net Rocks", Url="http://dotnetrocks.com" , ShowsUrl="http://www.pwop.com/feed.aspx?show=dotnetrocks&filetype=master"},
                new Producer{ Name ="Hanselminutes", Url="http://hanselminute.com" , ShowsUrl="http://feeds.feedburner.com/HanselminutesCompleteMP3"},
                new Producer{ Name ="This Developers life", Url="http://thisdeveloperslife.com/" , ShowsUrl="http://feeds.feedburner.com/thisdeveloperslife"},
                new Producer{ Name ="Herding Code", Url="http://herdingcode.com/" , ShowsUrl="http://feeds.feedburner.com/herdingcode"}
            };


            using (var db= new DB())
            {
                producers.ForEach(p=>
                  db.Producers.AddOrUpdate(x => x.Name,p));
                db.SaveChanges();
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
