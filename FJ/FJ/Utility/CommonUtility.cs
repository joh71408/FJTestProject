using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FJ.Utility
{
    public class CommonUtility
    {
        public static string SubmitAfterScript(StringBuilder scriptContent)
        {
            string strScript = null;
            strScript += "<script type=\"text/javascript\">";
            strScript += scriptContent.Replace(Environment.NewLine, string.Empty).ToString();       // framework throw exception msg 會有換行符號要移除，不然 javascript 會出錯
            strScript += "</script>";

            return strScript;
        }
    }
}