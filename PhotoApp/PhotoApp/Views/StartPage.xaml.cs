﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        private User user = new User((ulong)0, "dummy", false);
        private Event item = null;
        public StartPage()
        {
            InitializeComponent();
        }
        async void BtnConnectToEvent_Clicked(object sender, EventArgs e)
        {
            string eventID = entryCode1.Text + entryCode2.Text + entryCode3.Text + entryCode4.Text + entryCode5.Text + entryCode6.Text;
            DBconnector db = new DBconnector();
            item = db.getEventbyEventCode(ulong.Parse(eventID));

            if (eventID == null)
            {
                await DisplayAlert("Alert", "Please provide an eventcode", "OK");
                return;
            }            
            if (db.isValidEvent(ulong.Parse(eventID)))
            {
                App.Current.MainPage = new EventGallery(this.user, this.item);
            }
            else
            {
                await DisplayAlert("Alert", "incorrect event details", "OK");
            }
        }
        void btnLogIn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new LoginPage();
        }
        void BtnRegister_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new RegistrationPage();
        }

    }
}