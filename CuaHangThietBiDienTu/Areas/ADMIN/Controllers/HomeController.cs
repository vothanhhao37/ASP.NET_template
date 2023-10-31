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
    public class HomeController : Controller
    {
        private CUAHANGTHIETBIDIENTUEntities2 db = new CUAHANGTHIETBIDIENTUEntities2();
        // GET: ADMIN/Home
        public ActionResult Index()
        {
            ViewBag.SLDH = db.HOADONs.Count();
            ViewBag.SLKH = db.KHACHHANGs.Count();
            ViewBag.SLNV = db.NHANVIENs.Count();
            ViewBag.SLSP = db.SANPHAMs.Count();
            return View();
        }
    }
}