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
    public class CHITIETHOADONsController : Controller
    {
        private CUAHANGTHIETBIDIENTUEntities2 db = new CUAHANGTHIETBIDIENTUEntities2();

        // GET: ADMIN/CHITIETHOADONs
        public ActionResult Index()
        {
            var cHITIETHOADONs = db.CHITIETHOADONs.Include(c => c.HOADON).Include(c => c.SANPHAM);
            return View(cHITIETHOADONs.ToList());
        }

        // GET: ADMIN/CHITIETHOADONs/Details/5
        public ActionResult Details(string maHoaDon, string maSP)
        {
            if (maHoaDon == null || maSP == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CHITIETHOADON chiTietHoaDon = db.CHITIETHOADONs.Find(maHoaDon, maSP);

            if (chiTietHoaDon == null)
            {
                return HttpNotFound();
            }

            return View(chiTietHoaDon);
        }

        // GET: ADMIN/CHITIETHOADONs/Create
        public ActionResult Create()
        {
            ViewBag.MAHOADON = new SelectList(db.HOADONs, "MAHOADON", "MAHOADON");
            ViewBag.MASP = new SelectList(db.SANPHAMs, "MASP", "MASP");
            return View();
        }

        // POST: ADMIN/CHITIETHOADONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAHOADON,MASP,SOLUONG,DONGIAXUAT")] CHITIETHOADON cHITIETHOADON)
        {
            if (ModelState.IsValid)
            {
                db.CHITIETHOADONs.Add(cHITIETHOADON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAHOADON = new SelectList(db.HOADONs, "MAHOADON", "MAHOADON", cHITIETHOADON.MAHOADON);
            ViewBag.MASP = new SelectList(db.SANPHAMs, "MASP", "MASP", cHITIETHOADON.MASP);
            return View(cHITIETHOADON);
        }

        // GET: ADMIN/CHITIETHOADONs/Edit/5
        public ActionResult Edit(string maHoaDon, string maSP)
        {
            if (maHoaDon == null || maSP == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CHITIETHOADON chiTietHoaDon = db.CHITIETHOADONs.Find(maHoaDon, maSP);

            if (chiTietHoaDon == null)
            {
                return HttpNotFound();
            }

            // Lấy dữ liệu cần thiết để chỉnh sửa chi tiết hóa đơn
            ViewBag.ListHoaDon = new SelectList(db.HOADONs, "MAHOADON", "MAHOADON");
            ViewBag.ListSanPham = new SelectList(db.SANPHAMs, "MASP", "MASP");

            return View(chiTietHoaDon);
        }

        // POST: CHITIETHOADONs/Edit/5
        [HttpPost]
        public ActionResult Edit(CHITIETHOADON chiTietHoaDon)
        {
            if (ModelState.IsValid)
            {
                // Cập nhật thông tin chi tiết hóa đơn trong cơ sở dữ liệu
                db.Entry(chiTietHoaDon).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            // Nếu dữ liệu không hợp lệ, hiển thị lại form chỉnh sửa với thông báo lỗi
            ViewBag.ListHoaDon = new SelectList(db.HOADONs, "MAHOADON", "MAHOADON");
            ViewBag.ListSanPham = new SelectList(db.SANPHAMs, "MASP", "MASP");

            return View(chiTietHoaDon);
        }

        // GET: ADMIN/CHITIETHOADONs/Delete/5
        public ActionResult Delete(string maHoaDon, string maSP)
        {
            if (maHoaDon == null || maSP == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CHITIETHOADON chiTietHoaDon = db.CHITIETHOADONs.Find(maHoaDon, maSP);

            if (chiTietHoaDon == null)
            {
                return HttpNotFound();
            }

            return View(chiTietHoaDon);
        }

        // POST: CHITIETHOADONs/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string maHoaDon, string maSP)
        {
            CHITIETHOADON chiTietHoaDon = db.CHITIETHOADONs.Find(maHoaDon, maSP);
            db.CHITIETHOADONs.Remove(chiTietHoaDon);
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
