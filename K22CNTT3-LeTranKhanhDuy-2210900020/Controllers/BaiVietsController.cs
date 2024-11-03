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
    public class BaiVietsController : Controller
    {
        private K22CNTT3_LeTranKhanhDuy_2210900020_dbEntities db = new K22CNTT3_LeTranKhanhDuy_2210900020_dbEntities();

        // GET: BaiViets
        public ActionResult LtkdIndex()
        {
            var baiViet = db.BaiViet.Include(b => b.NguoiDung);
            return View(baiViet.ToList());
        }

        // GET: BaiViets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViet.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            return View(baiViet);
        }

        // GET: BaiViets/Create
        public ActionResult Create()
        {
            ViewBag.MaNguoiDung = new SelectList(db.NguoiDung, "MaNguoiDung", "TenDangNhap");
            return View();
        }

        // POST: BaiViets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBaiViet,MaNguoiDung,TieuDe,NoiDung,NgayTao")] BaiViet baiViet)
        {
            if (ModelState.IsValid)
            {
                db.BaiViet.Add(baiViet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNguoiDung = new SelectList(db.NguoiDung, "MaNguoiDung", "TenDangNhap", baiViet.MaNguoiDung);
            return View(baiViet);
        }

        // GET: BaiViets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViet.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNguoiDung = new SelectList(db.NguoiDung, "MaNguoiDung", "TenDangNhap", baiViet.MaNguoiDung);
            return View(baiViet);
        }

        // POST: BaiViets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBaiViet,MaNguoiDung,TieuDe,NoiDung,NgayTao")] BaiViet baiViet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baiViet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNguoiDung = new SelectList(db.NguoiDung, "MaNguoiDung", "TenDangNhap", baiViet.MaNguoiDung);
            return View(baiViet);
        }

        // GET: BaiViets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViet.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            return View(baiViet);
        }

        // POST: BaiViets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaiViet baiViet = db.BaiViet.Find(id);
            db.BaiViet.Remove(baiViet);
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
