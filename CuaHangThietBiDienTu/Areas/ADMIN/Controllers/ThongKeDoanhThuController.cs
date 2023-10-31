using CuaHangThietBiDienTu.Areas.ADMIN.Authentication;
using CuaHangThietBiDienTu.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangThietBiDienTu.Areas.ADMIN.Controllers
{
    [Auth]
    public class ThongKeDoanhThuController : Controller
    {
        // GET: ADMIN/ThongKeDoanhThu
        private CUAHANGTHIETBIDIENTUEntities2 db = new CUAHANGTHIETBIDIENTUEntities2();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Filter(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            // Lọc danh sách chi tiết hóa đơn theo ngày tạo
            var chiTietHoaDon = db.CHITIETHOADONs.Where(hd => hd.HOADON.NGAYTAO >= ngayBatDau && hd.HOADON.NGAYTAO <= ngayKetThuc).ToList();

            // Tính tổng doanh thu
            decimal tongDoanhThu = chiTietHoaDon.Sum(ct => ct.SOLUONG * ct.DONGIAXUAT);

            // Truyền dữ liệu qua view
            ViewBag.ChiTietHoaDon = chiTietHoaDon;
            ViewBag.TongDoanhThu = tongDoanhThu;

            return View("Index");
        }
        public ActionResult ExportToExcel()
        {
            return View();
        }
    }
}