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

            Plugin.Media.CrossMedia.Current.Initialize();

            MainPage = new MakeEventPage();
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
