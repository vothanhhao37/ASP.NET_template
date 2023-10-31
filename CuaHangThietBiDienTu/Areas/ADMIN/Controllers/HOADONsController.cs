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
    public class HOADONsController : Controller
    {
        private CUAHANGTHIETBIDIENTUEntities2 db = new CUAHANGTHIETBIDIENTUEntities2();

        // GET: ADMIN/HOADONs
        string LayMaHoaDon()
        {
            var maMax = db.HOADONs.ToList().Select(n => n.MAHOADON).Max();
            int maHD = int.Parse(maMax.Substring(2)) + 1;
            string SP = String.Concat("0000000", maHD.ToString());
            return "HD" + SP.Substring(maHD.ToString().Length - 1);
        }
        public ActionResult Index()
        {

            var hOADONs = db.HOADONs.Include(h => h.KHACHHANG).Include(h => h.NHANVIEN);
            return View(hOADONs.ToList());
        }

        // GET: ADMIN/HOADONs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            return View(hOADON);
        }

        // GET: ADMIN/HOADONs/Create
        public ActionResult Create()
        {
            ViewBag.MAHOADON = LayMaHoaDon();
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "MAKH");
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "MANV");
            return View();
        }

        // POST: ADMIN/HOADONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAHOADON,MANV,MAKH,NGAYTAO,TINHTRANGDONHANG")] HOADON hOADON)
        {
            if (ModelState.IsValid)
            {
                hOADON.MAHOADON = LayMaHoaDon();
                db.HOADONs.Add(hOADON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "MAKH", hOADON.MAKH);
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "MANV", hOADON.MANV);
            return View(hOADON);
        }

        // GET: ADMIN/HOADONs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENKH", hOADON.MAKH);
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENNV", hOADON.MANV);
            return View(hOADON);
        }

        // POST: ADMIN/HOADONs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAHOADON,MANV,MAKH,NGAYTAO,TINHTRANGDONHANG")] HOADON hOADON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOADON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENKH", hOADON.MAKH);
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENNV", hOADON.MANV);
            return View(hOADON);
        }

        // GET: ADMIN/HOADONs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            return View(hOADON);
        }

        // POST: ADMIN/HOADONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HOADON hOADON = db.HOADONs.Find(id);
            db.HOADONs.Remove(hOADON);
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
