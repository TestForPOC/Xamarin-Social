using System;
using Xamarin.Forms;
namespace XamarinSocial.Configurations
{
    public class AuthConfig
    {
        public static class FacebookConfig
        {
            public const string ClientId = "2082328572069158";
            public const string Scope = "email";
            public const string AuthorizeUrl = "https://www.facebook.com/dialog/oauth/";
            public const string RedirectUrl = "https://www.facebook.com/connect/login_success.html";
        }
        public static class LinkedInConfig
        {
            public const string ClientId = "81pep2rqrfkt1x";
            public const string ClientSecret = "2zPsdhDJIsSlAJC6";
            public const string Scope = "r_basicprofile r_emailaddress";
            public const string AuthorizeUrl = "https://www.linkedin.com/uas/oauth2/authorization";
            public const string RedirectUrl = "https://www.linkedin.com/oauth-success";
            public const string AccessTokenUrl = "https://www.linkedin.com/uas/oauth2/accessToken";
        }
        public static class GoogleConfig
        {
            //public const string ClientId = Device.=TargetPlatform.Android? ==

            //"2082328572069158";
            public const string AuthorizeUrl = "https://www.linkedin.com/uas/oauth2/authorization";
            public const string RedirectUrl = "http://devenvexe.com/";
            public const string AccessTokenUrl = "https://www.linkedin.com/uas/oauth2/accessToken";
        }

    }
}
