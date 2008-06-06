/*
   EnvMan - The Open-Source Windows Environment Variables Manager
   Copyright (C) 2006-2008 Vlad Setchin <envman-dev@googlegroups.com>

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace EnvMan.VersionManager.VersionInformation
{
    [Serializable]
    public class VersionInfo
    {
        /// <summary>
        /// Gets or sets the assembly version.
        /// </summary>
        /// <value>The assembly version.</value>
        [XmlIgnore]
        public Version AssemblyVersion
        {
            get { return new Version(major, minor, build); }
            set 
            {
                major = value.Major;
                minor = value.Minor;
                build = value.Build;
                revision = value.Revision;
            }
        }

        private string downloadWebPageAddress = string.Empty;
        /// <summary>
        /// Gets or sets the download web page address.
        /// </summary>
        /// <value>The download web page address.</value>
        public string DownloadWebPageAddress
        {
            get { return downloadWebPageAddress; }
            set { downloadWebPageAddress = value; }
        }

        private int major = -1;
        /// <summary>
        /// Gets or sets the major version number.
        /// </summary>
        /// <value>The major version number.</value>
        public int Major
        {
            get { return major; }
            set { major = value; }
        }

        private int minor = -1;
        /// <summary>
        /// Gets or sets the minor version number.
        /// </summary>
        /// <value>The minor.</value>
        public int Minor
        {
            get { return minor; }
            set { minor = value; }
        }

        private int build = -1;
        /// <summary>
        /// Gets or sets the build version number.
        /// </summary>
        /// <value>The build version number.</value>
        public int Build
        {
            get { return build; }
            set { build = value; }
        }

        private int revision = -1;
        /// <summary>
        /// Gets or sets the revision version number.
        /// </summary>
        /// <value>The revision version number.</value>
        public int Revision
        {
            get { return revision; }
            set { revision = value; }
        }
    }
}
