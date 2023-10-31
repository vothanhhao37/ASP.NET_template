using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using CuaHangThietBiDienTu.Context;
using System.Diagnostics;

namespace CuaHangThietBiDienTu.Controllers
{
    public class AuthenticationController : Controller
    {
        CUAHANGTHIETBIDIENTUEntities2 db = new CUAHANGTHIETBIDIENTUEntities2();
        // GET: Authentication
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            
            return View();
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(string taikhoan, string matkhau)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(matkhau);
               
                var data = db.KHACHHANGs.Where(s => s.TAIKHOAN.Equals(taikhoan) && s.MATKHAU.Equals(f_password)).ToList();
                
                if (data.Count() > 0)
                {
                   
                    //add session
                    Session["TENKH"] = data.FirstOrDefault().TENKH;
                    Session["TAIKHOAN"] = data.FirstOrDefault().TAIKHOAN;
                    Session["MAKH"] = data.FirstOrDefault().MAKH;
                    Session["SDT"] = data.FirstOrDefault().SDT;
                    Session["DIACHI"] = data.FirstOrDefault().DIACHI;
                    var makH = data.FirstOrDefault().MAKH;
                    var gioHangCount = db.GIOHANGs.Count(n => n.MAKH == makH).ToString();
                    Session["SLGH"] = gioHangCount;

                    return RedirectToAction("Index","Home");
                }
                else
                {
                    Debug.WriteLine("Khôn được");
                    ViewBag.error = "Đăng nhập không thành công";
                    return RedirectToAction("DangNhap");
                }
            }
            return View();
        }
        //GET: Register
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(KHACHHANG _user)
        {
            if (ModelState.IsValid)
            {
                var check = db.KHACHHANGs.FirstOrDefault(s => s.TAIKHOAN == _user.TAIKHOAN);
                _user.MAKH = LayMaKH();
                if (check == null)
                {
                    _user.MATKHAU = GetMD5(_user.MATKHAU);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.KHACHHANGs.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("DangNhap", new { taikhoan = _user.TAIKHOAN, matkhau = _user.MATKHAU });
                }
                else
                {
                    ViewBag.error = "Tên tài khoản đã tồn tại";
                    return View();
                }
            }
            return View();


        }
        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }
        string LayMaKH()
        {
            var maMax = db.KHACHHANGs.ToList().Select(n => n.MAKH).Max();
            int maKH = int.Parse(maMax.Substring(2)) + 1;
            string SP = String.Concat("00", maKH.ToString());
            return "KH" + SP.Substring(maKH.ToString().Length - 1);
        }
    }
}