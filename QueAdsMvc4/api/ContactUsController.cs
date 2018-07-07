using QueAdsMvc4.Presentation.Factories;
using QueAdsMvc4.Presentation.MvcExtensions;
using QueAdsMvc4.Presentation.ViewModels;

using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QueAdsMvc4.api
{
    public class ContactUsController : BaseApiController
    {
        [HttpPost]
        public HttpResponseMessage SendContactUsMessage(ContactUsViewModel model)
        {
            ServiceHandlers.ContactUsHandler.ContactUs(model);

            return Request.CreateResponse<string>(HttpStatusCode.OK, "Message sent successfully.");
        }
    }
}
