using beta.TheSoundOf.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beta.TheSoundOf.net.Jobs
{
    public class FeedsUpdaterJob
    {

        public void UpdateFeeds()
        {
            var db = new DB();

            var urls = db.Producers.Select(x => x.ShowsUrl).Distinct().ToList();

            List<Exception> exceptions = null;
            var rssFeeds = new RssFeedLoader(urls).GetLoadedFeeds(out exceptions);

            if (exceptions != null && exceptions.Count > 0)
            {
                exceptions.ForEach(e=>
                Elmah.ErrorSignal.FromCurrentContext().Raise(e));
            }


            rssFeeds.ForEach(feed => 
            {
                var url = feed.Channel.SelfLink.ToString();
               var guids = db.Shows
                            .Where(x => x.Producer.ShowsUrl == url)
                            .Select(x => x.Guid).Distinct()
                            .ToList();
               var p = db.Producers.FirstOrDefault(x => x.ShowsUrl ==url);
               feed.Channel
                   .Items
                   .ToList()
                   .ForEach(x =>
                   {
                       if (!guids.Contains(x.Guid.ToString()))
                       {
                           if (p != null && x.Enclosures.Count >0)
                           {
                               p.Shows.Add(new Show { 
                                Producer = p,
                                Guid = x.Guid.ToString(),
                                Mp3Url =  x.Enclosures.First().Url.AbsoluteUri.ToString(),
                                ProducerId = p.Id,
                                Title = x.Title,
                                Details =  x.Description,
                                PublicationDate = x.PublicationDate
                              
                                });
                               
                           }
                       }

                   });

               db.SaveChanges();

            });

        }
    }

  
}