using System;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFSocialMedia;
using XFSocialMedia.Droid.Renderers;
using Android.Content;
using System.Runtime.Remoting.Contexts;
using Android.App;
using XFSocialMedia.Configurations;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace XFSocialMedia.Droid.Renderers
{
    public class LoginPageRenderer : PageRenderer
    {
        public LoginPageRenderer(Android.Content.Context context) : base(context)
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

                auth.Completed += (sender, eventArgs) =>
                {
                    if (eventArgs.IsAuthenticated)
                    {
                        App.SuccessfulLoginAction.Invoke();
                        // Use eventArgs.Account to do wonderful things
                        App.SaveToken(eventArgs.Account.Properties["access_token"]);
                    }
                    else
                    {
                        // The user cancelled
                    }
                };

                activity.StartActivity(auth.GetUI(activity) as Intent);
            }

        }
    }
}
