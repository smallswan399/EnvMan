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
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

using AUM.Properties;
using AUM.VersionInformation;
using AUM.UI.Tray;
using AUM.UI;

namespace AUM
{
    public class VersionChecker
    {
        private TrayIcon trayIcon = null;
        private Icon programIcon = null;
        private VersionInfoManager versionInfoManager = null;
        private WebClient webClient = null;
        private AUMSettings settings = AUMSettings.Default;
        private VersionInfo versionInfo = null;

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
        public VersionChecker ( Icon programIcon )
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

        /// <summary>
        /// Checks the version.
        /// </summary>
        /// <param name="localVersionInfo">The local version info.</param>
        /// <param name="showInfo">if set to <c>true</c> [show info].</param>
        public void CheckVersion(VersionInfo localVersionInfo, bool showInfo)
        {
            string localFile = Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData ) 
                + settings.LocalPath + settings.VersionFile;
            Uri webFile = new Uri(settings.WebPath + settings.VersionFile);

            if (DownloadFile(webFile, localFile))
            {
                string message = string.Empty;
                versionInfoManager.Load(localFile);
                versionInfo = versionInfoManager.VersionInformation;
                
                if ( localVersionInfo.AssemblyVersion != versionInfo.AssemblyVersion )
                {
                    message = "New version " + versionInfo.AssemblyVersion + " was released.";

                    if ( showInfo )
                    {
                        // TODO: Display dialog box with "Download now", "Remind me later" buttons
                        //MessageBox.Show( message );
                        FrmMessageDialog messageDialog = new FrmMessageDialog();
                        messageDialog.Text = Resources.DialogTitle;
                        messageDialog.Message = message;
                        messageDialog.Icon = programIcon;
                        if (messageDialog.ShowDialog() == DialogResult.OK)
                        {
                            trayIcon_BalloonTipClicked(null, null);
                        }
                    }
                    else
                    {
                        if ( programIcon != null )
                        {
                            trayIcon = new TrayIcon( programIcon );
                        }
                        else
                        {
                            trayIcon = new TrayIcon();
                        }
                        trayIcon.BalloonTipClicked += new EventHandler(trayIcon_BalloonTipClicked);
                        trayIcon.BaloonToolTip = message;
                    }
                }
                else
                {
                    message = "You have the latest version.";

                    if ( showInfo )
                    {
                        MessageBox.Show(message, Resources.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }

        /// <summary>
        /// Handles the BalloonTipClicked event of the trayIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void trayIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            try
            {
                if (versionInfo.DownloadWebPageAddress != string.Empty)
                {
                    System.Diagnostics.Process.Start(versionInfo.DownloadWebPageAddress);
                }
            }
            catch (Exception/* ex*/)
            {
                // TODO: Check exception on opening a page in browser
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
    }
}
