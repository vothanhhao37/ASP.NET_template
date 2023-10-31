using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangThietBiDienTu.Context;
using CuaHangThietBiDienTu.Models;

namespace CuaHangThietBiDienTu.Controllers
{
    public class HomeController : Controller
    {
        CUAHANGTHIETBIDIENTUEntities2 db = new CUAHANGTHIETBIDIENTUEntities2();
        public ActionResult Index()
        {
            HomeModel homeModel = new HomeModel();
            homeModel.listSanPham = db.SANPHAMs.ToList();

            homeModel.listLoaiSP = db.LOAISANPHAMs.ToList();
            return View(homeModel);
        }
  
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
    }
}