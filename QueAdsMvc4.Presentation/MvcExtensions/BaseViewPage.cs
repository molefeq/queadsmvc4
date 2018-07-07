using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace QueAdsMvc4.Presentation.MvcExtensions
{
    public abstract class BaseViewPage : WebViewPage
    {
        public virtual new CustomPrincipal User
        {
            get { return base.User as CustomPrincipal; }
        }

        protected virtual bool IsAuthenticated
        {
            get { return Request.IsAuthenticated; }
        }
    }

    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        public virtual new CustomPrincipal User
        {
            get { return base.User as CustomPrincipal; }
        }

        protected virtual bool IsAuthenticated
        {
            get { return Request.IsAuthenticated; }
        }
    }
}
