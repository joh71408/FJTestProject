using FJ.BusinessLogics;
using FJ.Data.SearchModels;
using FJ.Data.ViewModels;
using FJ.Models;
using FJ.Utility;
using i18N;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FJ.Controllers
{
    public class AccountController : BaseController
    {
        private AccountBL AccountBL;
        public AccountController()
        {
            AccountBL = new AccountBL();
        }


        [AuthorizeFunctionModel(AuthorizeFunctionCode = 60)]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult GetIndexTable(AccountSearchModel searchModel)
        {
            return View("_IndexAccountTable",AccountBL.GetAccountTable(searchModel));
        }

        public ActionResult CreateUpdate()
        {
            AccountCreateUpdateViewModel viewModel = new AccountCreateUpdateViewModel()
            {
                DropDownListModel = new Data.Models.Common.DropDownListModel()
                {
                    WineryList = WineryList
                },
                IdentityCodeList=new List<SelectListItem>() { new SelectListItem() { Text = "管理員", Value = "90" }, new SelectListItem() { Text = "酒莊", Value = "10" } }
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateUpdate(AccountCreateUpdateViewModel viewModel)
        {
            string message = null;
            if (AccountBL.Create(viewModel))
            {
                message = FJMessage.InsertSuccessMessage;
            }
            else 
            {
                message = FJMessage.InsertErrorMessage;
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}