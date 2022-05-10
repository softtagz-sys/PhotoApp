using System;
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
        public EventPage()
        {
            InitializeComponent();
        }

        async void btnMakeEvent_Clicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NavigationPage(new MakeEventPage()));
        }
    }
}