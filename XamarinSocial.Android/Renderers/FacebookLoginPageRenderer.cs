using System;

using Xamarin.Forms;
using XamarinSocial.Views;
using XamarinSocial.Droid.Renderers;
using Xamarin.Forms.Platform.Android;
using Android.App;
using Xamarin.Auth;
using static XamarinSocial.Configurations.AuthConfig;
using Android.Content;
using Newtonsoft.Json.Linq;

[assembly: ExportRenderer(typeof(FacebookLoginPage), typeof(FacebookLoginPageRenderer))]

namespace XamarinSocial.Droid.Renderers
{

    public class FacebookLoginPageRenderer : PageRenderer
    {
        public FacebookLoginPageRenderer(Android.Content.Context context) : base(context)
        {
            AutoPackage = false;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            // this is a ViewGroup - so should be able to load an AXML file and FindView<>
            var activity = this.Context as Activity;
            if (App.SocialLoginType == App.SocialLogin.FACEBOOK)
            {
                var auth = new OAuth2Authenticator(
          clientId: FacebookConfig.ClientId, // your OAuth2 client id
          scope: FacebookConfig.Scope, // the scopes for the particular API you're accessing, delimited by "+" symbols
          authorizeUrl: new Uri(FacebookConfig.AuthorizeUrl), // the auth URL for the service
          redirectUrl: new Uri(FacebookConfig.RedirectUrl)); // the redirect URL for the service

                auth.Completed += async (sender, eventArgs) =>
                {
                    if (eventArgs.IsAuthenticated)
                    {

                        //Graph API to retrieved first name, last name, etc.
                        var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me"), null, eventArgs.Account);
                        var response = await request.GetResponseAsync();
                        var obj = JObject.Parse(response.GetResponseText());
                        // Use eventArgs.Account to do wonderful things
                        var id = obj["id"].ToString().Replace("\"", ""); // Id has extraneous quotation marks
                        App.SaveToken(eventArgs.Account.Properties["access_token"], obj["name"].ToString());
                        //App.SuccessfulLoginAction.Invoke();
                        App.Current.MainPage = new ProfilePage();

                    }
                    else
                    {
                        // The user cancelled
                    }
                };

                activity.StartActivity(auth.GetUI(activity) as Intent);
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

                auth2.IsLoadableRedirectUri = false;


                auth2.Completed += async (sender, eventArgs) =>
                {
                    if (eventArgs.IsAuthenticated)
                    {

                        //Graph API to retrieved first name, last name, etc.
                        var request = new OAuth2Request("GET", new Uri("https://api.linkedin.com/v2/me"), null, eventArgs.Account);
                        var response = await request.GetResponseAsync();
                        var obj = JObject.Parse(response.GetResponseText());
                        // Use eventArgs.Account to do wonderful things
                        var id = obj["id"].ToString().Replace("\"", ""); // Id has extraneous quotation marks
                        App.SaveToken(eventArgs.Account.Properties["access_token"], "");
                        App.SuccessfulLoginAction.Invoke();
                        App.Current.MainPage = new ProfilePage();


                    }
                    else
                    {
                        // The user cancelled
                    }
                };

                activity.StartActivity(auth2.GetUI(activity) as Intent);
            }
        }

    }
}

