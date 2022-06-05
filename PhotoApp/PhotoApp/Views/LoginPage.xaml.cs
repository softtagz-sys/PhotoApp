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
        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            DBconnector db = new DBconnector();

            if (db.isValidUser(entryEmail.Text, entryPassword.Text))
            {

            }
            else
            {

            }
            
        }
    }
}