using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QueAdsMvc4
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ViewAds_Route",
                url: "Ads",
                defaults: new { controller = "Ads", action = "ViewAds" }
            );

            routes.MapRoute(
                name: "UserAds_Route",
                url: "UserAds",
                defaults: new { controller = "Ads", action = "UserAds" }
            );

            routes.MapRoute(
                name: "EditUser_Route",
                url: "EditUser",
                defaults: new { controller = "Account", action = "EditUser" }
            );

            routes.MapRoute(
                name: "Login_Route",
                url: "Login",
                defaults: new { controller = "Account", action = "Login" }
            );

            routes.MapRoute(
                name: "Logoff_Route",
                url: "Logoff",
                defaults: new { controller = "Account", action = "Logoff" }
            );

            routes.MapRoute(
                name: "Register_Route",
                url: "Register",
                defaults: new { controller = "Account", action = "Register" }
            );

            routes.MapRoute(
                name: "ForgotPassword_Route",
                url: "ForgotPassword",
                defaults: new { controller = "Account", action = "ForgotPassword" }
            );


            routes.MapRoute(
                name: "ChangePassword_Route",
                url: "ChangePassword",
                defaults: new { controller = "Account", action = "ChangePassword" }
            );

            routes.MapRoute(
                name: "ContactUs_Route",
                url: "ContactUs",
                defaults: new { controller = "ContactUs", action = "ContactUs" }
            );

            routes.MapRoute(
                name: "CreateAd_Route",
                url: "CreateAd",
                defaults: new { controller = "Ads", action = "CreateAd", policyId = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "ViewAd_Route",
                url: "Ad/{policyId}",
                defaults: new { controller = "Ads", action = "ViewAd", policyId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EditAd_Route",
                url: "EditAd/{policyId}",
                defaults: new { controller = "Ads", action = "EditAd", policyId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Home", id = UrlParameter.Optional }
            );
        }
    }
}