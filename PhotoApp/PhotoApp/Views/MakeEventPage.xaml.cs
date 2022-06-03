﻿using System;
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
        public MakeEventPage()
        {
            InitializeComponent();
        }

        private void btnEventMaken_Clicked(object sender, EventArgs e)
        {
            string eventName = "kobes_event2";
            string remotePath = $"ftp://nasha.no-ip.org:5005/PhotoApp/{eventName}";
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