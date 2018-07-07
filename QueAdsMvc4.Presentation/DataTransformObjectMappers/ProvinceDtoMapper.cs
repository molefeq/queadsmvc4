using QueAds.Common.DataTransformObjects;

using QueAdsMvc4.Presentation.ViewModels;

using System.Linq;

namespace QueAdsMvc4.Presentation.DataTransformObjectMappers
{
    public static class ProvinceDtoMapper
    {
        public static ProvinceViewModel MapFromDto(this ProvinceDto provinceDto)
        {
            ProvinceViewModel provinceViewModel = new ProvinceViewModel();

            provinceViewModel.Id = provinceDto.Id;
            provinceViewModel.Name = provinceDto.Name;

            provinceDto.Cities.ToList().ForEach(item => provinceViewModel.Cities.Add(item.MapFromDto()));

            return provinceViewModel;
        }

        public static void MapToDto(this ProvinceDto provinceDto, ProvinceViewModel provinceViewModel)
        {
            provinceDto.Id = provinceViewModel.Id == null ? int.MinValue : provinceViewModel.Id.Value;
            provinceDto.Name = provinceViewModel.Name;
        }
    }
}
