using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms.PlatformConfiguration.macOSSpecific;
using XamarinSocial.Views;

namespace XamarinSocial.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        INavigationService _navigationService;
        public DelegateCommand LoginWithFacebookCommand { get; private set; }
        public DelegateCommand LoginWithGmailCommand { get; private set; }
        public DelegateCommand LoginWithLinkedInCommand { get; private set; }



        public MainPageViewModel(INavigationService navigationService)
        {
            try
            {
                _navigationService = navigationService;
                LoginWithFacebookCommand = new DelegateCommand(FacebookLogin);
                LoginWithGmailCommand = new DelegateCommand(GmailLogin);
                LoginWithLinkedInCommand = new DelegateCommand(LinkedInLogin);


            }
            catch (Exception e)
            {

            }
        }
        private async void FacebookLogin()
        {
            App.SocialLoginType = App.SocialLogin.FACEBOOK;
            await _navigationService.NavigateAsync("FacebookLoginPage");

        }
        private void GmailLogin()
        {

        }
        private async void LinkedInLogin()
        {
            App.SocialLoginType = App.SocialLogin.LINKEDIN;
            await _navigationService.NavigateAsync("FacebookLoginPage");

        }
    }
}
