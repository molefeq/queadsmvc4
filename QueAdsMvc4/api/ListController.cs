using QueAdsMvc4.Presentation.Factories;
using QueAdsMvc4.Presentation.MvcExtensions;
using QueAdsMvc4.Presentation.ViewModels;

using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QueAdsMvc4.api
{
    public class ListController : BaseApiController
    {
        [HttpGet]
        public HttpResponseMessage GetProvinces()
        {
            List<ProvinceViewModel> provinces = ServiceHandlers.ProvinceHandler.GetProvinces(string.Empty);
            return Request.CreateResponse<List<ProvinceViewModel>>(HttpStatusCode.OK, provinces);
        }

        [HttpGet]
        public HttpResponseMessage GeCategories()
        {
            List<CategoryViewModel> categories = ServiceHandlers.CategoryHandler.GetCategories(string.Empty, null, null, null, null, null);
            return Request.CreateResponse<List<CategoryViewModel>>(HttpStatusCode.OK, categories);
        }
    }
}
