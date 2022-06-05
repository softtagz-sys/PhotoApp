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
            InitializeComponent();
            DBconnector db = new DBconnector();
            List<Event> events = db.listEventsForUser(new User((ulong)1, "jan@telenet.be", true));


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

        private void OnEventBtnClicked(object sender, EventArgs e)
        {
            var myBtn = sender as Button;
            

        }

        async void BtnMakeEvent_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MakeEventPage()));
        }
    }
}