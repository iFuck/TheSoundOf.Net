using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace beta.TheSoundOf.net.Models
{
    public class DB : DbContext
    {
        public DB()
        // : base("DefaultConnection")
        {

        }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Show> Shows { get; set; }


        internal IQueryable<Show> GetShowsWithSearch(int? page, string searchText)
        {
            var shows = Shows.Include(x => x.Producer).OrderByDescending(x => x.PublicationDate).AsQueryable();

            if (!string.IsNullOrEmpty(searchText)) shows = shows.Where(x => x.Title.Contains(searchText) || x.Details.Contains(searchText)).AsQueryable();


            return shows;
        }

        internal IQueryable<Show> GetShowsForRssFeed()
        {
            return Shows
                    .Where(x => !x.Producer.IsBlocked)
                    .OrderByDescending(x => x.PublicationDate)
                    .Take(50);

        }
    }
}