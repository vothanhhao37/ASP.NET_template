using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CuaHangThietBiDienTu.Areas.ADMIN.Authentication;
using CuaHangThietBiDienTu.Context;

namespace CuaHangThietBiDienTu.Areas.ADMIN.Controllers
{
    [Auth]
    public class NHANVIENsController : Controller
    {
        private CUAHANGTHIETBIDIENTUEntities2 db = new CUAHANGTHIETBIDIENTUEntities2();

        // GET: ADMIN/NHANVIENs
        string LayMaNhanVien()
        {
            var maMax = db.NHANVIENs.ToList().Select(n => n.MANV).Max();
            int maNV = int.Parse(maMax.Substring(2)) + 1;
            string SP = String.Concat("000", maNV.ToString());
            return "NV" + SP.Substring(maNV.ToString().Length - 1);
        }
        public ActionResult Index()
            
        {
            adminCheck();

            return View(db.NHANVIENs.ToList());
        }

        // GET: ADMIN/NHANVIENs/Details/5
        public ActionResult Details(string id)
        {
            adminCheck();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // GET: ADMIN/NHANVIENs/Create
        public ActionResult Create()

        {
            ViewBag.MANHANVIEN = LayMaNhanVien();
            adminCheck();
            return View();
        }

        // POST: ADMIN/NHANVIENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MANV,TENNV,DIACHI,SDT,EMAIL,CMND,CHUCVU,GIOITINH,TAIKHOAN,MATKHAU,ISADMIN")] NHANVIEN nHANVIEN)
        {

            if (ModelState.IsValid)
            {
                nHANVIEN.MANV = LayMaNhanVien();
                db.NHANVIENs.Add(nHANVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nHANVIEN);
        }

        // GET: ADMIN/NHANVIENs/Edit/5
        public ActionResult Edit(string id)
        {
            adminCheck();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: ADMIN/NHANVIENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MANV,TENNV,DIACHI,SDT,EMAIL,CMND,CHUCVU,GIOITINH,TAIKHOAN,MATKHAU,ISADMIN")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHANVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nHANVIEN);
        }

        // GET: ADMIN/NHANVIENs/Delete/5
        public ActionResult Delete(string id)
        {
            adminCheck();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: ADMIN/NHANVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            db.NHANVIENs.Remove(nHANVIEN);
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
        private void adminCheck()
        {
            var check = Session["isAdmin"];
            Debug.WriteLine(check.ToString());
            if ( check.ToString() !="True")
            {
               
                RedirectToAction("Index", "Home");
            }
           
        }
    }
}
