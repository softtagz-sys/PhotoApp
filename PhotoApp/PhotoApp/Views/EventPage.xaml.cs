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
        public EventPage(Object user)
        {
            DBconnector db = new DBconnector();
            List<Event> events = db.listEventsForUser((User)user);

            for (int i = 0; i < events.Count; i++)
            {

            }


            Button button = new Button
            {
                Text = "Communie",
                Margin=10,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                WidthRequest=100,
                HeightRequest=200
            };
            button.Clicked += BtnOverview_Clicked;

            ImageButton ImgBtnMakeEvent = new ImageButton
            {
                Source = "PlusButton.png",
                Margin=10,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.End,
                WidthRequest = 50,
                HeightRequest = 100
            };
            ImgBtnMakeEvent.Clicked += ImgBtnMakeEvent_Clicked1;

            Content = new Grid
            {
                Children =
                {
                    ImgBtnMakeEvent
                }
            };
        }

        async void ImgBtnMakeEvent_Clicked1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MakeEventPage()));
        }

        private void BtnOverview_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}