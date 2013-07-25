using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace beta.TheSoundOf.net.Controllers
{
    public class AccountsController : Controller
    {
        //
        // GET: /Accounts/

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string userName, string userPssword)
        {
            if (FormsAuthentication.Authenticate(Request.Form["userName"], Request.Form["userPassword"]))
            {
                return RedirectToAction("Index", "Producers");
               // FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, False);
            }
            return View();
        }
    }
}
