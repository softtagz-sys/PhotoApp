﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[] { "Expander_Experimental" });
            Plugin.Media.CrossMedia.Current.Initialize();
            MainPage = new NavigationPage(new StartPage());
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
