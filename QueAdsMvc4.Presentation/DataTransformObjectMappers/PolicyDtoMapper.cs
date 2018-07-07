using QueAds.Common.DataTransformObjects;
using QueAds.Common.Utilities;
using QueAdsMvc4.Presentation.Utility;
using QueAdsMvc4.Presentation.ViewModels;
using System.Linq;

namespace QueAdsMvc4.Presentation.DataTransformObjectMappers
{
    public static class PolicyDtoMapper
    {
        public static PolicyViewModel MapFromDto(this PolicyDto policyDto)
        {
            PolicyViewModel policyViewModel = new PolicyViewModel();

            policyViewModel.Id = policyDto.Id;
            policyViewModel.Category = policyDto.Category.MapFromDto();
            policyViewModel.SubCategory = policyDto.SubCategory.MapFromDto();
            policyViewModel.Province = policyDto.Province.MapFromDto();
            policyViewModel.City = policyDto.City.MapFromDto();
            policyViewModel.CreateUser = policyDto.CreateUser.MapFromDto();
            //policyViewModel.CreateDate = policyDto.CreateDate;
            policyViewModel.CreateDateText = policyDto.CreateDate.ToString("dd/MM/yyyy");
            //policyViewModel.EditDate = policyDto.EditDate;
            policyViewModel.EditDateText = policyDto.EditDate.ToString("dd/MM/yyyy");

            policyViewModel.Subject = policyDto.Subject;
            policyViewModel.Description = policyDto.Description;
            policyViewModel.NegotiableInd = policyDto.NegotiableInd;
            policyViewModel.OfferType = policyDto.OfferType;
            policyViewModel.Price = Converter.NullableTypeToString(policyDto.Price);
            policyViewModel.CrudOperation = CrudOperation.UPDATE;

            if (policyDto.PolicyImages != null && policyDto.PolicyImages.Count > 0)
            {
                policyDto.PolicyImages.ForEach(t => policyViewModel.PolicyImages.Add(t.MapFromDto()));
            }

            if (policyDto.PolicySubCategoryAdditionalFields != null && policyDto.PolicySubCategoryAdditionalFields.Count > 0)
            {
                policyDto.PolicySubCategoryAdditionalFields.ForEach(t => policyViewModel.PolicySubCategoryAdditionalFields.Add(t.MapFromDto()));
            }

            return policyViewModel;
        }

        public static void MapToDto(this PolicyDto policyDto, PolicyViewModel policyViewModel)
        {
            policyDto.Id = policyViewModel.Id == null ? int.MinValue : policyViewModel.Id.Value;

            policyDto.Category.MapToDto(policyViewModel.Category);
            policyDto.SubCategory.MapToDto(policyViewModel.SubCategory);
            policyDto.Province.MapToDto(policyViewModel.Province);
            policyDto.City.MapToDto(policyViewModel.City);

            if (policyViewModel.CrudOperation == CrudOperation.CREATE)
            {
                if (policyViewModel.RegisterUser != null)
                {
                    policyDto.CreateUser.MapToDto(policyViewModel.RegisterUser);
                }
                else
                {
                    policyDto.CreateUser = new UserDto { Id = policyViewModel.CreateUserId.Value };
                }
            }
            else
            {
                policyDto.CreateUser.MapToDto(policyViewModel.CreateUser);
            }

            foreach (PolicyImageViewModel policyImageViewModel in policyViewModel.PolicyImages)
            {
                PolicyImageDto policyImage = new PolicyImageDto();
                policyImage.MapToDto(policyImageViewModel);
                policyDto.PolicyImages.Add(policyImage);
            }

            foreach (PolicySubCategoryAdditionalFieldViewModel policySubCategoryAdditionalFieldViewModel in policyViewModel.PolicySubCategoryAdditionalFields)
            {
                PolicySubCategoryAdditionalFieldDto policySubCategoryAdditionalFieldDto = new PolicySubCategoryAdditionalFieldDto();

                policySubCategoryAdditionalFieldDto.MapToDto(policySubCategoryAdditionalFieldViewModel);
                policyDto.PolicySubCategoryAdditionalFields.Add(policySubCategoryAdditionalFieldDto);
            }

            policyDto.Subject = policyViewModel.Subject;
            policyDto.Description = policyViewModel.Description;
            policyDto.NegotiableInd = policyViewModel.NegotiableInd;
            policyDto.OfferType = policyViewModel.OfferType;
            policyDto.Price = Converter.StringToDecimal(policyViewModel.Price);
        }

        public static void MapToDto(this PolicyDto policyDto, CreateAdViewModel createAdViewModel)
        {
            policyDto.Id = createAdViewModel.Id == null ? int.MinValue : createAdViewModel.Id.Value;

            policyDto.Category.MapToDto(createAdViewModel.Category);
            policyDto.SubCategory.MapToDto(createAdViewModel.SubCategory);
            policyDto.Province.MapToDto(createAdViewModel.Province);
            policyDto.City.MapToDto(createAdViewModel.City);

            if (createAdViewModel.RegisterUser != null)
            {
                policyDto.CreateUser.MapToDto(createAdViewModel.RegisterUser);
            }
            else
            {
                policyDto.CreateUser = new UserDto { Id = createAdViewModel.CreateUserId.Value };
            }

            foreach (PolicyImageViewModel policyImageViewModel in createAdViewModel.PolicyImages)
            {
                PolicyImageDto policyImage = new PolicyImageDto();
                policyImage.MapToDto(policyImageViewModel);
                policyDto.PolicyImages.Add(policyImage);
            }

            foreach (PolicySubCategoryAdditionalFieldViewModel policySubCategoryAdditionalFieldViewModel in createAdViewModel.PolicySubCategoryAdditionalFields)
            {
                PolicySubCategoryAdditionalFieldDto policySubCategoryAdditionalFieldDto = new PolicySubCategoryAdditionalFieldDto();

                policySubCategoryAdditionalFieldDto.MapToDto(policySubCategoryAdditionalFieldViewModel);
                policyDto.PolicySubCategoryAdditionalFields.Add(policySubCategoryAdditionalFieldDto);
            }

            policyDto.Subject = createAdViewModel.Subject;
            policyDto.Description = createAdViewModel.Description;
            policyDto.NegotiableInd = createAdViewModel.NegotiableInd;
            policyDto.OfferType = createAdViewModel.OfferType;
            policyDto.Price = Converter.StringToDecimal(createAdViewModel.Price);
        }

    }
}
