using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MakeEventPage : ContentPage
    {
        private User user = null;
        public MakeEventPage(Object user)
        {
            InitializeComponent();

            this.user = (User)user;
        }

        private async void btnMakeEvent_Clicked(object sender, EventArgs e)
        {
            Random rndCode = new Random();
            ulong strCode = (ulong)rndCode.Next(0, 1000000);
            string eventName = entryEventName.Text;
            DateTime startDate = dtpStarDate.Date;
            DateTime endDate = dtpEndDate.Date;

            //TODO missing time component

            this.createDBEvent(strCode, startDate, endDate, eventName);
            this.createFTPEvent(strCode.ToString("D3"));

            await DisplayAlert("Alert", "You're event has been created", "OK");
            App.Current.MainPage = new EventPage(user);
        }

        private void createDBEvent(ulong strCode, DateTime startDate, DateTime endDate, string eventName)
        {
            DBconnector db = new DBconnector();
            db.createEvent(new Event(0, user.getId(), strCode, startDate, endDate, eventName));
        }
        private void createFTPEvent(string strCode)
        {
            string remotePath = $"ftp://nasha.no-ip.org:5005/PhotoApp/{strCode}";

            string ftpUsername = "EventShootOutAppKey";
            string ftpPass = "n9thiK9mlg4we94lp9Ti";
            try
            {
                //create the directory
                FtpWebRequest requestDir = (FtpWebRequest)FtpWebRequest.Create(new Uri(remotePath));
                requestDir.Method = WebRequestMethods.Ftp.MakeDirectory;
                requestDir.Credentials = new NetworkCredential(ftpUsername, ftpPass);
                requestDir.UsePassive = true;
                requestDir.UseBinary = true;
                requestDir.KeepAlive = false;
                FtpWebResponse response = (FtpWebResponse)requestDir.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    response.Close();
                }
                else
                {
                    response.Close();
                }
            }
        }
    }
}