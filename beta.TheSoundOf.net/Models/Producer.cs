using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beta.TheSoundOf.net.Models
{
    public class Producer
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Url { get; set; }
        public virtual string ShowsUrl { get; set; }

        public virtual bool IsBlocked { get; set; }
        
        public virtual IList<Show> Shows { get; set; }


        public Producer()
        {
            Shows = new List<Show>();
        }
    }
}