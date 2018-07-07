using DotNetOpenAuth.AspNet;

using Microsoft.Web.WebPages.OAuth;

using QueAdsMvc4.Presentation.Filters;

using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QueAdsMvc4.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [QueAdsAuthorizationFilter()]
        public ActionResult EditUser()
        {
            return View();
        }

        [HttpGet]
        [QueAdsAuthorizationFilter()]
        public ActionResult Logoff()
        {
            LogOff();
            return RedirectToAction("Home", "Home", new { area = "" });
        }
        
        #region Private Methods

        private void LogOff()
        {
            Session.Abandon();

            // clear authentication cookie
            HttpCookie formsAuthenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            formsAuthenticationCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(formsAuthenticationCookie);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            HttpCookie sessionCookie = new HttpCookie("ASP.NET_SessionId", "");
            sessionCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(sessionCookie);
        }

        #endregion

    }
}
