using FJ.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJ.Data.ViewModels
{
    public class OrderTableViewModel 
    { 
        public IEnumerable<OrderIndexViewModel> OrderTable { get; set; }
    }
    public class OrderQueryViewModel
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public int WineryId { get; set; }
        public int ProductId { get; set; }
        public System.DateTime OrderDate { get; set; }
        public Nullable<System.DateTime> RequiredDate { get; set; }
        public System.DateTime ShippedDate { get; set; }
        public string Status { get; set; }
        public DropDownListModel DropDownListModel { get; set; }
    }

    public class OrderIndexViewModel
    {
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public string Winery { get; set; }
        public string OrderDate { get; set; }
        public string RequiredDate { get; set; }
        public string ShippedDate { get; set; }
        public string Status { get; set; }
    }
}
