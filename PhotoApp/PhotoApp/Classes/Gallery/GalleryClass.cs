using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoApp
{
    /// <summary>
    /// Gallery class.
    /// </summary>
    public class GalleryClass
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        /// <value>The identifier</value>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the project identifier
        /// </summary>
        /// <value>The project identifier</value>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the employee identifier
        /// </summary>
        /// <value>The employee identifier</value>
        public string Path
        {
            get;
            set;
        }

        public DateTime Created
        {
            get;
            set;
        }
    }
}
