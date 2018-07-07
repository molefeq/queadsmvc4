using QueAdsMvc4.Presentation.ViewModels;

using System.Collections.Generic;

namespace QueAdsMvc4.Presentation.ServiceHandlers.Interfaces
{
    public interface IListHandler
    {
        List<string> GetFieldValues(string tableName, string fieldName);
        List<string> GetChildFieldValues(string tableName, string fieldName, string childFieldName, string fieldValue);
        List<SubCategoryViewModel> GetSubCategories(int? categoryId, string searchText, int? provinceId, int? cityId, string offerType, string policySearchText);
        List<PolicySubCategoryAdditionalFieldViewModel> GetSubCategoryAdditionalFields(int subcategoryId, string searchText);
    }
}
