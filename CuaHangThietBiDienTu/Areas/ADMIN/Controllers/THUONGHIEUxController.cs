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
    public class THUONGHIEUxController : Controller
    {
        private CUAHANGTHIETBIDIENTUEntities2 db = new CUAHANGTHIETBIDIENTUEntities2();
        string LayMaThuongHieu()
        {
            var maMax = db.THUONGHIEUx.ToList().Select(n => n.MATH).Max();
            int maTH = int.Parse(maMax.Substring(2)) + 1;
            string SP = String.Concat("00", maTH.ToString());
            return "TH" + SP.Substring(maTH.ToString().Length - 1);
        }
        // GET: ADMIN/THUONGHIEUx
        public ActionResult Index()
        {
            return View(db.THUONGHIEUx.ToList());
        }

        // GET: ADMIN/THUONGHIEUx/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUONGHIEU tHUONGHIEU = db.THUONGHIEUx.Find(id);
            if (tHUONGHIEU == null)
            {
                return HttpNotFound();
            }
            return View(tHUONGHIEU);
        }

        // GET: ADMIN/THUONGHIEUx/Create
        public ActionResult Create()
        {
            ViewBag.MATH = LayMaThuongHieu();
            return View();
        }

        // POST: ADMIN/THUONGHIEUx/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MATH,TENTHUONGHIEU,QUOCGIA")] THUONGHIEU tHUONGHIEU)
        {
            if (ModelState.IsValid)
            {
                tHUONGHIEU.MATH = LayMaThuongHieu();
                db.THUONGHIEUx.Add(tHUONGHIEU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tHUONGHIEU);
        }

        // GET: ADMIN/THUONGHIEUx/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUONGHIEU tHUONGHIEU = db.THUONGHIEUx.Find(id);
            if (tHUONGHIEU == null)
            {
                return HttpNotFound();
            }
            return View(tHUONGHIEU);
        }

        // POST: ADMIN/THUONGHIEUx/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MATH,TENTHUONGHIEU,QUOCGIA")] THUONGHIEU tHUONGHIEU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHUONGHIEU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tHUONGHIEU);
        }

        // GET: ADMIN/THUONGHIEUx/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUONGHIEU tHUONGHIEU = db.THUONGHIEUx.Find(id);
            if (tHUONGHIEU == null)
            {
                return HttpNotFound();
            }
            return View(tHUONGHIEU);
        }

        // POST: ADMIN/THUONGHIEUx/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            THUONGHIEU tHUONGHIEU = db.THUONGHIEUx.Find(id);
            db.THUONGHIEUx.Remove(tHUONGHIEU);
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
