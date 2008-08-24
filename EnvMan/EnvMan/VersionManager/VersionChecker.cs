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
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

using EnvMan.VersionManager;
using EnvMan.VersionManager.VersionInformation;
using EnvMan.Properties;

namespace EnvMan.VersionManager
{
    public class VersionChecker
    {
        private Icon programIcon = null;
        private VersionInfoManager versionInfoManager = null;
        private WebClient webClient = null;
        
        private VersionInfo versionInfo = null;

        public delegate void NewVersionCheckedHandler(bool newVersion, VersionInfo versionInfo);
        public event NewVersionCheckedHandler VersionChecked;

        #region Contractors
        /// <summary>
        /// Initializes a new instance of the <see cref="VersionChecker"/> class.
        /// </summary>
        public VersionChecker()
        {
            InitVersionChecker();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="VersionChecker"/> class.
        /// </summary>
        /// <param name="programIcon">The program icon.</param>
        public VersionChecker(Icon programIcon)
        {
            this.programIcon = programIcon;
            InitVersionChecker();
        }
        /// <summary>
        /// Initialises the version checker.
        /// </summary>
        private void InitVersionChecker()
        {
            webClient = new WebClient();
            versionInfoManager = new VersionInfoManager();
        }
        #endregion Contractors

        /// <summary>
        /// Downloads the file.
        /// </summary>
        /// <param name="fileWebAddress">The file web address.</param>
        /// <param name="localFilePath">The local file path.</param>
        /// <returns></returns>
        public bool DownloadFile (Uri fileWebAddress, string localFilePath)
        {
            bool result = false;
            try 
	        {
                webClient.DownloadFile(fileWebAddress, localFilePath);
                result = true;
	        }
	        catch (System.Net.WebException ex)
	        {
                throw new WebException("Could not get new version info. "
                    + "Please check your network and proxy settings.", ex);
	        }

            return result;
            //==================================================

            //WebRequest request = WebRequest.Create( uri );

            //if ( proxy != null )
            //{
            //    request.Proxy = proxy;
            //}

            //request.Timeout = 5000;
            //WebResponse response = request.GetResponse();
            //Stream stream = response.GetResponseStream();

            //try
            //{
            //    byte[ ] buffer = new byte[ 8192 ];
            //    int offset = 0;

            //    while ( offset < buffer.Length )
            //    {
            //        int bytesRead = stream.Read( buffer, offset, buffer.Length - offset );

            //        if ( bytesRead == 0 )
            //        {
            //            byte[ ] smallerBuffer = new byte[ offset + bytesRead ];

            //            for ( int i = 0; i < offset + bytesRead; ++i )
            //            {
            //                smallerBuffer[ i ] = buffer[ i ];
            //            }

            //            buffer = smallerBuffer;
            //        }

            //        offset += bytesRead;
            //    }

            //    return buffer;
            //}

            //finally
            //{
            //    if ( stream != null )
            //    {
            //        stream.Close();
            //        stream = null;
            //    }

            //    if ( response != null )
            //    {
            //        response.Close();
            //        response = null;
            //    }
            //}

            //============================================

            //byte[] bytes = null;
            //Exception exception = null;
            //WebProxy[] proxiesPre = Network.GetProxyList();
            //WebProxy[] proxies = RepeatArray(proxiesPre, 2); // see bug #1942

            //foreach (WebProxy proxy in proxies)
            //{
            //    try
            //    {
            //        bytes = DownloadSmallFile(uri, proxy);
            //        exception = null;
            //    }

            //    catch (Exception ex)
            //    {
            //        exception = ex;
            //        bytes = null;
            //    }

            //    if (bytes != null)
            //    {
            //        break;
            //    }
            //}

            //if (exception != null)
            //{
            //    WebException we = exception as WebException;

            //    if (we != null)
            //    {
            //        throw new WebException(null, we, we.Status, we.Response);
            //    }
            //    else
            //    {
            //        throw new ApplicationException("An exception occurred while trying to download '" + uri.ToString() + "'", exception);
            //    }
            //}

            //return bytes;
        }

        #region Check Version
        public void CheckVersion(VersionInfo localVersionInfo)
        {
            string webServer = "http://env-man.sourceforge.net/";
#if DEBUG
            string webFileName = "EnvMan.Debug";
#else
            string webFileName = "EnvMan.Release";
#endif
            string webFile = webServer + webFileName;
            
            this.CheckVersion(localVersionInfo, webFile);
        }
        /// <summary>
        /// Checks the version.
        /// </summary>
        /// <param name="localVersionInfo">The local version info.</param>
#if DEBUG
        public void CheckVersion(VersionInfo localVersionInfo, string remoteFile) 
#else
        private void CheckVersion(VersionInfo localVersionInfo, string remoteFile) 
#endif
        {
            Uri webFile = new Uri(remoteFile);
            string localFile = System.IO.Path.GetTempFileName();
            
            if (DownloadFile(webFile, localFile))
            {
                string message = string.Empty;
                versionInfoManager.Load(localFile);
                versionInfo = versionInfoManager.VersionInformation;
                bool newVersion = false;

                if (localVersionInfo.AssemblyVersion != versionInfo.AssemblyVersion)
                {
                    newVersion = true;
                }

                if ( VersionChecked != null )
                {
                    VersionChecked( newVersion, versionInfo );
                }
            }

            File.Delete( localFile );
        } 
        #endregion Check Version
    }
}
