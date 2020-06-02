using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FJ.BusinessLogics
{
    public class CommonBL : BaseBL
    {
        
        public List<SelectListItem> CategoryList()
        {
            List<SelectListItem> list = AdapterFJRepository.CategoryRepository.GetAll()
                       .Select(p => new SelectListItem { Text = p.CategoryName, Value = p.CategoryId.ToString() }).ToList();

            return list;
        }

        public List<SelectListItem> ProductList()
        {
            List<SelectListItem> list = AdapterFJRepository.ProductRepository.GetAll()
                       .Select(p => new SelectListItem { Text = p.ProductName, Value = p.ProductId.ToString() }).ToList();

            return list;
        }

        public List<SelectListItem> ShelfList()
        {
            List<SelectListItem> list = AdapterFJRepository.ShelfRepository.GetAll()
                       .Select(p => new SelectListItem { Text = p.ShelfName, Value = p.ShelfId.ToString() }).ToList();

            return list;
        }

        public List<SelectListItem> WineryList()
        {
            List<SelectListItem> list = AdapterFJRepository.WineryRepository.GetAll()
                       .Select(p => new SelectListItem { Text = p.WineryName, Value = p.WineryId.ToString() }).ToList();

            return list;
        }

        //public List<SelectListItem> ProductList()
        //{
        //    List<SelectListItem> list = AdapterFJRepository.ProductRepository.GetAll()
        //               .Select(p => new SelectListItem { Text = p.ProductName, Value = p.ProductId.ToString() }).ToList();

        //    return list;
        //}
    }
}