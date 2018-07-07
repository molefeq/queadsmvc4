using QueAdsMvc4.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueAdsMvc4.Presentation.ServiceHandlers.Interfaces
{
    public interface ICategoryHandler
    {
        List<CategoryViewModel> GetCategories(string searchText, int? subCategoryId, int? provinceId, int? cityId, string offerType, string policySearchText);
        CategoryViewModel GetCategory(int categoryId, int? subCategoryId, int? provinceId, int? cityId, string offerType, string policySearchText);
    }
}
