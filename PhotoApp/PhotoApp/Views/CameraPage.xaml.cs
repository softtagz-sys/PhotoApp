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
    public partial class CameraPage : ContentPage
    {
        private Event item = null;
        public CameraPage(object item)
        {
            InitializeComponent();
            this.item = (Event)item;
            lblEventTitel.Text = (this.item.getName()).ToString();
        }
        async void TakePhoto_Clicked(object sender, System.EventArgs e)
        {
            string fileName = Guid.NewGuid().ToString();
            string eventName = (item.getId()).ToString();
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
            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
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