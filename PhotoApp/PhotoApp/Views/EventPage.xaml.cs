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
    public partial class EventPage : ContentPage
    {
        User user = null;
        public EventPage(Object user)
        {
            this.user = (User)user;
            InitializeComponent();
            DBconnector db = new DBconnector();
            List<Event> events = db.listEventsForUser(this.user);


            EventButtons.Children.Clear();
            foreach (Event item in events)
            {
                var btn = new Button()
                {
                    Text = item.getName()
                };
               
                btn.Clicked += async delegate { 
                    await Navigation.PushAsync(new NavigationPage(new EventGallery(this.user, item))); 
                };
                EventButtons.Children.Add(btn);
            }
        }

        async void BtnMakeEvent_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new MakeEventPage(this.user)));
            App.Current.MainPage = new MakeEventPage(user);
        }
    }
}