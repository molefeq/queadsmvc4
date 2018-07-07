using QueAdsMvc4.Presentation.Filters;
using System.Web;
using System.Web.Mvc;

namespace QueAdsMvc4
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ExceptionFilter());
        }
    }
}