using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace beta.TheSoundOf.net.Controllers
{
    public class JobsController : Controller
    {
        //
        // GET: /Jobs/
        
        public ActionResult Index()
        {
            new beta.TheSoundOf.net.Jobs.FeedsUpdaterJob().UpdateFeeds();
            return RedirectToAction("Index","Shows");
        }

    }
}
