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
    public class AdviceController : Controller
    {
        private Covid19dbContext db = new Covid19dbContext();

        // GET: Advice
        public ActionResult Index()
        {
            return View(db.Advices.ToList());
        }

        // GET: Advice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advice advice = db.Advices.Find(id);
            if (advice == null)
            {
                return HttpNotFound();
            }
            return View(advice);
        }

        
        // GET: Advice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Advice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description")] Advice advice)
        {
            if (ModelState.IsValid)
            {
               
                advice.UserId = 1;
                advice.Createddate = DateTime.Now;
                advice.Modifieddate = DateTime.Now;
                db.Advices.Add(advice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(advice);
        }

        // GET: Advice/Edit/5
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advice advice = db.Advices.Find(id);
            if (advice == null)
            {
                return HttpNotFound();
            }
            return View(advice);
        }

        // POST: Advice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,UserId,Createddate,Modifieddate")] Advice advice)
        {
            if (ModelState.IsValid)
            {
                advice.Modifieddate = DateTime.Now;
                db.Entry(advice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(advice);
        }

        // GET: Advice/Delete/5
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advice advice = db.Advices.Find(id);
            if (advice == null)
            {
                return HttpNotFound();
            }
            return View(advice);
        }

        // POST: Advice/Delete/5
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advice advice = db.Advices.Find(id);
            db.Advices.Remove(advice);
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
