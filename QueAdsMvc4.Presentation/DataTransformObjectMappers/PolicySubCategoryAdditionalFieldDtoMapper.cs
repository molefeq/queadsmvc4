using QueAds.Common.DataTransformObjects;
using QueAdsMvc4.Presentation.ViewModels;

namespace QueAdsMvc4.Presentation.DataTransformObjectMappers
{
    public static class PolicySubCategoryAdditionalFieldDtoMapper
    {
        public static PolicySubCategoryAdditionalFieldViewModel MapFromDto(this PolicySubCategoryAdditionalFieldDto policySubCategoryAdditionalFieldDto)
        {
            PolicySubCategoryAdditionalFieldViewModel policySubCategoryAdditionalFieldViewModel = new PolicySubCategoryAdditionalFieldViewModel();

            policySubCategoryAdditionalFieldViewModel.Id = policySubCategoryAdditionalFieldDto.Id;
            policySubCategoryAdditionalFieldViewModel.Value = policySubCategoryAdditionalFieldDto.Value;
            policySubCategoryAdditionalFieldViewModel.Policies_Id = policySubCategoryAdditionalFieldDto.Policies_Id;

            if (policySubCategoryAdditionalFieldDto.SubCategoryAdditionalField != null)
            {
                policySubCategoryAdditionalFieldViewModel.SubCategoryAdditionalFields_Id = policySubCategoryAdditionalFieldDto.SubCategoryAdditionalField.Id;
                policySubCategoryAdditionalFieldViewModel.SubCategories_Id = policySubCategoryAdditionalFieldDto.SubCategoryAdditionalField.SubCategories_Id;
                policySubCategoryAdditionalFieldViewModel.FieldName = policySubCategoryAdditionalFieldDto.SubCategoryAdditionalField.FieldName;
                policySubCategoryAdditionalFieldViewModel.ChildFieldName = policySubCategoryAdditionalFieldDto.SubCategoryAdditionalField.ChildFieldName;
                policySubCategoryAdditionalFieldViewModel.ParentFieldName = policySubCategoryAdditionalFieldDto.SubCategoryAdditionalField.ParentFieldName;
                policySubCategoryAdditionalFieldViewModel.DisplayText = policySubCategoryAdditionalFieldDto.SubCategoryAdditionalField.DisplayText;
                policySubCategoryAdditionalFieldViewModel.DataType = policySubCategoryAdditionalFieldDto.SubCategoryAdditionalField.DataType;
                policySubCategoryAdditionalFieldViewModel.ControlType = policySubCategoryAdditionalFieldDto.SubCategoryAdditionalField.ControlType;
                policySubCategoryAdditionalFieldViewModel.SortOrder = policySubCategoryAdditionalFieldDto.SubCategoryAdditionalField.SortOrder;
                policySubCategoryAdditionalFieldViewModel.RequiredInd = policySubCategoryAdditionalFieldDto.SubCategoryAdditionalField.RequiredInd;
                policySubCategoryAdditionalFieldViewModel.ControlName = "PolicySubCategoryAdditionalField_" + policySubCategoryAdditionalFieldDto.SubCategoryAdditionalField.FieldName;
            }

            return policySubCategoryAdditionalFieldViewModel;
        }

        public static PolicySubCategoryAdditionalFieldViewModel MapFromDto(this SubCategoryAdditionalFieldDto subCategoryAdditionalFieldDto)
        {
            PolicySubCategoryAdditionalFieldViewModel policySubCategoryAdditionalFieldViewModel = new PolicySubCategoryAdditionalFieldViewModel();

            if (subCategoryAdditionalFieldDto != null)
            {
                policySubCategoryAdditionalFieldViewModel.SubCategoryAdditionalFields_Id = subCategoryAdditionalFieldDto.Id;
                policySubCategoryAdditionalFieldViewModel.SubCategories_Id = subCategoryAdditionalFieldDto.SubCategories_Id;
                policySubCategoryAdditionalFieldViewModel.FieldName = subCategoryAdditionalFieldDto.FieldName;
                policySubCategoryAdditionalFieldViewModel.ChildFieldName = subCategoryAdditionalFieldDto.ChildFieldName;
                policySubCategoryAdditionalFieldViewModel.ParentFieldName = subCategoryAdditionalFieldDto.ParentFieldName;
                policySubCategoryAdditionalFieldViewModel.DisplayText = subCategoryAdditionalFieldDto.DisplayText;
                policySubCategoryAdditionalFieldViewModel.DataType = subCategoryAdditionalFieldDto.DataType;
                policySubCategoryAdditionalFieldViewModel.ControlType = subCategoryAdditionalFieldDto.ControlType;
                policySubCategoryAdditionalFieldViewModel.SortOrder = subCategoryAdditionalFieldDto.SortOrder;
                policySubCategoryAdditionalFieldViewModel.RequiredInd = subCategoryAdditionalFieldDto.RequiredInd;
                policySubCategoryAdditionalFieldViewModel.ControlName = "PolicySubCategoryAdditionalField_" + subCategoryAdditionalFieldDto.FieldName;
            }

            return policySubCategoryAdditionalFieldViewModel;
        }

        public static void MapToDto(this PolicySubCategoryAdditionalFieldDto policySubCategoryAdditionalFieldDto, PolicySubCategoryAdditionalFieldViewModel policySubCategoryAdditionalFieldViewModel)
        {
            policySubCategoryAdditionalFieldDto.Id = policySubCategoryAdditionalFieldViewModel.Id == null ? int.MinValue : policySubCategoryAdditionalFieldViewModel.Id.Value;
            policySubCategoryAdditionalFieldDto.Value = policySubCategoryAdditionalFieldViewModel.Value;

            policySubCategoryAdditionalFieldDto.SubCategoryAdditionalField = new SubCategoryAdditionalFieldDto()
            {
                Id = policySubCategoryAdditionalFieldViewModel.SubCategoryAdditionalFields_Id,
                SubCategories_Id = policySubCategoryAdditionalFieldViewModel.SubCategories_Id,
                FieldName = policySubCategoryAdditionalFieldViewModel.FieldName,
                ChildFieldName = policySubCategoryAdditionalFieldViewModel.ChildFieldName,
                ParentFieldName = policySubCategoryAdditionalFieldViewModel.ParentFieldName,
                DisplayText = policySubCategoryAdditionalFieldViewModel.DisplayText,
                DataType = policySubCategoryAdditionalFieldViewModel.DataType,
                ControlType = policySubCategoryAdditionalFieldViewModel.ControlType,
                SortOrder = policySubCategoryAdditionalFieldViewModel.SortOrder,
                RequiredInd = policySubCategoryAdditionalFieldViewModel.RequiredInd
            };

            policySubCategoryAdditionalFieldDto.Policies_Id = policySubCategoryAdditionalFieldViewModel.Policies_Id == null ? int.MinValue : policySubCategoryAdditionalFieldViewModel.Policies_Id.Value;
        }
    }
}
