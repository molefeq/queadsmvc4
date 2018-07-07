using QueAds.Common.Utilities;
using QueAdsMvc4.Presentation.Utility;
using QueAdsMvc4.Presentation.ViewModels;

namespace QueAdsMvc4.Presentation.ServiceHandlers.Interfaces
{
    public interface IUserHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UserViewModel Login(string username, string password);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        UserViewModel PasswordReset(string username);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        UserViewModel PasswordChange(string username, string oldPassword, string newPassword);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="crudStatus"></param>
        /// <returns></returns>
        UserViewModel RegisterUser(RegisterUserViewModel model, CrudStatus crudStatus);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDto"></param>
        /// <param name="crudOperation"></param>
        /// <returns></returns>
        UserViewModel SaveUser(UserViewModel model, CrudOperation crudOperation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        UserViewModel RegisterUser(RegisterUserViewModel model);
    }
}
