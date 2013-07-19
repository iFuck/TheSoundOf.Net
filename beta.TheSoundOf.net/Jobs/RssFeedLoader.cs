using Argotic.Syndication;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace beta.TheSoundOf.net.Jobs
{
    public class RssFeedLoader
    {
        List<string> _feedUrls = null;
        List<Exception> _exceptions = new List<Exception>();

        public RssFeedLoader(List<string> feedUrls)
        {
            _feedUrls = feedUrls;
        }

        /// <summary>
        /// Load content from web. Exceptions collection will contain any exception occured
        /// </summary>
        /// <returns></returns>
        public List<RssFeed> GetLoadedFeeds(out List<Exception> exceptions)
        {
            var feeds = new List<RssFeed>();
            RssFeed feed = null;

            _feedUrls.AsParallel().ForAll(x =>
            {
                try
                {
                    feed = LoadRssFeed(x);
                    feed.Channel.SelfLink = new Uri(x);
                    if (feed != null && feed.Channel.Items.Count() > 0) feeds.Add(feed);
                }
                catch (Exception exp)
                {
                    _exceptions.Add(exp);
                }
            });
            exceptions = _exceptions;

            return feeds;
        }


        private RssFeed LoadRssFeed(string feedurl)
        {
            RssFeed fd = null;

            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(feedurl);
            httpWebRequest.UserAgent =
                "Googlebot/1.0 (googlebot@googlebot.com http://googlebot.com/)";

            // WWB: Use The Default Proxy
            httpWebRequest.Proxy = System.Net.WebRequest.DefaultWebProxy;

            // WWB: Use The Thread's Credentials (Logged In User's Credentials)
            if (httpWebRequest.Proxy != null)
                httpWebRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;

            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (Stream responseStream = httpWebResponse.GetResponseStream())
                {
                    fd = new RssFeed();
                    fd.Load(responseStream);
                }
            }
            return fd;
        }

    }
}