using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CuaHangThietBiDienTu.Context;
namespace CuaHangThietBiDienTu.Models
{
    public class HomeModel
    {
        public List<SANPHAM> listSanPham { get; set; }
        public List<LOAISANPHAM> listLoaiSP { get; set; }
    }
}