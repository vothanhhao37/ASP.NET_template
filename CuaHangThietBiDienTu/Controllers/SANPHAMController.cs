using CuaHangThietBiDienTu.Context;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangThietBiDienTu.Controllers
{
    public class SANPHAMController : Controller
    {
        CUAHANGTHIETBIDIENTUEntities2 db = new CUAHANGTHIETBIDIENTUEntities2();
        // GET: SANPHAM
        public ActionResult Detail(string id)
        {
            var sanPham = db.SANPHAMs.Where(n => n.MASP == id).FirstOrDefault();
            return View(sanPham);
        }
       


    }
}