using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using beta.TheSoundOf.net.Models;

using PagedList.Mvc;

using PagedList;
namespace beta.TheSoundOf.net.Controllers
{
    public class ShowsController : Controller
    {
        private DB db = new DB();

        //
        // GET: /Shows/

        public ActionResult Index(int? page, string searchText)
    {
        ViewBag.SearchText = searchText;
        var products = db.Shows.Include(x => x.Producer).OrderBy(x=>x.Id).AsQueryable();

        if (!string.IsNullOrEmpty(searchText)) products = products.Where(x => x.Title.Contains(searchText) || x.Details.Contains(searchText)).AsQueryable();

        var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
        var onePageOfProducts = products.OrderBy(x => x.Id).ToPagedList(pageNumber, 25); // will only contain 25 products max because of the pageSize

        ViewBag.OnePageOfProducts = onePageOfProducts;
          
            return View(onePageOfProducts);
            
        }

        //
        // GET: /Shows/Details/5

        public ActionResult Details(int id = 0)
        {
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        //
        // GET: /Shows/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Shows/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Show show)
        {
            if (ModelState.IsValid)
            {
                db.Shows.Add(show);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(show);
        }

        //
        // GET: /Shows/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        //
        // POST: /Shows/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Show show)
        {
            if (ModelState.IsValid)
            {
                db.Entry(show).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(show);
        }

        //
        // GET: /Shows/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        //
        // POST: /Shows/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Show show = db.Shows.Find(id);
            db.Shows.Remove(show);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}