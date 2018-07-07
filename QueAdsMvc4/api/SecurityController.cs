using QueAdsMvc4.Presentation.Factories;
using QueAdsMvc4.Presentation.Filters;
using QueAdsMvc4.Presentation.MvcExtensions;
using QueAdsMvc4.Presentation.Utility;
using QueAdsMvc4.Presentation.ViewModels;

using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace QueAdsMvc4c.api
{
    public class SecurityController : BaseApiController
    {
        [HttpPost]
        public HttpResponseMessage Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse<object>(HttpStatusCode.OK, new { errors = ToModelStateErrorResult(ModelState) });
            }

            try
            {
                UserViewModel userViewModel = ServiceHandlers.UserHandler.Login(model.UserName, model.Password);

                if (!userViewModel.FirstTimeLogIn)
                {
                    FormsAuthenticationLogin(userViewModel);
                }

                return Request.CreateResponse<UserViewModel>(HttpStatusCode.OK, userViewModel);
            }
            catch (ModelStateException ex)
            {
                return Request.CreateResponse<object>(HttpStatusCode.OK, new { errors = ex.ModelErrors });
            }
        }
        
        [HttpPost]
        public HttpResponseMessage RegisterUser(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse<object>(HttpStatusCode.OK, new { errors = ToModelStateErrorResult(ModelState) });
            }

            try
            {
                UserViewModel response = ServiceHandlers.UserHandler.RegisterUser(model);

                FormsAuthenticationLogin(response);

                return Request.CreateResponse<string>(HttpStatusCode.OK, "Register Successful.");
            }
            catch (ModelStateException ex)
            {
                return Request.CreateResponse<object>(HttpStatusCode.OK, new { errors = ex.ModelErrors });
            }
        }

        [HttpGet]
        [QueAdsAuthorizationFilter()]
        public HttpResponseMessage Logoff()
        {
            LogOff();
            return Request.CreateResponse<string>(HttpStatusCode.OK, "Logoff Successful.");
        }

        [HttpGet]
        [QueAdsAuthorizationFilter()]
        public HttpResponseMessage GetUser()
        {
            UserViewModel user = ServiceHandlers.UserHandler.SaveUser(new UserViewModel { Id = UserId }, CrudOperation.READ);
            return Request.CreateResponse<UserViewModel>(HttpStatusCode.OK, user);
        }

        [HttpPost]
        [QueAdsAuthorizationFilter()]
        public HttpResponseMessage EditUser(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse<object>(HttpStatusCode.OK, new { errors = ToModelStateErrorResult(ModelState) });
            }

            try
            {
                UserViewModel response = ServiceHandlers.UserHandler.SaveUser(model, CrudOperation.UPDATE);

                return Request.CreateResponse<string>(HttpStatusCode.OK, "User Information Update Successful.");
            }
            catch (ModelStateException ex)
            {
                return Request.CreateResponse<object>(HttpStatusCode.OK, new { errors = ex.ModelErrors });
            }
        }

        [HttpPost]
        public HttpResponseMessage ResetPassword(string userName)
        {
            try
            {
                UserViewModel userViewModel = ServiceHandlers.UserHandler.PasswordReset(userName);

                return Request.CreateResponse<string>(HttpStatusCode.OK, "Password Reset Was Successful.");
            }
            catch (ModelStateException ex)
            {
                return Request.CreateResponse<object>(HttpStatusCode.OK, new { errors = ex.ModelErrors });
            }
        }
        
        [HttpPost]
        public HttpResponseMessage ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                UserViewModel userViewModel = ServiceHandlers.UserHandler.PasswordChange(model.UserName, model.Password, model.NewPassword);

                FormsAuthenticationLogin(userViewModel);

                return Request.CreateResponse<string>(HttpStatusCode.OK, "Password Change Was Successful.");
            }
            catch (ModelStateException ex)
            {
                return Request.CreateResponse<object>(HttpStatusCode.OK, new { errors = ex.ModelErrors });
            }
        }

        #region Private Methods

        private void FormsAuthenticationLogin(UserViewModel userViewModel)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userViewModel.Id.ToString(), DateTime.Now, DateTime.Now.AddMinutes(30),
                                                                             true, "|" + userViewModel.Username,
                                                                             FormsAuthentication.FormsCookiePath);
            string encryptCookie = FormsAuthentication.Encrypt(ticket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptCookie);

            HttpContext.Current.Response.Cookies.Add(authCookie);
        }

        private void LogOff()
        {
            HttpContext.Current.Session.Abandon();

            // clear authentication cookie
            HttpCookie formsAuthenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            formsAuthenticationCookie.Expires = DateTime.Now.AddYears(-1);
            HttpContext.Current.Response.Cookies.Add(formsAuthenticationCookie);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            HttpCookie sessionCookie = new HttpCookie("ASP.NET_SessionId", "");
            sessionCookie.Expires = DateTime.Now.AddYears(-1);
            HttpContext.Current.Response.Cookies.Add(sessionCookie);
        }

        #endregion
    }
}
