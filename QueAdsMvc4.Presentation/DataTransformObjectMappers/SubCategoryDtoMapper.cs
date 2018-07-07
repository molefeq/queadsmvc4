using QueAds.Common.DataTransformObjects;
using QueAdsMvc4.Presentation.ViewModels;

namespace QueAdsMvc4.Presentation.DataTransformObjectMappers
{
    public static class SubCategoryDtoMapper
    {
        public static SubCategoryViewModel MapFromDto(this SubCategoryDto subCategoryDto)
        {
            SubCategoryViewModel subCategoryViewModel = new SubCategoryViewModel();

            subCategoryViewModel.Id = subCategoryDto.Id;
            subCategoryViewModel.Name = subCategoryDto.Name;
            subCategoryViewModel.Categories_Id = subCategoryDto.Categories_Id;
            subCategoryViewModel.PolicyCount = subCategoryDto.PolicyCount;

            return subCategoryViewModel;
        }

        public static void MapToDto(this SubCategoryDto subCategoryDto, SubCategoryViewModel subCategoryViewModel)
        {
            subCategoryDto.Id = subCategoryViewModel.Id == null ? int.MinValue : subCategoryViewModel.Id.Value;
            subCategoryDto.Name = subCategoryViewModel.Name;
        }
    }
}
