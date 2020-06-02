using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FJ.Data.Repositories.Adapter;

namespace FJ.Models
{
    public class AuthorizeModel : AuthorizeAttribute
    {
        protected AdapterFJRepository _AdapterFJRepository;
        protected bool _Authorize;

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (SessionModel.LoginDate != null)
            {
                _Authorize = true;
                _AdapterFJRepository = new AdapterFJRepository();
            }
            else
            {
                _Authorize = false;

                RouteValueDictionary routeValueDictionary = new RouteValueDictionary();
                routeValueDictionary.Add("controller", "Login");
                routeValueDictionary.Add("action", "Index");

                filterContext.Result = new RedirectToRouteResult(routeValueDictionary);
            }
        }
    }

    public class AuthorizeFunctionModel : AuthorizeModel
    {
        // 網頁功能 Code
        private int _AuthorizeFunctionCode;
        public int AuthorizeFunctionCode
        {
            get { return _AuthorizeFunctionCode; }
            set { _AuthorizeFunctionCode = value; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (_Authorize)
            {
                // 權限功能驗證
                bool isPageAuthorize = base._AdapterFJRepository.CheckAuthorizeFunction(SessionModel.LoginDate.LoginId, this.AuthorizeFunctionCode);

                // 驗證失敗
                if (isPageAuthorize == false)
                {
                    RouteValueDictionary routeValueDictionary = new RouteValueDictionary();
                    routeValueDictionary.Add("controller", "Home");
                    routeValueDictionary.Add("action", "Error");
                    routeValueDictionary.Add("id", "您沒有權限");

                    filterContext.Result = new RedirectToRouteResult(routeValueDictionary);
                }
            }
        }
    }
}