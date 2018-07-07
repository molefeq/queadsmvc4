using System;
using System.Configuration;
using System.Security.Claims;
using System.Web.Mvc;
using System.Net.Http;

namespace QueAdsMvc4.Presentation.MvcExtensions
{
    public class BaseController : Controller
    {
        protected virtual new CustomPrincipal User
        {
            get { return HttpContext.User as CustomPrincipal; }
        }

        protected virtual int UserId
        {
            get { return Convert.ToInt32(HttpContext.User.Identity.Name); }
        }

        protected virtual string UserName
        {
            get { return User.UserName; }
        }

        protected virtual bool IsAuthenticated
        {
            get { return Request.IsAuthenticated; }
        }

        protected virtual string GetStringAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        protected virtual int GetIntAppSetting(string key)
        {
            int appSetting;

            if (ConfigurationManager.AppSettings[key] == null || !int.TryParse(ConfigurationManager.AppSettings[key], out appSetting))
            {
                return 0;
            }

            return appSetting;
        }
    }
}
