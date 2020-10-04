using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dot_myCovid19app.DAL;
using Dot_myCovid19app.Models;

namespace Dot_myCovid19app.Controllers
{
    public class URLController : Controller
    {
        private Covid19dbContext db = new Covid19dbContext();

        // GET: URL
        public ActionResult Index()
        {
            return View(db.URLs.ToList());
        }


        // GET: URL/Details/5
        public ActionResult viewURL(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            URL uRL = db.URLs.Find(id);
            
            return View(Server.UrlEncode(uRL.CovidURL));
        }

        // GET: URL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            URL uRL = db.URLs.Find(id);
            if (uRL == null)
            {
                return HttpNotFound();
            }
            return View(uRL);
        }

        // GET: URL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: URL/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CountryName,CovidURL")] URL url)
        {
            if (ModelState.IsValid)
            {
                //url.UserId = 1;
                url.Createddate = DateTime.Now;
               // url.Modifieddate = DateTime.Now;
                db.URLs.Add(url);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(url);
        }

        // GET: URL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            URL uRL = db.URLs.Find(id);
            if (uRL == null)
            {
                return HttpNotFound();
            }
            return View(uRL);
        }

        // POST: URL/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CountryName,CovidURL,Createddate")] URL url)
        {
            if (ModelState.IsValid)
            {
               // uRL.ModifiedDate = DateTime.Now;
                db.Entry(url).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(url);
        }

        // GET: URL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            URL uRL = db.URLs.Find(id);
            if (uRL == null)
            {
                return HttpNotFound();
            }
            return View(uRL);
        }

        // POST: URL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            URL uRL = db.URLs.Find(id);
            db.URLs.Remove(uRL);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
