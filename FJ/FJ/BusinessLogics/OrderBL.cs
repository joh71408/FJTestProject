using FJ.Data.EntityFrameworks;
using FJ.Data.SearchModels;
using FJ.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FJ.BusinessLogics
{
    public class OrderBL : BaseBL
    {
        public IQueryable<OrderIndexViewModel> GetOrderData(OrderViewSearchModel searchModel)
        {
            IQueryable<Order> table = AdapterFJRepository.OrderRepository.GetAll();

            if (searchModel.OrderId != null) 
            {
                table = table.Where(p => p.OrderId.Equals(searchModel.OrderId));
            }
            if (string.IsNullOrEmpty(searchModel.CustomerName))
            {
                table = table.Where(p => p.CustomerName.Contains(searchModel.CustomerName));
            }
            if (searchModel.WineryId != 0)
            {
                table = table.Where(p => p.WineryId.Equals(searchModel.WineryId));
            }
            if (searchModel.ProductId != 0)
            {
                table = from n in table
                        where n.Order_Detail == AdapterFJRepository.Order_DetailRepository.GetAll(p => p.ProductId == searchModel.ProductId)
                        select n;
            }
            if(searchModel.OrderDate!=null)
            {
                DateTime NextDate = searchModel.OrderDate.Value.AddDays(1);
                table = table.Where(p => p.OrderDate >= searchModel.OrderDate && p.OrderDate < NextDate);
            }
            if (searchModel.RequiredDate != null)
            {
                DateTime NextDate = searchModel.RequiredDate.Value.AddDays(1);
                table = table.Where(p => p.RequiredDate >= searchModel.RequiredDate && p.RequiredDate < NextDate);
            }
            if (searchModel.ShippedDate != null)
            {
                DateTime NextDate = searchModel.ShippedDate.Value.AddDays(1);
                table = table.Where(p => p.ShippedDate >= searchModel.ShippedDate && p.ShippedDate < NextDate);
            }
            var Otable = table.Select(p => new OrderIndexViewModel
            {
                OrderId = p.OrderId.ToString(),
                CustomerName = p.CustomerName,
                Winery = p.Winery.WineryName,
                OrderDate = p.OrderDate.ToString(),
                RequiredDate = p.RequiredDate.ToString(),
                ShippedDate = p.ShippedDate.ToString()
            });
            return Otable.OrderByDescending(p=>p.OrderDate);
        }
    }
}