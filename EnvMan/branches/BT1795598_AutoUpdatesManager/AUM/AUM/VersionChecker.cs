/*
   AUM - Automated Updates Manager
   Copyright (C) 2006-2007 Vlad Setchin <v_setchin@yahoo.com.au>

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

using AUM.Properties;
using AUM.VersionInformation;

namespace AUM
{
    public class VersionChecker
    {
        private VersionInfoManager versionInfoManager = null;
        private WebClient webClient = null;
        private AUMSettings settings = AUMSettings.Default;

        public VersionChecker()
        {
            webClient = new WebClient();
            versionInfoManager = new VersionInfoManager();
        }
        public bool DownloadFile (Uri fileWebAddress, string localFilePath)
        {
            bool result = false;
            try 
	        {
                webClient.DownloadFile(fileWebAddress, localFilePath);
                result = true;
	        }
	        catch (Exception ex)
	        {
                MessageBox.Show( ex.Message );
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

        public void CheckVersion(VersionInfo localVersionInfo)
        {
            string localFile = Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData ) 
                + settings.LocalPath + settings.VersionFile;
            Uri webFile = new Uri(settings.WebPath + settings.VersionFile);

            if (DownloadFile(webFile, localFile))
            {
                versionInfoManager.Load(localFile);
                VersionInfo currentVersionInfo = versionInfoManager.VersionInformation;

            }

        }
    }
}
