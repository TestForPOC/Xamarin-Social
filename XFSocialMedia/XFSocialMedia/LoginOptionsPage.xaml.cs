using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XFSocialMedia
{
    public partial class LoginOptionsPage : ContentPage
    {
        public LoginOptionsPage()
        {
            InitializeComponent();
        }

        void FacebookClicked(object sender, System.EventArgs e)
        {
            App.SocialLoginType = App.SocialLogin.FACEBOOK;
        }
    }
}
