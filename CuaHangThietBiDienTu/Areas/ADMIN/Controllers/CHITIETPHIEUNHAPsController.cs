using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CuaHangThietBiDienTu.Areas.ADMIN.Authentication;
using CuaHangThietBiDienTu.Context;

namespace CuaHangThietBiDienTu.Areas.ADMIN.Controllers
{
    [Auth]
    public class CHITIETPHIEUNHAPsController : Controller
    {
        private CUAHANGTHIETBIDIENTUEntities2 db = new CUAHANGTHIETBIDIENTUEntities2();

        // GET: ADMIN/CHITIETPHIEUNHAPs
        public ActionResult Index()
        {
            var cHITIETPHIEUNHAPs = db.CHITIETPHIEUNHAPs.Include(c => c.PHIEUNHAP).Include(c => c.SANPHAM);
            return View(cHITIETPHIEUNHAPs.ToList());
        }

        // GET: ADMIN/CHITIETPHIEUNHAPs/Details/5
        public ActionResult Details(string maPhieuNhap, string maSP)
        {
            if (maPhieuNhap == null || maSP==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETPHIEUNHAP cHITIETPHIEUNHAP = db.CHITIETPHIEUNHAPs.Find(maPhieuNhap, maSP);
            if (cHITIETPHIEUNHAP == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETPHIEUNHAP);
        }

        // GET: ADMIN/CHITIETPHIEUNHAPs/Create
        public ActionResult Create()
        {
            ViewBag.MAPN = new SelectList(db.PHIEUNHAPs, "MAPN", "MAPN");
            ViewBag.MASP = new SelectList(db.SANPHAMs, "MASP", "TENSP");
            return View();
        }

        // POST: ADMIN/CHITIETPHIEUNHAPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAPN,MASP,SOLUONG,DONGIANHAP")] CHITIETPHIEUNHAP cHITIETPHIEUNHAP)
        {
            if (ModelState.IsValid)
            {
                db.CHITIETPHIEUNHAPs.Add(cHITIETPHIEUNHAP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAPN = new SelectList(db.PHIEUNHAPs, "MAPN", "MANV", cHITIETPHIEUNHAP.MAPN);
            ViewBag.MASP = new SelectList(db.SANPHAMs, "MASP", "TENSP", cHITIETPHIEUNHAP.MASP);
            return View(cHITIETPHIEUNHAP);
        }

        // GET: ADMIN/CHITIETPHIEUNHAPs/Edit/5
        public ActionResult Edit(string maPhieuNhap, string maSP)
        {
            if (maPhieuNhap == null || maSP == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETPHIEUNHAP cHITIETPHIEUNHAP = db.CHITIETPHIEUNHAPs.Find(maPhieuNhap,maSP);
            if (cHITIETPHIEUNHAP == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAPN = new SelectList(db.PHIEUNHAPs, "MAPN", "MAPN", cHITIETPHIEUNHAP.MAPN);
            ViewBag.MASP = new SelectList(db.SANPHAMs, "MASP", "TENSP", cHITIETPHIEUNHAP.MASP);
            return View(cHITIETPHIEUNHAP);
        }

        // POST: ADMIN/CHITIETPHIEUNHAPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAPN,MASP,SOLUONG,DONGIANHAP")] CHITIETPHIEUNHAP cHITIETPHIEUNHAP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHITIETPHIEUNHAP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAPN = new SelectList(db.PHIEUNHAPs, "MAPN", "MAPN", cHITIETPHIEUNHAP.MAPN);
            ViewBag.MASP = new SelectList(db.SANPHAMs, "MASP", "TENSP", cHITIETPHIEUNHAP.MASP);
            return View(cHITIETPHIEUNHAP);
        }

        // GET: ADMIN/CHITIETPHIEUNHAPs/Delete/5
        public ActionResult Delete(string maPhieuNhap, string maSP)
        {
            if (maPhieuNhap == null || maSP == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETPHIEUNHAP cHITIETPHIEUNHAP = db.CHITIETPHIEUNHAPs.Find(maPhieuNhap, maSP);
            if (cHITIETPHIEUNHAP == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETPHIEUNHAP);
        }

        // POST: ADMIN/CHITIETPHIEUNHAPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string maPhieuNhap, string maSP)
        {
            CHITIETPHIEUNHAP cHITIETPHIEUNHAP = db.CHITIETPHIEUNHAPs.Find(maPhieuNhap, maSP);
            db.CHITIETPHIEUNHAPs.Remove(cHITIETPHIEUNHAP);
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
