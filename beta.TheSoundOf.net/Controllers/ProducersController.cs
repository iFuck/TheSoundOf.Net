using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using beta.TheSoundOf.net.Models;
using PagedList;

namespace beta.TheSoundOf.net.Controllers
{
    public class ProducersController : Controller
    {
        private DB db = new DB();


        public ProducersController()
        {
            ViewBag.Title = "The Sound Of .Net";
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600, VaryByParam = "none")]
        public ActionResult Producers()
        {
            
            return View( db.Producers.Where(x => !x.IsBlocked).ToList());
        }

        //
        // GET: /Producers/
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Producers.ToList());
        }

        //
        // GET: /Producers/Details/5

        public ActionResult Details( int? page, int id = 0)
        {
            Producer producer = db.Producers.Include(x=>x.Shows).FirstOrDefault(x=>x.Id == id);
            if (producer == null)
            {
                return HttpNotFound();
            }
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfProducts = producer.Shows.OrderByDescending(x => x.PublicationDate).AsQueryable().ToPagedList(pageNumber, 25); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfItems = onePageOfProducts;

            return View(producer);
        }

        //
        // GET: /Producers/Create

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Producers/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Producer producer)
        {
            if (ModelState.IsValid)
            {
                db.Producers.Add(producer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producer);
        }

        //
        // GET: /Producers/Edit/5

        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            Producer producer = db.Producers.Find(id);
            if (producer == null)
            {
                return HttpNotFound();
            }
            return View(producer);
        }

        //
        // POST: /Producers/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(Producer producer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producer);
        }

        //
        // GET: /Producers/Delete/5

        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            Producer producer = db.Producers.Find(id);
            if (producer == null)
            {
                return HttpNotFound();
            }
            return View(producer);
        }

        //
        // POST: /Producers/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Producer producer = db.Producers.Find(id);
            db.Producers.Remove(producer);
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