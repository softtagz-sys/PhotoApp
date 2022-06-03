using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PhotoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        async void GoToCamera_OnClicked(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CameraPage()));
        }
        async void GoToEvent_OnClicked(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new EventPage()));
        }

    }
}
