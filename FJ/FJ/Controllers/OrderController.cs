using FJ.BusinessLogics;
using FJ.Data.Models.Common;
using FJ.Data.SearchModels;
using FJ.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FJ.Controllers
{
    public class OrderController : BaseController
    {
        OrderBL orderBL = new OrderBL();
        
        // GET: Order
        public ActionResult Index()
        {
            OrderQueryViewModel viewModel = new OrderQueryViewModel()
            {
                DropDownListModel = new DropDownListModel()
                {
                    ProductList = Productlist,
                    CategoryList = Categorylist,
                    ShelfList = ShelfList,
                    WineryList = WineryList
                }
            };
            return View(viewModel);
        }

        public ActionResult getOrderTable(OrderViewSearchModel searchModel)
        {
            OrderTableViewModel table = new OrderTableViewModel()
            {
                OrderTable = orderBL.GetOrderData(searchModel)
            };
            return View("_IndexOrderTable", table);
        }
    }
}