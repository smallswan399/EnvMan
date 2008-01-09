/*
   AUM - Automated Updates Manager
   Copyright (C) 2006-2008 Vlad Setchin <auto.updates.mng@gmail.com>

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

namespace AUM.VersionInformation
{
    [Serializable]
    public class VersionInfo
    {
        private string assemblyVersion = string.Empty;
        /// <summary>
        /// Gets or sets the assembly version.
        /// </summary>
        /// <value>The assembly version.</value>
        public string AssemblyVersion
        {
            get { return assemblyVersion; }
            set { assemblyVersion = value; }
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
    }
}
