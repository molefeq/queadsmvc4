using QueAds.Common.DataTransformObjects;
using QueAds.Common.ResponseObjects;
using QueAds.Common.Utilities;

using QueAds.Service.Presentation.Factories;

using QueAdsMvc4.Presentation.DataTransformObjectMappers;
using QueAdsMvc4.Presentation.ServiceHandlers.Interfaces;
using QueAdsMvc4.Presentation.ViewModels;

using System.Collections.Generic;
using System.Linq;

namespace QueAdsMvc4.Presentation.ServiceHandlers.Classes
{
    public class ListServiceHandler : IListHandler
    {
        public List<string> GetFieldValues(string tableName, string fieldName)
        {
            return EntityFactory.ListManager.GetFieldValues(tableName, fieldName, null);
        }

        public List<string> GetChildFieldValues(string tableName, string fieldName, string childFieldName, string fieldValue)
        {
            return EntityFactory.ListManager.GetChildFieldValues(tableName, fieldName, childFieldName, fieldValue);
        }

        public List<SubCategoryViewModel> GetSubCategories(int? categoryId, string searchText, int? provinceId, int? cityId, string offerType, string policySearchText)
        {
            Result<SubCategoryDto> response = EntityFactory.SubCategoryManager.GetSubCategories(categoryId, new SearchObject { SearchText = searchText }, new PolicyFilter
            {
                IncludeFilter = true,
                ProvinceId = provinceId,
                CityId = cityId,
                SearchText = policySearchText,
                OfferType = offerType
            });

            return response == null && response.Models == null && response.Models.Count == 0 ? new List<SubCategoryViewModel>() : response.Models.Select(item => item.MapFromDto()).ToList();
        }

        public List<PolicySubCategoryAdditionalFieldViewModel> GetSubCategoryAdditionalFields(int subcategoryId, string searchText)
        {
            Result<SubCategoryAdditionalFieldDto> response = EntityFactory.SubCategoryAdditionalFieldManager.GetSubCategoryAdditionalFields(subcategoryId, new SearchObject { SearchText = searchText });

            return response == null && response.Models == null && response.Models.Count == 0 ? new List<PolicySubCategoryAdditionalFieldViewModel>() : response.Models.Select(item => item.MapFromDto()).ToList();
        }
    }
}
