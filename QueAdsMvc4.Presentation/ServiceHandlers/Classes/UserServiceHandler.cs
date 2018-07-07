using QueAds.Common.DataTransformObjects;
using QueAds.Common.ResponseObjects;
using QueAds.Common.Utilities;

using QueAds.Service.Presentation.Factories;

using QueAdsMvc4.Presentation.DataTransformObjectMappers;
using QueAdsMvc4.Presentation.ServiceHandlers.Interfaces;
using QueAdsMvc4.Presentation.Utility;
using QueAdsMvc4.Presentation.ViewModels;

using System.Linq;

namespace QueAdsMvc4.Presentation.ServiceHandlers.Classes
{
    public class UserServiceHandler : IUserHandler
    {
        public UserViewModel Login(string username, string password)
        {
            Response<UserDto> response = EntityFactory.UserManager.Login(username, password);

            if (response.HasErrors)
            {
                ModelStateException modelStateException = new ModelStateException();
                response.ErrorMessages.ToList().ForEach(item => modelStateException.ModelErrors.Add(new ModelStateError() { FieldName = item.FieldName, Message = item.Message }));

                throw modelStateException;
            }

            return response.Model.MapFromDto();
        }

        public UserViewModel PasswordReset(string username)
        {
            Response<UserDto> response = EntityFactory.UserManager.PasswordReset(username);

            if (response.HasErrors)
            {
                ModelStateException modelStateException = new ModelStateException();
                response.ErrorMessages.ToList().ForEach(item => modelStateException.ModelErrors.Add(new ModelStateError() { FieldName = item.FieldName, Message = item.Message }));

                throw modelStateException;
            }

            return response.Model.MapFromDto();
        }

        public UserViewModel PasswordChange(string username, string oldPassword, string newPassword)
        {
            Response<UserDto> response = EntityFactory.UserManager.PasswordChange(username, oldPassword, newPassword);

            if (response.HasErrors)
            {
                ModelStateException modelStateException = new ModelStateException();
                response.ErrorMessages.ToList().ForEach(item => modelStateException.ModelErrors.Add(new ModelStateError() { FieldName = item.FieldName, Message = item.Message }));

                throw modelStateException;
            }

            return response.Model.MapFromDto();
        }

        public UserViewModel RegisterUser(RegisterUserViewModel model, CrudStatus crudStatus)
        {
            UserDto user = new UserDto();

            user.MapToDto(model);

            Response<UserDto> response = EntityFactory.UserManager.SaveUser(user, crudStatus);

            if (response.HasErrors)
            {
                ModelStateException modelStateException = new ModelStateException();
                response.ErrorMessages.ToList().ForEach(item => modelStateException.ModelErrors.Add(new ModelStateError() { FieldName = item.FieldName, Message = item.Message }));

                throw modelStateException;
            }

            return response.Model.MapFromDto();
        }

        public UserViewModel RegisterUser(RegisterUserViewModel model)
        {
            UserDto user = new UserDto();

            user.MapToDto(model);

            Response<UserDto> response = EntityFactory.UserManager.SaveUser(user, CrudStatus.CREATE);

            if (response.HasErrors)
            {
                ModelStateException modelStateException = new ModelStateException();
                response.ErrorMessages.ToList().ForEach(item => modelStateException.ModelErrors.Add(new ModelStateError() { FieldName = item.FieldName, Message = item.Message }));

                throw modelStateException;
            }

            return response.Model.MapFromDto();
        }

        public UserViewModel SaveUser(UserViewModel model, CrudOperation crudOperation)
        {
            UserDto user = new UserDto();
            CrudStatus crudStatus = CrudStatusMapper.MapToEnum(crudOperation);

            user.MapToDto(model);

            Response<UserDto> response = EntityFactory.UserManager.SaveUser(user, crudStatus);

            if (response.HasErrors)
            {
                ModelStateException modelStateException = new ModelStateException();
                response.ErrorMessages.ToList().ForEach(item => modelStateException.ModelErrors.Add(new ModelStateError() { FieldName = item.FieldName, Message = item.Message }));

                throw modelStateException;
            }

            return response.Model.MapFromDto();
        }
    }
}
