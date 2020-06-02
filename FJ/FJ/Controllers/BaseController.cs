using FJ.BusinessLogics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FJ.Controllers
{
    public class BaseController: Controller
    {
        
        public  CommonBL _CommonBL;
        public CommonBL CommonBL
        {
            get
            {
                if (_CommonBL != null) 
                {
                    _CommonBL = new CommonBL();
                }
                return _CommonBL;
            }
        } 

        public List<SelectListItem> _Categorylist;
        public List<SelectListItem> Categorylist
        {
            get
            {
                if (_Categorylist != null)
                {
                    _Categorylist = CommonBL.CategoryList();
                }
                return _Categorylist;
            }
        }

        public List<SelectListItem> _Productlist;
        public List<SelectListItem> Productlist 
        {
            get 
            { 
                if(_Productlist!=null)
                {
                    _Productlist = CommonBL.ProductList();
                }
                return _Productlist;
            }
        }

        public List<SelectListItem> _ShelfList;
        public List<SelectListItem> ShelfList
        {
            get
            {
                if (_ShelfList != null)
                {
                    _ShelfList = CommonBL.ShelfList();
                }
                return _ShelfList;
            }
        }

        public List<SelectListItem> _WineryList;
        public List<SelectListItem> WineryList
        {
            get
            {
                if (_WineryList != null)
                {
                    _WineryList = CommonBL.WineryList();
                }
                return _WineryList;
            }
        }

        public void Download()
        {

        }
    }
}