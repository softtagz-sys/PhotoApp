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
        string strEmail, strPassword;
        bool blIsHost;
        
        public RegistrationPage()
        {
            InitializeComponent();
        }

        void btnRegister_CLicked(object sender, EventArgs e)
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
                }    
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}