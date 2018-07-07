using QueAdsMvc4.Presentation.Filters;

using System.Web.Mvc;

namespace QueAdsMvc4.Controllers
{
    public class AdsController : Controller
    {
        public ActionResult ViewAds(string province, string city)
        {
            return View();
        }

        public ActionResult ViewAd(int? policyId)
        {
            return View();
        }

        public ActionResult CreateAd()
        {
            return View();
        }

        public ActionResult EditAd(int policyId)
        {
            return View();
        }

        [QueAdsAuthorizationFilter()]
        public ActionResult UserAds()
        {
            return View();
        }

    }
}
