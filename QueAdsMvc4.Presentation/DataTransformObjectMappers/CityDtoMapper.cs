using QueAds.Common.DataTransformObjects;

using QueAdsMvc4.Presentation.ViewModels;

namespace QueAdsMvc4.Presentation.DataTransformObjectMappers
{
    public static class CityDtoMapper
    {
        public static CityViewModel MapFromDto(this CityDto cityDto)
        {
            CityViewModel cityViewModel = new CityViewModel();

            cityViewModel.Id = cityDto.Id;
            cityViewModel.Name = cityDto.Name;
            cityViewModel.Provinces_Id = cityDto.Provinces_Id;

            return cityViewModel;
        }

        public static void MapToDto(this CityDto cityDto, CityViewModel cityViewModel)
        {
            cityDto.Id = cityViewModel.Id == null ? int.MinValue : cityViewModel.Id.Value;
            cityDto.Name = cityViewModel.Name;
        }
    }
}
