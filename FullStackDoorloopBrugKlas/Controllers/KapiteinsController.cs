using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBFSDoorloop;

namespace FullStackDoorloopBrugKlas.Controllers
{
    public class KapiteinsController : Controller
    {
        private FullStackDBContext db = new FullStackDBContext();

        // GET: Kapiteins
        public ActionResult Index()
        {
            return View(db.Kapiteins.ToList());
        }

        // GET: Kapiteins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kapitein kapitein = db.Kapiteins.Find(id);
            if (kapitein == null)
            {
                return HttpNotFound();
            }
            return View(kapitein);
        }

        // GET: Kapiteins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kapiteins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KapiteinId,Naam,Leeftijd,AlcoholPercentage")] Kapitein kapitein)
        {
            if (ModelState.IsValid)
            {
                db.Kapiteins.Add(kapitein);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kapitein);
        }

        // GET: Kapiteins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kapitein kapitein = db.Kapiteins.Find(id);
            if (kapitein == null)
            {
                return HttpNotFound();
            }
            return View(kapitein);
        }

        // POST: Kapiteins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KapiteinId,Naam,Leeftijd,AlcoholPercentage")] Kapitein kapitein)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kapitein).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kapitein);
        }

        // GET: Kapiteins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kapitein kapitein = db.Kapiteins.Find(id);
            if (kapitein == null)
            {
                return HttpNotFound();
            }
            return View(kapitein);
        }

        // POST: Kapiteins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kapitein kapitein = db.Kapiteins.Find(id);
            db.Kapiteins.Remove(kapitein);
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
        public JsonResult SchipVanKapitein(int SchipId) {
            List<Kapitein> kapiteinen = db.Kapiteins.Where( s => s.SchipId == SchipId).ToList();
            return Json(kapiteinen, JsonRequestBehavior.AllowGet);
        }
    }
}
