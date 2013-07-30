using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beta.TheSoundOf.net.Models
{
    public class Show
    {
        public virtual int Id { get; set; }

        public virtual string Title { get; set; }
        public virtual string Details { get; set; }
        public virtual string Mp3Url { get; set; }

        public virtual int ProducerId { get; set; }

        public virtual string Guid { get; set; }
        public virtual Producer Producer { get; set; }

        public virtual DateTime? PublicationDate { get; set; }

        public virtual int PlayedOnReleasDate { get; set; }

        public virtual int PlayedTotal { get; set; }



        internal void UpdateStatistics()
        {
            PlayedTotal += 1;
            var now = DateTime.Now;
            if (PublicationDate.HasValue &&
                (PublicationDate <= now && PublicationDate.Value.AddMonths(1) >= now))
                PlayedOnReleasDate += 1;
        }
    }
}