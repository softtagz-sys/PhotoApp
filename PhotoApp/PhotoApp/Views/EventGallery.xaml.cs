﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

        }
    }
}