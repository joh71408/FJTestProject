using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FJ.Models
{
    public class LoginModel
    {
        public int LoginId { get; set; }
        public string AccountUser { get; set; }
        public int IdentityCode { get; set; }
        public string UserName { get; set; }
    }
}