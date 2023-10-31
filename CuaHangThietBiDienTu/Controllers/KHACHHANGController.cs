using CuaHangThietBiDienTu.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CuaHangThietBiDienTu.Controllers
{
    public class KHACHHANGController : Controller
    {
        // GET: KHACHHANG
        CUAHANGTHIETBIDIENTUEntities2 db = new CUAHANGTHIETBIDIENTUEntities2();
        public ActionResult Detail(string makh)
        {
         
            if (Session["MAKH"]!=null)
            {
               
                var thongTinCaNhan = db.KHACHHANGs.Where(m => m.MAKH == makh).FirstOrDefault();
              
                return View(thongTinCaNhan);
               
            }
            return RedirectToAction("DangNhap","Authentication");
           
        }
        public ActionResult DonDatHang()
        {
            if(Session["MAKH"]==null)
            {
                return RedirectToAction("DangNhap", "Authentication");
            }
            var makh = Session["MAKH"].ToString();
            var DDH = db.HOADONs.Where(hd=>hd.MAKH==makh);
            return View(DDH.ToList());
        }
        public ActionResult Edit()
            
        {
            if (Session["MAKH"] == null)
            {
                return RedirectToAction("DangNhap", "Authentication");
            }
            var id = Session["MAKH"].ToString();
          
            KHACHHANG kHACHHANG = db.KHACHHANGs.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
        }

        // POST: KHACHHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAKH,TENKH,DIACHI,SDT,EMAIL,CMND,TAIKHOAN,MATKHAU")] KHACHHANG kHACHHANG)
        {
            Debug.WriteLine("Da edit");
            //var currentKH = db.KHACHHANGs.Where(kh => kh.MAKH == Session["MAKH"].ToString()).FirstOrDefault();
            //kHACHHANG.MATKHAU = currentKH.MATKHAU;
            if (ModelState.IsValid)
            {
                db.Entry(kHACHHANG).State = EntityState.Modified;
                db.SaveChanges();
                
            }
            return View(kHACHHANG);
        }
      
    }
}