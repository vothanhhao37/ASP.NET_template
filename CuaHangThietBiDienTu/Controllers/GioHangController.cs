using CuaHangThietBiDienTu.Context;
using CuaHangThietBiDienTu.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangThietBiDienTu.Controllers
{
    public class GioHangController : Controller
    {
        CUAHANGTHIETBIDIENTUEntities2 db = new CUAHANGTHIETBIDIENTUEntities2();
        public ActionResult Index(string makh)
        {
            if (Session["MAKH"] != null)
            {

                var thongTinGioHang = db.GIOHANGs.Where(n => n.MAKH == makh).ToList();

                return View(thongTinGioHang);

            }
            return RedirectToAction("DangNhap", "Authentication");
           
        }

        public ActionResult ThemVaoGioHang(string masp, string soluong)
        {


            if (Session["MAKH"] == null) {
                return RedirectToAction("DangNhap", "Authentication");
            }
            var gioHangItem = db.GIOHANGs.FirstOrDefault(g => g.MASP == masp);
            if (gioHangItem != null)
            {
                // Nếu sản phẩm đã tồn tại, cập nhật số lượng
                gioHangItem.SOLUONG += int.Parse(soluong);
               
            }
            else
            {
                // Nếu sản phẩm chưa tồn tại, tạo mới và thêm vào giỏ hàng
                var gioHangItemMoi = new GIOHANG
                {
                    MASP = masp,
                    SOLUONG = int.Parse(soluong),
                    DONGIA = db.SANPHAMs.Where(n=>n.MASP==masp).FirstOrDefault().DONGIA, // Cập nhật giá sản phẩm tương ứng
                    MAKH = Session["MAKH"].ToString()// Thay đổi giá trị MAKH theo người dùng đăng nhập hoặc hệ thống đang sử dụng
                };
                db.GIOHANGs.Add(gioHangItemMoi);

                // Cho Session["SLGH"] +=1;
                Session["SLGH"] = int.Parse(Session["SLGH"].ToString()) + 1;
               
            }
           
         
            db.SaveChanges();

            // Trả về kết quả thành công hoặc thông tin khác cần thiết (nếu cần)


            return Json(new { success = true, slgh = Session["SLGH"] }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult XoaSanPham(string masp)
        {

            var gioHang = db.GIOHANGs.SingleOrDefault(g => g.MASP == masp);
            if (gioHang != null)
            {
                db.GIOHANGs.Remove(gioHang);
                db.SaveChanges();
                Session["SLGH"] = int.Parse(Session["SLGH"].ToString()) - 1;
                return Json(new { success = true, slgh = Session["SLGH"] });


            }
            return Json(new { success = false  });
        }
        [HttpPost]
        public ActionResult CapNhatSoLuong(string masp, int soluong)
        {
           
            var gioHang = db.GIOHANGs.SingleOrDefault(g => g.MASP == masp);
            if (gioHang != null)
            {
                gioHang.SOLUONG = soluong;
                db.SaveChanges();
               
                return Json(new { success = true });
               
            }
           
            return Json(new { success = false });
        }


        public ActionResult ConfirmOrder()
        {
            if (Session["MAKH"] == null)
            {
                return RedirectToAction("DangNhap", "Authentication");
            }
            List<SelectedProduct> selectedProducts = Session["selectedProducts"] as List<SelectedProduct>;
            List<XacNhanDatHangModel> xacNhanDatHangs = new List<XacNhanDatHangModel>();

            foreach (var item in selectedProducts)
            {
                var sanPham = db.SANPHAMs.FirstOrDefault(n => n.MASP == item.MASP);

                if (sanPham != null)
                {
                    XacNhanDatHangModel xacNhanDatHang = new XacNhanDatHangModel
                    {
                        TENSP = sanPham.TENSP,
                        SOLUONG = item.SOLUONG,
                        DONGIA = sanPham.DONGIA,
                        ANHSP = sanPham.ANH
                    };

                    xacNhanDatHangs.Add(xacNhanDatHang);
                }
            }

            return View(xacNhanDatHangs);
        }


        [HttpPost]
        public ActionResult XuLiGioHang(List<SelectedProduct> selectedProducts)
        {
            // Xử lý dữ liệu sản phẩm đã chọn
          
            Session["selectedProducts"] = selectedProducts;
            return Json(selectedProducts);

        }
        public ActionResult DatHangThanhCong()
        {
            if (Session["MAKH"] == null)
            {
                return RedirectToAction("DangNhap", "Authentication");
            }
            string maHD = LayMaHoaDon();
            string maKH = Session["MAKH"] as string;
            DateTime ngayTao = DateTime.Now;
            string tinhTrangDonHang = "Đã đặt hàng";

            HOADON hoadon = new HOADON
            {
                MAHOADON = maHD,
                MANV = null,
                MAKH = maKH,
                NGAYTAO = ngayTao,
                TINHTRANGDONHANG = tinhTrangDonHang
            };

            // Lưu hóa đơn vào cơ sở dữ liệu
            db.HOADONs.Add(hoadon);
            db.SaveChanges();
            List<SelectedProduct> selectedProducts = Session["selectedProducts"] as List<SelectedProduct>;
            foreach(var item in selectedProducts)
            {
                var sanPham = db.SANPHAMs.FirstOrDefault(n => n.MASP == item.MASP);
                CHITIETHOADON cthd = new CHITIETHOADON
                {
                    MAHOADON = maHD,
                    MASP = item.MASP,
                    SOLUONG = item.SOLUONG,
                    DONGIAXUAT = sanPham.DONGIA
            };
                db.CHITIETHOADONs.Add(cthd);
                // xóa dòng trong bảng GIOHANG có MASP = item.MASP và có MAKH = Session["MAKH"]
                var gioHangItem = db.GIOHANGs.FirstOrDefault(n => n.MASP == item.MASP && n.MAKH == maKH);
                if (gioHangItem != null)
                {
                    db.GIOHANGs.Remove(gioHangItem);
                }
                db.SaveChanges();
            }
            Session["SLGH"] = int.Parse(Session["SLGH"].ToString()) - selectedProducts.Count;
            Session["selectedProducts"] = null;
            return View();
        }

        string LayMaHoaDon()
        {
            var maMax = db.HOADONs.ToList().Select(n => n.MAHOADON).Max();
            int maHD = int.Parse(maMax.Substring(2)) + 1;
            string SP = String.Concat("000", maHD.ToString());
            return "HD" + SP.Substring(maHD.ToString().Length - 1);
        }

    }
}
