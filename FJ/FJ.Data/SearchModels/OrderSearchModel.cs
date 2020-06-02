using FJ.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJ.Data.SearchModels
{
    public class OrderViewSearchModel
    {
        public int? OrderId { get; set; }
        public string CustomerName { get; set; }
        public int WineryId { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> RequiredDate { get; set; }
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public string Status { get; set; }
    }
}
