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
    public class SANPHAMsController : Controller
    {
        private CUAHANGTHIETBIDIENTUEntities2 db = new CUAHANGTHIETBIDIENTUEntities2();

        // GET: ADMIN/SANPHAMs
        public ActionResult Index()
        {
            var sANPHAMs = db.SANPHAMs.Include(s => s.LOAISANPHAM).Include(s => s.THUONGHIEU).Include(s => s.THONGSOKYTHUAT);
            return View(sANPHAMs.ToList());
        }

        // GET: ADMIN/SANPHAMs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }
        string LayMaSANPHAM()
        {
            var maMax = db.SANPHAMs.ToList().Select(n => n.MASP).Max();
            int maSP = int.Parse(maMax.Substring(2)) + 1;
            string SP = String.Concat("00000", maSP.ToString());
            return "SP" + SP.Substring(maSP.ToString().Length - 1);
        }

        // GET: ADMIN/SANPHAMs/Create
        public ActionResult Create()
        {
            ViewBag.MASP = LayMaSANPHAM();

            ViewBag.MALOAISP = new SelectList(db.LOAISANPHAMs, "MALOAISP", "TENLOAISP");
            ViewBag.MATH = new SelectList(db.THUONGHIEUx, "MATH", "TENTHUONGHIEU");
            ViewBag.MATSKT = new SelectList(db.THONGSOKYTHUATs, "MATSKT", "HEDIEUHANH");
            return View();
        }

        // POST: ADMIN/SANPHAMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MASP,TENSP,DONGIA,SOLUONG,MOTA,ANH,MALOAISP,MATH,MATSKT")] SANPHAM sANPHAM)
        {
            var imgSP = Request.Files["Avatar"];
            string postedFileName = System.IO.Path.GetFileName(imgSP.FileName);
            var path = Server.MapPath("/Images/" + postedFileName);
            imgSP.SaveAs(path);
            if (ModelState.IsValid)
            {
                sANPHAM.MASP = LayMaSANPHAM();
                sANPHAM.ANH = postedFileName;
                db.SANPHAMs.Add(sANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MALOAISP = new SelectList(db.LOAISANPHAMs, "MALOAISP", "TENLOAISP", sANPHAM.MALOAISP);
            ViewBag.MATH = new SelectList(db.THUONGHIEUx, "MATH", "TENTHUONGHIEU", sANPHAM.MATH);
            ViewBag.MATSKT = new SelectList(db.THONGSOKYTHUATs, "MATSKT", "HEDIEUHANH", sANPHAM.MATSKT);
            return View(sANPHAM);
        }

        // GET: ADMIN/SANPHAMs/Edit/5
        public ActionResult Edit(string id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.MALOAISP = new SelectList(db.LOAISANPHAMs, "MALOAISP", "TENLOAISP", sANPHAM.MALOAISP);
            ViewBag.MATH = new SelectList(db.THUONGHIEUx, "MATH", "TENTHUONGHIEU", sANPHAM.MATH);
            ViewBag.MATSKT = new SelectList(db.THONGSOKYTHUATs, "MATSKT", "HEDIEUHANH", sANPHAM.MATSKT);
            return View(sANPHAM);
        }

        // POST: ADMIN/SANPHAMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MASP,TENSP,DONGIA,SOLUONG,MOTA,ANH,MALOAISP,MATH,MATSKT")] SANPHAM sANPHAM)
        {
            var imgSP = Request.Files["Avatar"];
            string postedFileName = System.IO.Path.GetFileName(imgSP.FileName);
            var path = Server.MapPath("/Images/" + postedFileName);
            imgSP.SaveAs(path);
            if (ModelState.IsValid)
            {
                sANPHAM.ANH = postedFileName;
                db.Entry(sANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MALOAISP = new SelectList(db.LOAISANPHAMs, "MALOAISP", "TENLOAISP", sANPHAM.MALOAISP);
            ViewBag.MATH = new SelectList(db.THUONGHIEUx, "MATH", "TENTHUONGHIEU", sANPHAM.MATH);
            ViewBag.MATSKT = new SelectList(db.THONGSOKYTHUATs, "MATSKT", "HEDIEUHANH", sANPHAM.MATSKT);
            return View(sANPHAM);
        }

        // GET: ADMIN/SANPHAMs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // POST: ADMIN/SANPHAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            db.SANPHAMs.Remove(sANPHAM);
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
