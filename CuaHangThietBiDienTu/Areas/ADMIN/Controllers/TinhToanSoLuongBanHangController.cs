using CuaHangThietBiDienTu.Areas.ADMIN.Authentication;
using CuaHangThietBiDienTu.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangThietBiDienTu.Areas.ADMIN.Controllers
{
    [Auth]
    public class TinhToanSoLuongBanHangController : Controller
    {
        private CUAHANGTHIETBIDIENTUEntities2 db = new CUAHANGTHIETBIDIENTUEntities2();

        public ActionResult Index()
        {
            //Tìm tên loại sản phẩm theo mã loại sản phẩm

            ViewBag.DSLSP = new SelectList(db.LOAISANPHAMs, "MALOAISP", "TENLOAISP");
            return View();
        }

        public ActionResult TinhToanSoLuongBanDuocTheoLoai(DateTime ngayBatDau,DateTime ngayKetThuc,string loaisp)
        {   //Tính số lượng sản phẩm bán được theo tham số truyền từ giao diện    
            int? soLuongBanDuoc = db.CHITIETHOADONs
                .Where(ct => ct.SANPHAM.MALOAISP == loaisp &&
                             ct.HOADON.NGAYTAO >= ngayBatDau &&
                             ct.HOADON.NGAYTAO <= ngayKetThuc)
                .Sum(ct => (int?)ct.SOLUONG);
            ViewBag.SLBD = soLuongBanDuoc;
            //lấy tên loại sản phẩm để hiển thị ra bảng
            string tenLoaiSP = db.LOAISANPHAMs
              .Where(lsp => lsp.MALOAISP == loaisp)
              .Select(lsp => lsp.TENLOAISP)
              .FirstOrDefault();
            ViewBag.tenloaisp = tenLoaiSP;
            ViewBag.DSLSP = new SelectList(db.LOAISANPHAMs, "MALOAISP", "TENLOAISP");
            return View("Index");
        }

     
    }
}
