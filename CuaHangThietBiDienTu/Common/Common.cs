using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
namespace CuaHangThietBiDienTu.Common
{
    static public class Common
    {
        static public string FormatNumberWithDotsAndCurrency(dynamic amount)
        { 
            CultureInfo cultureInfo = new CultureInfo("vi-VN"); // Chỉ định ngôn ngữ của định dạng tiền tệ
            return amount.ToString("C0", cultureInfo);
        }

    }
}