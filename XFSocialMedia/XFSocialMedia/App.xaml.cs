using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFSocialMedia.Configurations;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XFSocialMedia
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new LoginPage();
        }
        public static SocialLogin SocialLoginType = SocialLogin.NONE;

        public static bool IsLoggedIn
        {
            get { return !string.IsNullOrWhiteSpace(_Token); }
        }

        static string _Token;
        public static string Token
        {
            get { return _Token; }
        }

        public static void SaveToken(string token)
        {
            _Token = token;
        }

        public static Action SuccessfulLoginAction
        {
            get
            {
                return new Action(() =>
                {
                    Application.Current.MainPage.DisplayAlert("Successfull", "Login completed with  facebook", "Ok");
                });
            }
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        public enum SocialLogin
        {
            FACEBOOK,
            TWITTER,
            GOOGLE,
            INSTAGRAM,
            NONE
        };
    }
}
