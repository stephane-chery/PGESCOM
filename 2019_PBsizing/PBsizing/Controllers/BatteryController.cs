using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBsizing.Models;


namespace PBsizing.Controllers
{
    public class BatteryController : Controller
    {
        private   BatListEntities2 db = new BatListEntities2();

        //
        // GET: /Battery/

        public ActionResult Index()
        {
            return View(db.BATTERIEs.ToList());
        }

        //
        // GET: /Battery/Details/5

        public ActionResult Details(short id = 0)
        {
            BATTERIE batterie = db.BATTERIEs.Find(id);
            if (batterie == null)
            {
                return HttpNotFound();
            }
            return View(batterie);
        }

        //
        // GET: /Battery/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Battery/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BATTERIE batterie)
        {
            if (ModelState.IsValid)
            {
                db.BATTERIEs.Add(batterie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(batterie);
        }

        //
        // GET: /Battery/Edit/5

        public ActionResult Edit(short id = 0)
        {
            BATTERIE batterie = db.BATTERIEs.Find(id);
            if (batterie == null)
            {
                return HttpNotFound();
            }
            return View(batterie);
        }

        //
        // POST: /Battery/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BATTERIE batterie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(batterie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(batterie);
        }

        //
        // GET: /Battery/Delete/5

        public ActionResult Delete(short id = 0)
        {
            BATTERIE batterie = db.BATTERIEs.Find(id);
            if (batterie == null)
            {
                return HttpNotFound();
            }
            return View(batterie);
        }

        //
        // POST: /Battery/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            BATTERIE batterie = db.BATTERIEs.Find(id);
            db.BATTERIEs.Remove(batterie);
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