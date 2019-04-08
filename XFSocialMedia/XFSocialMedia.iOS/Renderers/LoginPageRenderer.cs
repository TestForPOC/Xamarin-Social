using System;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFSocialMedia;
using XFSocialMedia.iOS.Renderers;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace XFSocialMedia.iOS.Renderers
{
    public class LoginPageRenderer : PageRenderer
    {
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            var auth = new OAuth2Authenticator(
                clientId: "2082328572069158", // your OAuth2 client id
                scope: "email", // the      scopes for the particular API you're accessing, delimited by "+" symbols
                authorizeUrl: new Uri("https://www.facebook.com/dialog/oauth/"),
                isUsingNativeUI: false,    // the auth URL for the service
                redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html")); // the redirect URL for the service

            auth.Completed += (sender, eventArgs) =>
            {
                // We presented the UI, so it's up to us to dimiss it on iOS.
                App.SuccessfulLoginAction.Invoke();

                if (eventArgs.IsAuthenticated)
                {
                    // Use eventArgs.Account to do wonderful things
                    App.SaveToken(eventArgs.Account.Properties["access_token"]);
                }
                else
                {
                    // The user cancelled
                }
            };

            PresentViewController(auth.GetUI(), true, null);

        }
    }
}
