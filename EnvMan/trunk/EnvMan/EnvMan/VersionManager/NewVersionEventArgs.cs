using System;
using System.Collections.Generic;
using System.Text;
using EnvMan.VersionManager.VersionInformation;

namespace EnvMan.VersionManager
{
    /// <summary>
    /// 
    /// </summary>
    public class NewVersionEventArgs : EventArgs
    {
        private bool newVersion = false;
        /// <summary>
        /// Gets or sets a value indicating whether [new version].
        /// </summary>
        /// <value><c>true</c> if [new version]; otherwise, <c>false</c>.</value>
        public bool NewVersion
        {
            set
            {
                newVersion = value;
            }
            get
            {
                return newVersion;
            }
        }

        private VersionInfo versionInfo;
        /// <summary>
        /// Gets or sets the version information.
        /// </summary>
        /// <value>The version information.</value>
        public VersionInfo VersionInformation
        {
            get
            {
                return versionInfo;
            }
            set
            {
                versionInfo = value;
            }
        }
    }
}
