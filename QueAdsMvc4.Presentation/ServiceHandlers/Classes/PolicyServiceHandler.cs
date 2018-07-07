using QueAds.Common.DataTransformObjects;
using QueAds.Common.ResponseObjects;
using QueAds.Common.Utilities;

using QueAds.Service.Presentation.Factories;

using QueAdsMvc4.Presentation.DataTransformObjectMappers;
using QueAdsMvc4.Presentation.ServiceHandlers.Interfaces;
using QueAdsMvc4.Presentation.Utility;
using QueAdsMvc4.Presentation.ViewModels;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace QueAdsMvc4.Presentation.ServiceHandlers.Classes
{
    public class PolicyServiceHandler : IPolicyHandler
    {
        public List<PolicyViewModel> GetRecentPolicies(int? categoryId, int? provinceId)
        {
            List<PolicyDto> response = EntityFactory.PolicyManager.GetRecentPolicies(new PolicyFilter
            {
                IncludeFilter = true,
                CategoryId = categoryId,
                ProvinceId = provinceId
            });

            return response == null ? new List<PolicyViewModel>() : response.Select(item => item.MapFromDto()).ToList();
        }

        public DataSourceResult<PolicyViewModel> GetPolicies(int? userId, int? categoryId, int? subCategoryId, int? provinceId, int? cityId, int pageIndex, int pageSize, string offerType, string searchText)
        {
            Result<PolicyDto> response = EntityFactory.PolicyManager.GetPolicies(new PolicyFilter
            {
                IncludeFilter = true,
                UserId = userId,
                CategoryId = categoryId,
                SubCategoryId = subCategoryId,
                ProvinceId = provinceId,
                CityId = cityId,
                OfferType = offerType,
                SearchText = searchText
            }
                , new SearchObject
            {
                IsPageable = true,
                PageIndex = pageIndex,
                PageSize = pageSize,
                SortColumn = "CreateDate",
                SortOrder = SortOrder.DESCENDING
            });

            return new DataSourceResult<PolicyViewModel>()
            {
                Total = response.Total,
                Data = response == null && response.Models == null && response.Models.Count == 0 ? new List<PolicyViewModel>() : response.Models.Select(item => item.MapFromDto()).ToList()
            };
        }

        public PolicyViewModel SavePolicy(PolicyViewModel model)
        {
            PolicyDto policy = new PolicyDto();
            CrudStatus crudStatus = CrudStatusMapper.MapToEnum(model.CrudOperation);

            policy.MapToDto(model);

            Response<PolicyDto> response = EntityFactory.PolicyManager.SavePolicy(policy, crudStatus);

            if (response.HasErrors)
            {
                ModelStateException modelStateException = new ModelStateException();
                response.ErrorMessages.ToList().ForEach(item => modelStateException.ModelErrors.Add(new ModelStateError() { FieldName = item.FieldName, Message = item.Message }));

                throw modelStateException;
            }

            return model.CrudOperation == CrudOperation.DELETE ? new PolicyViewModel() : response.Model.MapFromDto();
        }

        public PolicyViewModel CreateAd(CreateAdViewModel model)
        {
            PolicyDto policy = new PolicyDto();

            policy.MapToDto(model);

            Response<PolicyDto> response = EntityFactory.PolicyManager.SavePolicy(policy, CrudStatus.CREATE);

            if (response.HasErrors)
            {
                ModelStateException modelStateException = new ModelStateException();
                response.ErrorMessages.ToList().ForEach(item => modelStateException.ModelErrors.Add(new ModelStateError() { FieldName = item.FieldName, Message = item.Message }));

                throw modelStateException;
            }

            return response.Model.MapFromDto();
        }

        public void ReplyToPolicy(PolicyReplyViewModel model)
        {
            string smtpServerAddress = ConfigurationManager.AppSettings["SMTPAddress"];
            int smtpPortNumber = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPortNumber"]);
            string fromAddress = ConfigurationManager.AppSettings["FromAddress"];
            string url = string.Format("{0}/AdsManagement/AdsManagement/ViewAd?policyId={1}", ConfigurationManager.AppSettings["SiteUrl"], model.Policy_Id);
            string toEmailAddress = model.Policy_Create_EmailAddress;

            string subject = string.Format("Re: {0}", model.Subject);

            StringBuilder sb = new StringBuilder();

            // Add email heading
            model.Name = string.IsNullOrEmpty(model.Name) ? "Someone" : model.Name;

            sb.Append(string.Format("{0} <{1}> has replied to your ad.", model.Name, model.EmailAddress));
            sb.Append("<br />");
            sb.Append(url);
            sb.Append("<br />");
            sb.Append("<br />");
            sb.Append("Here is the text of the reply");
            sb.Append("<br />");
            sb.Append("<br />");
            sb.Append(string.Format("{0}.", model.Message));
            sb.Append("<br />");
            sb.Append("<br />");
            sb.Append("Thank you,");
            sb.Append("<br />");
            sb.Append("Queads.co.za");

            EmailHandler.SendEmail(smtpServerAddress, smtpPortNumber, fromAddress, toEmailAddress, null, subject, sb.ToString());
        }
    }
}
