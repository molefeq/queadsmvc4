using QueAdsMvc4.Presentation.Utility;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace QueAdsMvc4.Presentation.MvcExtensions
{
    public class BaseApiController : ApiController
    {
        public virtual List<ModelStateError> ToModelStateErrorResult(ModelStateDictionary modelStateDictionary)
        {
            List<ModelStateError> errors = new List<ModelStateError>();

            foreach (var modelState in modelStateDictionary)
            {
                if (modelState.Value.Errors.Count > 0)
                {
                    errors.Add(new ModelStateError { Message = modelState.Value.Errors[0].ErrorMessage, FieldName = modelState.Key });
                }
            }

            return errors;
        }

        protected virtual bool IsAuthenticated
        {
            get { return HttpContext.Current.Request.IsAuthenticated; }
        }

        protected virtual new CustomPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as CustomPrincipal; }
        }

        protected virtual int UserId
        {
            get { return Convert.ToInt32(CurrentUser.Identity.Name); }
        }

        protected virtual string UserName
        {
            get { return CurrentUser.UserName; }
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
