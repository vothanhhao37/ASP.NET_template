using CuaHangThietBiDienTu.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangThietBiDienTu.Areas.ADMIN.Controllers
{
    public class DangNhapController : Controller
    {
        CUAHANGTHIETBIDIENTUEntities2 db = new CUAHANGTHIETBIDIENTUEntities2();
        // GET: ADMIN/DangNhap
        [HttpGet]
        public ActionResult Index()
        {
            Session["MANV"] = "admin";
            Session["isAdmin"] = "123";

            return View();

        }

        [HttpPost]
        public ActionResult Index(string taikhoan, string matkhau)
        {
            if (ModelState.IsValid)
            {
               

                var data = db.NHANVIENs.Where(s => s.TAIKHOAN.Equals(taikhoan) && s.MATKHAU.Equals(matkhau)).ToList();
                Debug.WriteLine(data.Count());
                if (data.Count() > 0)
                {
                 
;                    //add session
                    Session["MANV"] = data.FirstOrDefault().MANV;
                    Session["isAdmin"] = data.FirstOrDefault().ISADMIN.ToString();
                    Session["TENNV" ]= data.FirstOrDefault().TENNV.ToString();
                    Debug.WriteLine("isadmin : " + Session["isAdmin"]);
                    return RedirectToAction("Index", "ADMIN/Home");
                }
                else
                {
                    Debug.WriteLine(2);
                    ViewBag.error = "Đăng nhập không thành công";
                    return RedirectToAction("Index", "ADMIN/DangNhap");
                }
            }
            Debug.WriteLine(3);
            return View();
        }
        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("Index", "DangNhap");
        }
    }
}