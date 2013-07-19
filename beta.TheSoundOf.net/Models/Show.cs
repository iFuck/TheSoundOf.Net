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
    }
}