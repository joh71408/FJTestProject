using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FJ.Data.Models.Common
{
    public class DropDownListModel
    {
        public List<SelectListItem> ProductList { get; set; }
        public List<SelectListItem> WineryList { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
        public List<SelectListItem> ShelfList { get; set; }
    }
}
