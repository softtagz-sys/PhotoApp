using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using System.IO;

namespace PhotoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventGallery : ContentPage
    {
        private User user = null;
        private Event item = null;
        public EventGallery(Object user, Object item)
        {
            InitializeComponent();
            this.user = (User)user;
            this.item = (Event)item;

            //await DisplayAlert("user", this.user.getEmail , "OK");
            //await DisplayAlert("event", this.item.getName , "OK");

            lblTitle.Text = this.item.getName();
            lblEventCode.Text = Convert.ToString(this.item.GetEventCode());
            lblStartDate.Text = "StartDate: " + Convert.ToString(this.item.getStartDate());
            lblEndDate.Text = "EndDate " +  Convert.ToString(this.item.getEndDate());

            if (this.item.HasEventExpired())
            {
                lblEventStatus.Text = "This event has expired";
            }
            else if (this.item.HasEventBegun())
            {
                lblEventStatus.Text = "This event has not yet begun";
            }
            else if (this.item.IsEventUngoing())
            {
                lblEventStatus.Text = "This event is ongoing";
            }
        }

        async void BtnTakePhoto_Clicked(object sender, System.EventArgs e)
        {
            string fileName = Guid.NewGuid().ToString();
            string eventName = (item.GetEventCode()).ToString();
            string remotePath = $"ftp://nasha.no-ip.org:5005/PhotoApp/{eventName}";
            string ftpUsername = "EventShootOutAppKey";
            string ftpPass = "n9thiK9mlg4we94lp9Ti";
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = fileName
            });
            if (file == null)
                return;
            using (var client = new WebClient())
            {
                client.Credentials = new NetworkCredential(ftpUsername, ftpPass);
                client.UploadFile($"{remotePath}/{fileName}.jpg", WebRequestMethods.Ftp.UploadFile, file.Path);
                File.Delete(file.Path);
                file.Dispose();
            }
        }


    }
}