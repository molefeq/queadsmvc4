using QueAdsMvc4.Presentation.Utility;
using QueAdsMvc4.Presentation.ViewModels;

using System.Collections.Generic;

namespace QueAdsMvc4.Presentation.ServiceHandlers.Interfaces
{
    public interface IPolicyHandler
    {
        List<PolicyViewModel> GetRecentPolicies(int? categoryId, int? provinceId);
        DataSourceResult<PolicyViewModel> GetPolicies(int? userId, int? categoryId, int? subCategoryId, int? provinceId, int? cityId, int pageIndex, int pageSize, string offerType, string searchText);
        PolicyViewModel SavePolicy(PolicyViewModel model);
        PolicyViewModel CreateAd(CreateAdViewModel model);
        void ReplyToPolicy(PolicyReplyViewModel model);
    }
}
