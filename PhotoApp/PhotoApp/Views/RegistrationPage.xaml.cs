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
    public partial class RegistrationPage : ContentPage
    {        
        public RegistrationPage()
        {
            InitializeComponent();
        }

        async void btnRegister_CLicked(object sender, EventArgs e)
        {
            try
            {
                if (EntryEmail != null && EntryPassword != null)
                {
                    DBconnector db = new DBconnector();

                    User u = new User
                        (
                            0,
                            EntryEmail.Text,
                            false
                        );
                    u.setPassword(EntryPassword.Text);
                    int r = db.createUser(u);

                    await DisplayAlert("Alert", "You're account has been created", "OK");
                    App.Current.MainPage = new StartPage();
                }    
            }
            catch (Exception)
            {

                throw;
            }
        }
        void BtnBack_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new StartPage();
        }
    }
}