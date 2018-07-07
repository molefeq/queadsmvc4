using QueAdsMvc4.App_Start;
using QueAdsMvc4.Presentation.MvcExtensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Validation.Providers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace QueAdsMvc4
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Services.RemoveAll(typeof(System.Web.Http.Validation.ModelValidatorProvider), v => v is InvalidModelValidatorProvider);
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            CultureInfo newCulture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();

            newCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            newCulture.NumberFormat.NumberDecimalSeparator = ".";
            newCulture.DateTimeFormat.DateSeparator = "/";
            Thread.CurrentThread.CurrentCulture = newCulture;
        }

        protected void Application_PostAuthorizeRequest()
        {
            System.Web.HttpContext.Current.SetSessionStateBehavior(System.Web.SessionState.SessionStateBehavior.Required);

            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        FormsIdentity identity = (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket ticket = identity.Ticket;

                        string ticketUserRoles = ticket.UserData.Split(new string[] { "|" }, StringSplitOptions.None)[0];
                        string ticketUserAdditionalInformation = ticket.UserData.Split(new string[] { "|" }, StringSplitOptions.None)[1];

                        List<string> roles = new List<string>();

                        roles.AddRange(ticketUserRoles.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));

                        string userDisplayName = ticketUserAdditionalInformation.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0];

                        HttpContext.Current.User = new CustomPrincipal(identity, roles, userDisplayName);
                    }
                }
            }
        }
    }
}