using QueAds.Common.ErrorLogging;

using System;
using System.Configuration;
using System.ServiceModel;
using System.Web.Mvc;

namespace QueAdsMvc4.Presentation.Filters
{
   public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                var result = new ViewResult();
                Exception exception = filterContext.Exception;

                if (!(filterContext.Exception is FaultException))
                {
                    string mainErrorLoggingDirectory = ConfigurationManager.AppSettings["MainErrorLoggingDirectory"];

                    ErrorLogger.Instance.LogError("QueAdsMvc4", "QueAds", filterContext.RequestContext.HttpContext.Server.MapPath(mainErrorLoggingDirectory), exception);
                }

                result.ViewName = "Error";

                if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult()
                    {
                        Data = new
                        {
                            error = true,
                            message = "Please contact admin for further assistance regrading this error: " + exception.Message
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    filterContext.Result = result;
                }

                filterContext.ExceptionHandled = true;
            }
        }
    }
}
