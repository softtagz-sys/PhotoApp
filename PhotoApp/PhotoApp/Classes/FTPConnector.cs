using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Xamarin.Forms;

namespace PhotoApp
{
    internal class FTPConnector
    {
        private string remoteFTPPath = $"ftp://nasha.no-ip.org:5005/PhotoApp";
        private string remoteHTTPPath = $"http://nasha.no-ip.org:5006/PhotoApp";
        private string ftpUsername = "EventShootOutAppKey";
        private string ftpPass = "n9thiK9mlg4we94lp9Ti";

        public FTPConnector()
        {

        }

        public void uploadFile(MediaFile file, string eventCode, string fileName)
        {
            if (file == null)
                return;
            using (var client = new WebClient())
            {
                client.Credentials = new NetworkCredential(ftpUsername, ftpPass);
                client.UploadFile($"{remoteFTPPath}/{eventCode}/{fileName}.jpg", WebRequestMethods.Ftp.UploadFile, file.Path);
                File.Delete(file.Path);
                file.Dispose();
            }
        }

        public List<Photo> getPhotosForEvent(ulong eventCode)
        {
            List<Photo> photos = new List<Photo>();

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{remoteFTPPath}/{eventCode}");
                request.Method = WebRequestMethods.Ftp.ListDirectory;

                request.Credentials = new NetworkCredential(ftpUsername, ftpPass);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string names = reader.ReadToEnd();

                reader.Close();
                response.Close();

                foreach (string fileName in names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                    photos.Add(new Photo(fileName, $"{remoteFTPPath}/{eventCode}/{fileName}", $"{remoteHTTPPath}/{eventCode}/{fileName}"));
            }
            catch (Exception)
            {
                throw;
            }

            return photos;
        }
    }
}
