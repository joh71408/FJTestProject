using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FJ.Models
{
    public class SessionModel
    {
        public static LoginModel LoginDate
        {
            get
            {
                return HttpContext.Current.Session["LoginDate"] as LoginModel;
            }
            set
            {
                HttpContext.Current.Session["LoginDate"] = value;
            }
        }
    }
}