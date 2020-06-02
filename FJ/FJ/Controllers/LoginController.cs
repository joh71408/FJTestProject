using FJ.BusinessLogics;
using FJ.Data.ViewModels;
using i18N;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FJ.Controllers
{
    public class LoginController : Controller
    {
        private AccountBL AccountBL;
        public LoginController()
        {
            AccountBL = new AccountBL();
        }
        // GET: Login
        public ActionResult LoginIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginIndex(LoginIndexViewModel viewModel)
        {
            bool check = AccountBL.GetLogin(viewModel);
            if(check)
            {
                return RedirectToAction("Index", "Home");
            }
            return Json(FJMessage.LoginErrorMessage, JsonRequestBehavior.AllowGet);
        }
    }
}