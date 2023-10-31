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
    public class PHIEUNHAPsController : Controller
    {
        private CUAHANGTHIETBIDIENTUEntities2 db = new CUAHANGTHIETBIDIENTUEntities2();

        // GET: ADMIN/PHIEUNHAPs
        string LayMaPhieuNhap()
        {
            var maMax = db.PHIEUNHAPs.ToList().Select(n => n.MAPN).Max();
            int maHD = int.Parse(maMax.Substring(2)) + 1;
            string SP = String.Concat("00", maHD.ToString());
            return "PN" + SP.Substring(maHD.ToString().Length - 1);
        }
        public ActionResult Index()
        {
            var pHIEUNHAPs = db.PHIEUNHAPs.Include(p => p.NHANVIEN);
            return View(pHIEUNHAPs.ToList());
        }

        // GET: ADMIN/PHIEUNHAPs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUNHAP pHIEUNHAP = db.PHIEUNHAPs.Find(id);
            if (pHIEUNHAP == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUNHAP);
        }

        // GET: ADMIN/PHIEUNHAPs/Create
        public ActionResult Create()
        {
            ViewBag.MAPHIEUNHAP = LayMaPhieuNhap();
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENNV");
            return View();
        }

        // POST: ADMIN/PHIEUNHAPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAPN,MANV,NGAYNHAP")] PHIEUNHAP pHIEUNHAP)
        {
            if (ModelState.IsValid)
            {
                pHIEUNHAP.MAPN = LayMaPhieuNhap();
                db.PHIEUNHAPs.Add(pHIEUNHAP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENNV", pHIEUNHAP.MANV);
            return View(pHIEUNHAP);
        }

        // GET: ADMIN/PHIEUNHAPs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUNHAP pHIEUNHAP = db.PHIEUNHAPs.Find(id);
            if (pHIEUNHAP == null)
            {
                return HttpNotFound();
            }
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENNV", pHIEUNHAP.MANV);
            return View(pHIEUNHAP);
        }

        // POST: ADMIN/PHIEUNHAPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAPN,MANV,NGAYNHAP")] PHIEUNHAP pHIEUNHAP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEUNHAP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENNV", pHIEUNHAP.MANV);
            return View(pHIEUNHAP);
        }

        // GET: ADMIN/PHIEUNHAPs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUNHAP pHIEUNHAP = db.PHIEUNHAPs.Find(id);
            if (pHIEUNHAP == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUNHAP);
        }

        // POST: ADMIN/PHIEUNHAPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHIEUNHAP pHIEUNHAP = db.PHIEUNHAPs.Find(id);
            db.PHIEUNHAPs.Remove(pHIEUNHAP);
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
