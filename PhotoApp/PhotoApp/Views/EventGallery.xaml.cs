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
        private FTPConnector ftp = new FTPConnector();

        public EventGallery(Object user, Object item)
        {
            InitializeComponent();
            this.user = (User)user;
            this.item = (Event)item;

            lblTitle.Text = this.item.getName();

            //lblEventCode.Text = Convert.ToString(this.item.GetEventCode());
            lblStartDate.Text = "StartDate: " + Convert.ToString(this.item.getStartDate());
            lblEndDate.Text = "EndDate " +  Convert.ToString(this.item.getEndDate());

            if (this.item.HasEventExpired())
            {
                //lblEventStatus.Text = "This event has expired";
            }
            else if (this.item.HasEventBegun())
            {
                //lblEventStatus.Text = "This event has not yet begun";
            }
            else if (this.item.IsEventUngoing())
            {
                //lblEventStatus.Text = "This event is ungoing";
            }

            this.loadEventPictures();
        }

        async void BtnTakePhoto_Clicked(object sender, System.EventArgs e)
        {
            string fileName = Guid.NewGuid().ToString();
            string eventCode = (item.GetEventCode()).ToString();
            
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                return;
            }
            MediaFile file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = fileName
            });

            ftp.uploadFile(file, eventCode, fileName);
        }

        private void loadEventPictures()
        {
            imageListView.Children.Clear();
            foreach (Photo photo in ftp.getPhotosForEvent(item.GetEventCode()))
            {
                // add pic to gallery
                Image img = new Image{ Aspect = Aspect.AspectFit };
                imageListView.Children.Add(img);

                img.Source = new UriImageSource
                {
                    Uri = new Uri(photo.uriHTTP),
                    CachingEnabled = true,
                    CacheValidity = new TimeSpan(0, 30, 0)
                };
            }

        }
    }
}