using System;
using Newtonsoft.Json.Linq;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinSocial.iOS.Renderers;
using XamarinSocial.Views;
using static XamarinSocial.Configurations.AuthConfig;

[assembly: ExportRenderer(typeof(FacebookLoginPage), typeof(FacebookLoginPageRenderer))]
namespace XamarinSocial.iOS.Renderers
{
    public class FacebookLoginPageRenderer : PageRenderer
    {
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            if (App.SocialLoginType == App.SocialLogin.FACEBOOK)
            {
                var auth = new OAuth2Authenticator(
        clientId: FacebookConfig.ClientId, // your OAuth2 client id
        scope: FacebookConfig.Scope, // the scopes for the particular API you're accessing, delimited by "+" symbols
        authorizeUrl: new Uri(FacebookConfig.AuthorizeUrl), // the auth URL for the service
        redirectUrl: new Uri(FacebookConfig.RedirectUrl)); // the redirect URL for the service

                auth.Completed += async (sender, eventArgs) =>
                {
                    // We presented the UI, so it's up to us to dimiss it on iOS.

                    if (eventArgs.IsAuthenticated)
                    {
                        var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me"), null, eventArgs.Account);
                        var response = await request.GetResponseAsync();
                        var obj = JObject.Parse(response.GetResponseText());
                        // Use eventArgs.Account to do wonderful things
                        var id = obj["id"].ToString().Replace("\"", ""); // Id has extraneous quotation marks
                        App.SaveToken(eventArgs.Account.Properties["access_token"], obj["name"].ToString());
                        App.SuccessfulLoginAction.Invoke();

                        // Use eventArgs.Account to do wonderful things
                        // App.SaveToken(eventArgs.Account.Properties["access_token"], "");
                    }
                    else
                    {
                        // The user cancelled
                    }
                };

                PresentViewController(auth.GetUI(), true, null);
            }
            if (App.SocialLoginType == App.SocialLogin.LINKEDIN)
            {
                var auth2 = new OAuth2Authenticator(
                clientId: LinkedInConfig.ClientId,
                clientSecret: LinkedInConfig.ClientSecret,// 
                scope: LinkedInConfig.Scope, // the scopes for the particular API you're accessing, delimited by "+" symbols
                authorizeUrl: new Uri(LinkedInConfig.AuthorizeUrl), // the auth URL for the service
                  redirectUrl: new Uri(LinkedInConfig.RedirectUrl), // the redirect URL for the service
                accessTokenUrl: new Uri(LinkedInConfig.AccessTokenUrl));

                auth2.Completed += async (sender, eventArgs) =>
                {
                    // We presented the UI, so it's up to us to dimiss it on iOS.

                    if (eventArgs.IsAuthenticated)
                    {
                        var request = new OAuth2Request("GET", new Uri("https://api.linkedin.com/v2/me"), null, eventArgs.Account);
                        var response = await request.GetResponseAsync();
                        var obj = JObject.Parse(response.GetResponseText());
                        // Use eventArgs.Account to do wonderful things
                        // var id = obj["id"].ToString().Replace("\"", ""); // Id has extraneous quotation marks
                        App.SaveToken(eventArgs.Account.Properties["access_token"], "");
                        App.SuccessfulLoginAction.Invoke();
                        // Use eventArgs.Account to do wonderful things
                        // App.SaveToken(eventArgs.Account.Properties["access_token"], "");
                    }
                    else
                    {
                        // The user cancelled
                    }
                };

                PresentViewController(auth2.GetUI(), true, null);


            }
        }
    }
}

