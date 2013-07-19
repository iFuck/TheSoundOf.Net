using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace beta.TheSoundOf.net.Models
{
    public class DB: DbContext
    {
        public DB()
            : base("DefaultConnection")
        {
                
        }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Show> Shows { get; set; }

    }
}