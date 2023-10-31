using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
namespace CuaHangThietBiDienTu.Areas.ADMIN.Authentication
{


    public class AuthAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // Kiểm tra điều kiện đăng nhập ở đây
            if (httpContext.Session["MANV"] == null)
            {
                var routeValues = new RouteValueDictionary(new
                {
                    controller = "DangNhap",
                    action = "Index"
                });

                httpContext.Response.RedirectToRoute(routeValues);
                return false;
            }

            return true;
        }
    }

}