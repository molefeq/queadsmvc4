using QueAds.Common.DataTransformObjects;

using QueAdsMvc4.Presentation.ViewModels;

namespace QueAdsMvc4.Presentation.DataTransformObjectMappers
{
    public static class UserDtoMapper
    {
        public static UserViewModel MapFromDto(this UserDto userDto)
        {
            UserViewModel userViewModel = new UserViewModel();

            userViewModel.Id = userDto.Id;
            userViewModel.Firstnames = userDto.Firstnames;
            userViewModel.Lastname = userDto.Lastname;
            userViewModel.Username = userDto.Username;
            userViewModel.MobileNumber = userDto.MobileNumber;
            userViewModel.EmailAddress = userDto.EmailAddress;
            userViewModel.FirstTimeLogIn = userDto.FirstTimeLogIn;

            return userViewModel;
        }

        public static RegisterUserViewModel MapFromDtoToRegisterViewModel(this UserDto userDto)
        {
            RegisterUserViewModel userViewModel = new RegisterUserViewModel();

            userViewModel.Id = userDto.Id;
            userViewModel.Firstnames = userDto.Firstnames;
            userViewModel.Lastname = userDto.Lastname;
            userViewModel.UserName = userDto.Username;
            userViewModel.MobileNumber = userDto.MobileNumber;
            userViewModel.EmailAddress = userDto.EmailAddress;

            return userViewModel;
        }

        public static void MapToDto(this UserDto userDto, UserViewModel userViewModel)
        {
            userDto.Id = userViewModel.Id == null ? int.MinValue : userViewModel.Id.Value;
            userDto.Firstnames = userViewModel.Firstnames;
            userDto.Lastname = userViewModel.Lastname;
            userDto.Username = userViewModel.Username;
            userDto.MobileNumber = userViewModel.MobileNumber;
            userDto.EmailAddress = userViewModel.EmailAddress;
        }

        public static void MapToDto(this UserDto userDto, RegisterUserViewModel registerUserViewModel)
        {
            userDto.Id = registerUserViewModel.Id == int.MinValue || registerUserViewModel.Id == 0 ? int.MinValue : registerUserViewModel.Id;
            userDto.Firstnames = registerUserViewModel.Firstnames;
            userDto.Lastname = registerUserViewModel.Lastname;
            userDto.Username = registerUserViewModel.UserName;
            userDto.PasswordText = registerUserViewModel.Password;
            userDto.MobileNumber = registerUserViewModel.MobileNumber;
            userDto.EmailAddress = registerUserViewModel.EmailAddress;
        }
    }
}
