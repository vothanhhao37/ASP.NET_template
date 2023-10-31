using CuaHangThietBiDienTu.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangThietBiDienTu.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using PagedList.Mvc;
using PagedList;
namespace CuaHangThietBiDienTu.Controllers
{
    public class LOAISANPHAMController : Controller
    {
      
        // GET: LOAISANPHAM
        CUAHANGTHIETBIDIENTUEntities2 db = new CUAHANGTHIETBIDIENTUEntities2();
        public ActionResult Index()
        {
            var listLoaiSP = db.LOAISANPHAMs.ToList();

            return View(listLoaiSP);
        }
        public ActionResult SanPhamTheoLoai(string id)
        {
            if (id == null)
                id = "";
             var listSanPham = db.SANPHAMs.Where(n => n.TENSP.ToLower().Contains(id.Trim().ToLower()) || n.MASP.ToLower().Contains(id.Trim().ToLower()) || n.MALOAISP == id).ToList();
            Session["ListSanPham"] = listSanPham;
            return RedirectToAction("DanhSachSanPham");

           
        }

        public ActionResult LocSanPham(string loaisanpham, string hedieuhanh, string thuonghieu, string ram, string rom, string giamin, string giamax)
        {

            //Lọc sản phẩm dựa trên các thông số đầu vào
            var filteredSanPham = db.SANPHAMs.AsQueryable();

            //Lọc theo loại sản phẩm
            if (loaisanpham.Length != 0)
            {
                filteredSanPham = filteredSanPham.Where(sp => loaisanpham.Contains(sp.LOAISANPHAM.TENLOAISP));
            }

            //Lọc theo hệ điều hành
            if (hedieuhanh.Length != 0)
            {
                Debug.WriteLine(hedieuhanh.Length);

                filteredSanPham = filteredSanPham.Where(sp => hedieuhanh.Contains(sp.THONGSOKYTHUAT.HEDIEUHANH));
            }

            //Lọc theo thương hiệu
            if (thuonghieu.Length != 0)
            {
                filteredSanPham = filteredSanPham.Where(sp => thuonghieu.Contains(sp.THUONGHIEU.TENTHUONGHIEU));
            }

            //Lọc theo RAM
            if (ram.Length!=0)
            {
                filteredSanPham = filteredSanPham.Where(sp => ram.Contains(sp.THONGSOKYTHUAT.RAM.ToString()));
            }

            //Lọc theo ROM
            if (rom.Length != 0)
            {
                filteredSanPham = filteredSanPham.Where(sp => rom.Contains(sp.THONGSOKYTHUAT.ROM));
            }

            // Lọc theo giá min
            if (giamin.Length!=0 )
            {
                int minPrice = int.Parse(giamin);
                filteredSanPham = filteredSanPham.Where(sp => sp.DONGIA >= minPrice);
            }

            // Lọc theo giá max
            if (giamax.Length != 0)
            {
                int maxPrice = int.Parse(giamax);
                filteredSanPham = filteredSanPham.Where(sp => sp.DONGIA <= maxPrice);
            }

            // Gửi danh sách sản phẩm đã lọc đến view
            var listSanPham = filteredSanPham.ToList();
            Session["ListSanPham"] = listSanPham;
            return RedirectToAction("DanhSachSanPham");

       

        }

        public ActionResult DanhSachSanPham(int? page, string order)
        {
            ViewBag.listLoaiSP = db.LOAISANPHAMs.ToList();
            ViewBag.listThuongHieu = db.THUONGHIEUx.ToList();
            var listSanPham = Session["ListSanPham"] as List<SANPHAM>;

            int pageSize = 7;
            int pageNumber = (page ?? 1); // Nếu không có giá trị trang được chọn, mặc định là trang đầu tiên          
            var pagedSanPham = listSanPham.ToPagedList(pageNumber, pageSize); // Sử dụng công cụ phân trang để chia danh sách sản phẩm
            if (order == "asc")
            {
                pagedSanPham = listSanPham.OrderBy(n=>n.DONGIA).ToPagedList(pageNumber, pageSize);
            }
            else if (order == "desc")
            {
                pagedSanPham = listSanPham.OrderByDescending(sp => sp.DONGIA).ToPagedList(pageNumber, pageSize);
            }
            return View(pagedSanPham);
        }


    }
}