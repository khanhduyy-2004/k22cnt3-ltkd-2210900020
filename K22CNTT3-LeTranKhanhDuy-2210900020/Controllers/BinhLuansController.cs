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
    public class BinhLuansController : Controller
    {
        private K22CNTT3_LeTranKhanhDuy_2210900020_dbEntities db = new K22CNTT3_LeTranKhanhDuy_2210900020_dbEntities();

        // GET: BinhLuans
        public ActionResult LtkdIndex()
        {
            var binhLuan = db.BinhLuan.Include(b => b.BaiViet).Include(b => b.NguoiDung);
            return View(binhLuan.ToList());
        }

        // GET: BinhLuans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinhLuan binhLuan = db.BinhLuan.Find(id);
            if (binhLuan == null)
            {
                return HttpNotFound();
            }
            return View(binhLuan);
        }

        // GET: BinhLuans/Create
        public ActionResult Create()
        {
            ViewBag.MaBaiViet = new SelectList(db.BaiViet, "MaBaiViet", "TieuDe");
            ViewBag.MaNguoiDung = new SelectList(db.NguoiDung, "MaNguoiDung", "TenDangNhap");
            return View();
        }

        // POST: BinhLuans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBinhLuan,MaBaiViet,MaNguoiDung,NoiDung,NgayTao")] BinhLuan binhLuan)
        {
            if (ModelState.IsValid)
            {
                db.BinhLuan.Add(binhLuan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaBaiViet = new SelectList(db.BaiViet, "MaBaiViet", "TieuDe", binhLuan.MaBaiViet);
            ViewBag.MaNguoiDung = new SelectList(db.NguoiDung, "MaNguoiDung", "TenDangNhap", binhLuan.MaNguoiDung);
            return View(binhLuan);
        }

        // GET: BinhLuans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinhLuan binhLuan = db.BinhLuan.Find(id);
            if (binhLuan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaBaiViet = new SelectList(db.BaiViet, "MaBaiViet", "TieuDe", binhLuan.MaBaiViet);
            ViewBag.MaNguoiDung = new SelectList(db.NguoiDung, "MaNguoiDung", "TenDangNhap", binhLuan.MaNguoiDung);
            return View(binhLuan);
        }

        // POST: BinhLuans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBinhLuan,MaBaiViet,MaNguoiDung,NoiDung,NgayTao")] BinhLuan binhLuan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(binhLuan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaBaiViet = new SelectList(db.BaiViet, "MaBaiViet", "TieuDe", binhLuan.MaBaiViet);
            ViewBag.MaNguoiDung = new SelectList(db.NguoiDung, "MaNguoiDung", "TenDangNhap", binhLuan.MaNguoiDung);
            return View(binhLuan);
        }

        // GET: BinhLuans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinhLuan binhLuan = db.BinhLuan.Find(id);
            if (binhLuan == null)
            {
                return HttpNotFound();
            }
            return View(binhLuan);
        }

        // POST: BinhLuans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BinhLuan binhLuan = db.BinhLuan.Find(id);
            db.BinhLuan.Remove(binhLuan);
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
