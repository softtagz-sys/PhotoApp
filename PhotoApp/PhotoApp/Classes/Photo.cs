using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoApp
{
    class Photo
    {
        public string fileName { get; set; }
        public string uriFTP { get; set; }
        public string uriHTTP { get; set; }
        public DateTime modified { get; set; }   //not in use
        public Photo(string fileName, string uriFTP, string uriHTTP)
        {
            this.fileName = fileName;
            this.uriFTP = uriFTP;
            this.uriHTTP = uriHTTP;
        }
    }
}
