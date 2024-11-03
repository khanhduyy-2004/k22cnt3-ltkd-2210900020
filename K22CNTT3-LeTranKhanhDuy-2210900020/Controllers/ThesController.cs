using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNTT3_LeTranKhanhDuy_2210900020.Models;

namespace K22CNTT3_LeTranKhanhDuy_2210900020.Controllers
{
    public class ThesController : Controller
    {
        private K22CNTT3_LeTranKhanhDuy_2210900020_dbEntities db = new K22CNTT3_LeTranKhanhDuy_2210900020_dbEntities();

        // GET: Thes
        public ActionResult LtkdIndex()
        {
            return View(db.The.ToList());
        }

        // GET: Thes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            The the = db.The.Find(id);
            if (the == null)
            {
                return HttpNotFound();
            }
            return View(the);
        }

        // GET: Thes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Thes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaThe,TenThe")] The the)
        {
            if (ModelState.IsValid)
            {
                db.The.Add(the);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(the);
        }

        // GET: Thes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            The the = db.The.Find(id);
            if (the == null)
            {
                return HttpNotFound();
            }
            return View(the);
        }

        // POST: Thes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaThe,TenThe")] The the)
        {
            if (ModelState.IsValid)
            {
                db.Entry(the).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(the);
        }

        // GET: Thes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            The the = db.The.Find(id);
            if (the == null)
            {
                return HttpNotFound();
            }
            return View(the);
        }

        // POST: Thes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            The the = db.The.Find(id);
            db.The.Remove(the);
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
