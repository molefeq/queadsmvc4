using QueAdsMvc4.Presentation.Factories;
using QueAdsMvc4.Presentation.Filters;
using QueAdsMvc4.Presentation.MvcExtensions;
using QueAdsMvc4.Presentation.Utility;
using QueAdsMvc4.Presentation.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace QueAdsMvc4.api
{
    public class PolicyController : BaseApiController
    {
        [HttpGet]
        public HttpResponseMessage GetRecentPolicies(int? categoryId, int? provinceId)
        {
            List<PolicyViewModel> policies = ServiceHandlers.PolicyHandler.GetRecentPolicies(categoryId, provinceId);

            MapPoliciesImages(policies);

            return Request.CreateResponse<List<PolicyViewModel>>(HttpStatusCode.OK, policies);
        }

        [HttpGet]
        public HttpResponseMessage SearchPolicies(int? categoryId, int? subCategoryId, int? provinceId, int? cityId, string searchText, int pageIndex, int pageSize, string offerType)
        {
            DataSourceResult<PolicyViewModel> policies = ServiceHandlers.PolicyHandler.GetPolicies(null, categoryId, subCategoryId, provinceId, cityId, pageIndex, pageSize, offerType, searchText);

            MapPoliciesImages(policies.Data);

            return Request.CreateResponse<DataSourceResult<PolicyViewModel>>(HttpStatusCode.OK, policies);
        }

        [HttpGet]
        [QueAdsAuthorizationFilter()]
        public HttpResponseMessage SearchUserPolicies(int pageIndex, int pageSize, string searchText = "")
        {
            DataSourceResult<PolicyViewModel> policies = ServiceHandlers.PolicyHandler.GetPolicies(UserId, null, null, null, null, pageIndex, pageSize, null, searchText);

            MapPoliciesImages(policies.Data);

            var results = from p in policies.Data
                          group p by p.CreateDateText into g
                          select new GroupResults<PolicyViewModel> { Key = g.Key, Models = g.ToList() };

            return Request.CreateResponse<object>(HttpStatusCode.OK, new { GroupedResults = results, Total = policies.Total });
        }

        [HttpGet]
        public HttpResponseMessage GetUserSearchPreferences()
        {
            var response = new
            {
                Category = SessionBag.Current.Category,
                SubCategory = SessionBag.Current.SubCategory,
                Province = SessionBag.Current.Province,
                City = SessionBag.Current.City,

            };

            return Request.CreateResponse<object>(HttpStatusCode.OK, response);
        }

        [HttpPost]
        public HttpResponseMessage SetUserSearchPreferences(UserSearchPreferencesViewModel model)
        {
            if (model.Category != null)
            {
                SessionBag.Current.Category = new
                {
                    Id = model.Category.Id,
                    Name = model.Category.Name
                };
            }
            else
            {
                SessionBag.Current.Category = null;
            }

            if (model.SubCategory != null)
            {
                SessionBag.Current.SubCategory = new
                {
                    Id = model.SubCategory.Id,
                    Name = model.SubCategory.Name
                };
            }
            else
            {
                SessionBag.Current.SubCategory = null;
            }

            if (model.Province != null)
            {
                SessionBag.Current.Province = new
                {
                    Id = model.Province.Id,
                    Name = model.Province.Name
                };
            }
            else
            {
                SessionBag.Current.Province = null;
            }

            if (model.City != null)
            {
                SessionBag.Current.City = new
                {
                    Id = model.City.Id,
                    Name = model.City.Name
                };
            }
            else
            {
                SessionBag.Current.City = null;
            }

            return Request.CreateResponse<string>(HttpStatusCode.OK, "User search preferences setup correctly.");
        }

        [HttpGet]
        public HttpResponseMessage GetPolicy(int? policyId)
        {
            PolicyViewModel policy = policyId == null ? new PolicyViewModel() : ServiceHandlers.PolicyHandler.SavePolicy(new PolicyViewModel { Id = policyId.Value, CrudOperation = CrudOperation.READ });

            policy.IsAuthenticated = IsAuthenticated;
            MapPolicyImages(policy);

            return Request.CreateResponse<PolicyViewModel>(HttpStatusCode.OK, policy);
        }

        [HttpPost]
        public HttpResponseMessage PolicyReply(PolicyReplyViewModel model)
        {
            ServiceHandlers.PolicyHandler.ReplyToPolicy(model);

            return Request.CreateResponse<string>(HttpStatusCode.OK, "Reply sent successfully.");
        }

        [HttpGet]
        public HttpResponseMessage GetPolicyAdditionalData(int subCategoryId)
        {
            List<PolicySubCategoryAdditionalFieldViewModel> policySubCategoryAdditionalFields = ServiceHandlers.ListHandler.GetSubCategoryAdditionalFields(subCategoryId, string.Empty);
            Dictionary<string, List<string>> policyAdditionalFieldOption = new Dictionary<string, List<string>>();

            foreach (var item in policySubCategoryAdditionalFields.Where(p => p.ControlType == "DropDownList" && string.IsNullOrEmpty(p.ParentFieldName)))
            {
                policyAdditionalFieldOption.Add(item.FieldName, ServiceHandlers.ListHandler.GetFieldValues("SubCategoryAdditionalFields", item.FieldName));
            }


            return Request.CreateResponse<object>(HttpStatusCode.OK, new { policysubcategoryadditionalfields = policySubCategoryAdditionalFields, policyadditionalfieldoptions = policyAdditionalFieldOption });
        }

        [HttpPost]
        public HttpResponseMessage UploadPolicyImage()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                var httpRequest = HttpContext.Current.Request;

                if (httpRequest.Files.Count == 0)
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                List<AdImageInformation> normalAdImageInformations = new List<AdImageInformation> {new AdImageInformation
                {
                    Width = Convert.ToInt32(GetStringAppSetting("PolicyImagesNormalDimension").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0]),
                    Height = Convert.ToInt32(GetStringAppSetting("PolicyImagesNormalDimension").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[1]),
                    PhysicalDirectory = HttpContext.Current.Server.MapPath(GetStringAppSetting("PolicyImagesNormalDirectory")),
                    RelativeDirectory = new Uri(HttpContext.Current.Request.Url, VirtualPathUtility.ToAbsolute(GetStringAppSetting("PolicyImagesNormalDirectory"))).AbsoluteUri
                }
            };

                string fileName = PostedImageHandler.SaveAdUploadedImages(httpRequest.Files[0], normalAdImageInformations);

                return Request.CreateResponse<PolicyImageViewModel>(HttpStatusCode.OK, new PolicyImageViewModel { NormalImageUrl = normalAdImageInformations[0].RelativeFileName, ImageFileName = fileName });


            }
            catch (Exception ex)
            {
                ServiceHandlers.SystemExceptionLogHandler.LogError(ex);
                throw;
            }
        }

        [HttpPost]
        public HttpResponseMessage SavePolicy(PolicyViewModel model)
        {
            if (IsAuthenticated)
            {
                ModelState.RemoveValidation("model.CreateUser");
                ModelState.RemoveValidation("model.RegisterUser");
                model.CreateUserId = UserId;
                model.RegisterUser = null;
            }

            if (model.CrudOperation == CrudOperation.CREATE)
            {
                ModelState.RemoveValidation("model.CreateUser");
                model.CreateUser = null;
            }

            if (!ModelState.IsValid)
            {
                return Request.CreateResponse<object>(HttpStatusCode.OK, new { errors = ToModelStateErrorResult(ModelState) });
            }

            try
            {
                PolicyViewModel policyViewModel = ServiceHandlers.PolicyHandler.SavePolicy(model);

                PolicyAdImagesResize(policyViewModel);

                if (!IsAuthenticated)
                {
                    FormsAuthenticationLogin(policyViewModel.CreateUser);
                }

                return Request.CreateResponse<PolicyViewModel>(HttpStatusCode.OK, policyViewModel);
            }
            catch (ModelStateException ex)
            {
                return Request.CreateResponse<object>(HttpStatusCode.OK, new { errors = ex.ModelErrors });
            }
        }

        #region Private Methods

        private void PolicyAdImagesResize(PolicyViewModel policyViewModel)
        {
            foreach (PolicyImageViewModel policyImageViewModel in policyViewModel.PolicyImages)
            {
                string imageFileName = PostedImageHandler.GetPhysicalFileName(HttpContext.Current.Server.MapPath(GetStringAppSetting("PolicyImagesNormalDirectory")), policyImageViewModel.ImageFileName);
                PostedImageHandler.ResizeImage(imageFileName, policyImageViewModel.ImageFileName,
                    new AdImageInformation
                    {
                        Width = Convert.ToInt32(GetStringAppSetting("PolicyImagesThumbnailsDimension").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0]),
                        Height = Convert.ToInt32(GetStringAppSetting("PolicyImagesThumbnailsDimension").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[1]),
                        PhysicalDirectory = HttpContext.Current.Server.MapPath(GetStringAppSetting("PolicyImagesThumbnailsDirectory")),
                        RelativeDirectory = new Uri(HttpContext.Current.Request.Url, VirtualPathUtility.ToAbsolute(GetStringAppSetting("PolicyImagesThumbnailsDirectory"))).AbsoluteUri
                    });
                PostedImageHandler.ResizeImage(imageFileName, policyImageViewModel.ImageFileName,
                    new AdImageInformation
                    {
                        Width = Convert.ToInt32(GetStringAppSetting("PolicyImagesPreviewDimension").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0]),
                        Height = Convert.ToInt32(GetStringAppSetting("PolicyImagesPreviewDimension").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[1]),
                        PhysicalDirectory = HttpContext.Current.Server.MapPath(GetStringAppSetting("PolicyImagesPreviewDirectory")),
                        RelativeDirectory = new Uri(HttpContext.Current.Request.Url, VirtualPathUtility.ToAbsolute(GetStringAppSetting("PolicyImagesPreviewDirectory"))).AbsoluteUri
                    });
            }

        }

        private void MapPoliciesImages(List<PolicyViewModel> policyViewModels)
        {
            foreach (PolicyViewModel policyViewModel in policyViewModels)
            {
                MapPolicyImages(policyViewModel);
            }
        }

        private void MapPolicyImages(PolicyViewModel policyViewModel)
        {
            if (policyViewModel.PolicyImages == null || policyViewModel.PolicyImages.Count == 0)
            {
                return;
            }

            List<PolicyImageViewModel> policyImages = new List<PolicyImageViewModel>();

            foreach (PolicyImageViewModel policyImageViewModel in policyViewModel.PolicyImages)
            {
                string normalImageUrl = PostedImageHandler.GetExistingRelativeFileName(HttpContext.Current.Server.MapPath(GetStringAppSetting("PolicyImagesNormalDirectory")),
                                                                                                     new Uri(HttpContext.Current.Request.Url, VirtualPathUtility.ToAbsolute(GetStringAppSetting("PolicyImagesNormalDirectory"))).AbsoluteUri,
                                                                                                     policyImageViewModel.ImageFileName);
                if (!string.IsNullOrEmpty(normalImageUrl))
                {
                    policyImageViewModel.NormalImageUrl = normalImageUrl;
                    policyImageViewModel.ThumbnailImageUrl = PostedImageHandler.GetExistingRelativeFileName(HttpContext.Current.Server.MapPath(GetStringAppSetting("PolicyImagesThumbnailsDirectory")),
                                                                                                            new Uri(HttpContext.Current.Request.Url, VirtualPathUtility.ToAbsolute(GetStringAppSetting("PolicyImagesThumbnailsDirectory"))).AbsoluteUri,
                                                                                                            policyImageViewModel.ImageFileName);
                    policyImageViewModel.PreviewImageUrl = PostedImageHandler.GetExistingRelativeFileName(HttpContext.Current.Server.MapPath(GetStringAppSetting("PolicyImagesPreviewDirectory")),
                                                                                                          new Uri(HttpContext.Current.Request.Url, VirtualPathUtility.ToAbsolute(GetStringAppSetting("PolicyImagesPreviewDirectory"))).AbsoluteUri,
                                                                                                          policyImageViewModel.ImageFileName);
                    policyImages.Add(policyImageViewModel);
                }
            }

            policyViewModel.PolicyImages = policyImages;
        }

        private void FormsAuthenticationLogin(UserViewModel userViewModel)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userViewModel.Id.ToString(), DateTime.Now, DateTime.Now.AddMinutes(30),
                                                                             true, "|" + userViewModel.Username,
                                                                             FormsAuthentication.FormsCookiePath);
            string encryptCookie = FormsAuthentication.Encrypt(ticket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptCookie);

            HttpContext.Current.Response.Cookies.Add(authCookie);
        }

        #endregion

    }
}
