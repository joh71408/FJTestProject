using FJ.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FJ.Helper
{
    public static class CommonHelper
    {
        #region DateTimeFormat

        // 日期格式(ToShortDateString 會去抓 client 端 OS 日期格式，導致與 DatePicker 格式不符會出錯)
        public static string ToDateFormat(this DateTime dte)
        {
            return dte.ToDateFormat(DateTimeFormat.yyyyMMdd);
        }
        public static string ToDateFormat(this DateTime dte, DateTimeFormat dateTimeFormat)
        {
            string formatStr = null;
            switch (dateTimeFormat)
            {
                case DateTimeFormat.yyyy:
                    formatStr = "yyyy";
                    break;
                case DateTimeFormat.yyyyMM:
                    formatStr = "yyyy-MM";
                    break;
                case DateTimeFormat.yyyyMMdd:
                    formatStr = "yyyy-MM-dd";
                    break;
                case DateTimeFormat.yyyyMMddHHmmss:
                    formatStr = "yyyy-MM-dd HH:mm:ss";
                    break;
                case DateTimeFormat.HHmmss:
                    formatStr = "HH:mm:ss";
                    break;
                default:
                    goto case DateTimeFormat.yyyyMMdd;
            }

            return dte.ToString(formatStr);
        }

        #endregion
    }
}