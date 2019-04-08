using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using Prism;
using XamarinSocial.Views;

namespace XamarinSocial
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }
        public static SocialLogin SocialLoginType = SocialLogin.NONE;

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }
        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<FacebookLoginPage>();
            Container.RegisterTypeForNavigation<ProfilePage>();



        }
        public static Action SuccessfulLoginAction
        {
            get
            {
                return new Action(() =>
                {


                    // App.Current.MainPage.Navigation.PushAsync(new ProfilePage());
                    //App.Current.MainPage.Navigation.PopAsync();
                    //Application.Current.MainPage.DisplayAlert("Successfull", "Login completed with  facebook", "Ok");
                });
            }
        }
        static string _Token;
        public static string Token
        {
            get { return _Token; }
        }
        static string _firstname;
        public static string Firstname
        {
            get { return Firstname; }
        }
        static string _lastname;
        public static string Lastname
        {
            get { return Lastname; }
        }

        public static void SaveToken(string token, string firstname)
        {
            _Token = token;
            _firstname = firstname;
        }
        public enum SocialLogin
        {
            FACEBOOK,
            TWITTER,
            GOOGLE,
            LINKEDIN,
            NONE
        };
    }

}
