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
    public class THONGSOKYTHUATsController : Controller
    {
        private CUAHANGTHIETBIDIENTUEntities2 db = new CUAHANGTHIETBIDIENTUEntities2();
        string LayMaTSKT()
        {
            var maMax = db.THONGSOKYTHUATs.ToList().Select(n => n.MATSKT).Max();
            int maTSKT = int.Parse(maMax.Substring(4)) + 1;
            string SP = String.Concat("00", maTSKT.ToString());
            return "TSKT" + SP.Substring(maTSKT.ToString().Length - 1);
        }
        // GET: ADMIN/THONGSOKYTHUATs
        public ActionResult Index()
        {
            return View(db.THONGSOKYTHUATs.ToList());
        }

        // GET: ADMIN/THONGSOKYTHUATs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THONGSOKYTHUAT tHONGSOKYTHUAT = db.THONGSOKYTHUATs.Find(id);
            if (tHONGSOKYTHUAT == null)
            {
                return HttpNotFound();
            }
            return View(tHONGSOKYTHUAT);
        }

        // GET: ADMIN/THONGSOKYTHUATs/Create
        public ActionResult Create()
        {
            ViewBag.MATHONGSOKT = LayMaTSKT();
            return View();
        }

        // POST: ADMIN/THONGSOKYTHUATs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MATSKT,HEDIEUHANH,RAM,ROM,KICHCOMANHINH,VIXULY,PIN,CAMERA")] THONGSOKYTHUAT tHONGSOKYTHUAT)
        {
            if (ModelState.IsValid)
            {
                tHONGSOKYTHUAT.MATSKT = LayMaTSKT();
                db.THONGSOKYTHUATs.Add(tHONGSOKYTHUAT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tHONGSOKYTHUAT);
        }

        // GET: ADMIN/THONGSOKYTHUATs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THONGSOKYTHUAT tHONGSOKYTHUAT = db.THONGSOKYTHUATs.Find(id);
            if (tHONGSOKYTHUAT == null)
            {
                return HttpNotFound();
            }
            return View(tHONGSOKYTHUAT);
        }

        // POST: ADMIN/THONGSOKYTHUATs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MATSKT,HEDIEUHANH,RAM,ROM,KICHCOMANHINH,VIXULY,PIN,CAMERA")] THONGSOKYTHUAT tHONGSOKYTHUAT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHONGSOKYTHUAT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tHONGSOKYTHUAT);
        }

        // GET: ADMIN/THONGSOKYTHUATs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THONGSOKYTHUAT tHONGSOKYTHUAT = db.THONGSOKYTHUATs.Find(id);
            if (tHONGSOKYTHUAT == null)
            {
                return HttpNotFound();
            }
            return View(tHONGSOKYTHUAT);
        }

        // POST: ADMIN/THONGSOKYTHUATs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            THONGSOKYTHUAT tHONGSOKYTHUAT = db.THONGSOKYTHUATs.Find(id);
            db.THONGSOKYTHUATs.Remove(tHONGSOKYTHUAT);
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
