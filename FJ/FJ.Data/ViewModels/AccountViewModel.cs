using FJ.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FJ.Data.ViewModels
{
    public class AccountTableViewModel
    {
        public IEnumerable<AccountIndexViewModel> AccountTable { get; set; }
    }
    public class AccountQueryViewModel
    {
        public string AccountUser { get; set; }
        public int IdentityCode { get; set; }
    }
    public class AccountIndexViewModel
    {
        public string AccountUser { get; set; }
        public string UserName { get; set; }
        public int IdentityCode { get; set; }
        public string Winery { get; set; }
    }

    public class AccountCreateUpdateViewModel
    {
        public int AccountId { get; set; }
        public string AccountUser { get; set; }
        public string Password { get; set; }
        public string CheckPassword { get; set; }
        public int IdentityCode { get; set; }
        public string UserName { get; set; }
        public Nullable<int> WineryId { get; set; }
        public DropDownListModel DropDownListModel { get; set; }
        public List<SelectListItem> IdentityCodeList { get; set; }
    }
}
