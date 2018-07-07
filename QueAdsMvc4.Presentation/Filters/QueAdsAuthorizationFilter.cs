using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QueAdsMvc4.Presentation.Filters
{
    public class QueAdsAuthorizationFilter: FilterAttribute, IAuthorizationFilter
    {           
        private string[] _Roles;

        public QueAdsAuthorizationFilter() { }

        public QueAdsAuthorizationFilter(params string[] roles)
        {
            _Roles = roles;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var User = filterContext.HttpContext.User;
            bool isAuthorized = _Roles == null ? true : false;

            if (_Roles != null)
            {
                foreach (string module in _Roles)
                {
                    isAuthorized = true;
                    break;
                }
            }

            if (!filterContext.RequestContext.HttpContext.Request.IsAuthenticated || !isAuthorized)
            {
                string loginUrl = FormsAuthentication.LoginUrl;

                LogOut(filterContext);

                if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult
                    {
                        Data = new
                        {
                            loginUrl = loginUrl,
                            message = "sorry the session has timed out, you were logged out"
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                    return;
                }

                FormsAuthentication.RedirectToLoginPage();
                filterContext.Result = new ViewResult() { ViewName = "Login" };

                return;
            }
        }

        private void LogOut(AuthorizationContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Session.Abandon();
            FormsAuthentication.SignOut();

            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            filterContext.RequestContext.HttpContext.Response.Cookies.Add(cookie1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            filterContext.RequestContext.HttpContext.Response.Cookies.Add(cookie2);
        }
    }
}
