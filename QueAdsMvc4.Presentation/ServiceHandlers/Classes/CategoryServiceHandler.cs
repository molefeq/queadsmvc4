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
    public class CategoryServiceHandler : ICategoryHandler
    {
        public List<CategoryViewModel> GetCategories(string searchText, int? subCategoryId, int? provinceId, int? cityId, string offerType, string policySearchText)
        {
            Result<CategoryDto> response = EntityFactory.CategoryManager.GetCategories(new SearchObject { SearchText = searchText }, new PolicyFilter
            {
                IncludeFilter = true,
                SubCategoryId = subCategoryId,
                ProvinceId = provinceId,
                CityId = cityId,
                SearchText = policySearchText,
                OfferType = offerType
            });

            return response == null && response.Models == null && response.Models.Count == 0 ? new List<CategoryViewModel>() : response.Models.OrderBy(c => c.Name).Select(item => item.MapFromDto()).ToList();
        }

        public CategoryViewModel GetCategory(int categoryId, int? subCategoryId, int? provinceId, int? cityId, string offerType, string policySearchText)
        {
            CategoryDto response = EntityFactory.CategoryManager.GetCategory(categoryId, new PolicyFilter
            {
                IncludeFilter = true,
                SubCategoryId = subCategoryId,
                ProvinceId = provinceId,
                CityId = cityId,
                SearchText = policySearchText,
                OfferType = offerType
            });

            return response == null ? new CategoryViewModel() : response.MapFromDto();
        }
    }
}
