using Microsoft.Web.WebPages.OAuth;

namespace QueAdsMvc4.App_Start
{
    public class AuthConfig
    {
        public static void RegisterAuth()
        {
            OAuthWebSecurity.RegisterFacebookClient(
                appId: "473316002869830",
                appSecret: "5d4dcdad8b4f130bd9dd7d0e89687114");
        }
    }
}