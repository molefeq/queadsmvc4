using QueAds.Common.DataTransformObjects;

using QueAdsMvc4.Presentation.ViewModels;

using System.Linq;

namespace QueAdsMvc4.Presentation.DataTransformObjectMappers
{
    public static class CategoryDtoMapper
    {
        public static CategoryViewModel MapFromDto(this CategoryDto categoryDto)
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();

            categoryViewModel.Id = categoryDto.Id;
            categoryViewModel.Name = categoryDto.Name;
            categoryViewModel.PolicyCount = categoryDto.PolicyCount;

            categoryDto.SubCategories.ToList().ForEach(item => categoryViewModel.SubCategories.Add(item.MapFromDto()));

            return categoryViewModel;
        }

        public static void MapToDto(this CategoryDto categoryDto, CategoryViewModel categoryViewModel)
        {
            categoryDto.Id = categoryViewModel.Id == null ? int.MinValue : categoryViewModel.Id.Value;
            categoryDto.Name = categoryViewModel.Name;
        }
    }
}
