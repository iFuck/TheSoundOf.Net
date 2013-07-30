using beta.TheSoundOf.net.Models;
using beta.TheSoundOf.net.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Xml.Linq;

namespace beta.TheSoundOf.net.Controllers
{
    public class RssFeedController : Controller
    {
        //
        // GET: /RssFeed/

        public ActionResult Index()
        {
            var rootUrl = "http://asite.azurewebsites.net";// WebConfigurationManager.AppSettings["RootUrl"];//== null ? "http://localhost:1000" : WebConfigurationManager.AppSettings["RootUrl"];
            var document = new XDocument();

            try
            {
                using (var db = new DB())
                {
                    var shows = db.GetShowsForRssFeed();
                    document = FeedExporterService.CreateFeed(shows, rootUrl);
                }
            }
            catch (Exception e)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(e);
            }

            return Content(document.ToString(), "text/xml", Encoding.UTF8);

        }

    }
}
