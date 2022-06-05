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
        User user = null;
        public EventPage(object user)
        {
            InitializeComponent();
            this.user = (User)user;
            DBconnector db = new DBconnector();
            List<Event> events = db.listEventsForUser(this.user);


            EventButtons.Children.Clear();
            foreach (Event item in events)
            {
                var btn = new Button()
                {
                    Text = item.getName()
                    };
                btn.Clicked += OnEventBtnClicked;
                EventButtons.Children.Add(btn);
            }
        }

        private async void OnEventBtnClicked(object sender, EventArgs e)
        {
            var myBtn = sender as Button;

            await Navigation.PushAsync(new NavigationPage(new EventGallery()));
        }

        async void BtnMakeEvent_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new MakeEventPage(this.user)));
            App.Current.MainPage = new MakeEventPage(user);
        }
    }
}