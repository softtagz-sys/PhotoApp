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
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }
        void BtnConnectToEvent_Clicked(object sender, EventArgs e)
        {

        }
        void btnLogIn_OnClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new LoginPage();
        }
        void BtnRegister_OnClicked(object sender, EventArgs e)
        {
        }

        private void dtpBeginDatum_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

        private void dtpEindDatum_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

        private void tpBeginTijd_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }

        private void tpEindTijd_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }
    }
}