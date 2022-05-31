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
                  
                }    
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}