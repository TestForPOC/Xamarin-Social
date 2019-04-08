using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.ComponentModel;

namespace XamarinSocial.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            try
            {
                InitializeComponent();
                // lbl_welcome.Text = "Welcome " + App.Firstname;
            }
            catch (Exception e)
            {

            }


        }
    }
}
