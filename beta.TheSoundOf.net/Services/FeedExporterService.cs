using Argotic.Syndication;
using beta.TheSoundOf.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace beta.TheSoundOf.net.Services
{
    public class FeedExporterService
    {
        public static XDocument CreateFeed(IQueryable<Show> shows, string rootUrl)
        {
        
            var rssFeed = new RssFeed("Main RSS Feed for TheSoundOf.Net");
            var rssChannel = new RssChannel(new Uri("http://www.TheSoundOf.net"), "Title", "Desc");
            var url = "{0}/shows/details/{1}";

            foreach (var item in shows)
            {
                var rssItem = new RssItem
                {
                    Author = item.Producer.Name,
                    Title = item.Title,
                    Link =new Uri( string.Format(url,rootUrl, item.Id)),
                    Guid = new RssGuid(item.Id.ToString(),false),
                    Description = item.Details,
                    PublicationDate = item.PublicationDate.HasValue ? item.PublicationDate.Value : DateTime.Now
                };
                rssChannel.AddItem(rssItem);
            }

            rssFeed.Channel = rssChannel;


            return XDocument.Parse(rssFeed.CreateNavigator().OuterXml.ToString());  

        }
    }
}