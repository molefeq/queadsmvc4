using QueAds.Common.DataTransformObjects;

using QueAdsMvc4.Presentation.ViewModels;

namespace QueAdsMvc4.Presentation.DataTransformObjectMappers
{
    public static class PolicyImageDtoMapper
    {
        public static PolicyImageViewModel MapFromDto(this PolicyImageDto policyImageDto)
        {
            PolicyImageViewModel policyImageViewModel = new PolicyImageViewModel();

            policyImageViewModel.Id = policyImageDto.Id;
            policyImageViewModel.Policy_Id = policyImageDto.Policy_Id;
            policyImageViewModel.ImageFileName = policyImageDto.ImageFileName;
            policyImageViewModel.CreateUser_Id = policyImageDto.CreateUser_Id;

            return policyImageViewModel;
        }

        public static void MapToDto(this PolicyImageDto policyImageDto, PolicyImageViewModel policyImageViewModel)
        {
            policyImageDto.Id = policyImageViewModel.Id;
            policyImageDto.Policy_Id = policyImageViewModel.Policy_Id;
            policyImageDto.ImageFileName = policyImageViewModel.ImageFileName;
            policyImageDto.CreateUser_Id = policyImageViewModel.CreateUser_Id;
        }
    }
}
