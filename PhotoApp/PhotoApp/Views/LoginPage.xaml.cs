using MySqlConnector;
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        async void btnLogin_Clicked(object sender, EventArgs e)
        {
            if (entryEmail.Text != null && entryPassword.Text != null)
            {
                DBconnector db = new DBconnector();
                User user = db.getUserbyUsername(entryEmail.Text, entryPassword.Text);
                if (user != null)
                {
                    App.Current.MainPage = new EventPage(user);
                }
                else
                {
                    await DisplayAlert("Alert", "User details incorrect", "OK");
                }
            }
            else
            {
                await DisplayAlert("Alert", "Please provide username and password", "OK");
            }
            
        }
    }
}