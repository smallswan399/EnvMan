/*
   AUM - Automated Updates Manager Tests
   Copyright (C) 2006-2008 Vlad Setchin <v_setchin@yahoo.com.au>

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
using System.Windows.Forms;
using System.Drawing;

namespace AUM.UI.Tray
{
    class TrayIcon
    {
        public event EventHandler BalloonTipClicked;

        #region Variables
        NotifyIcon notifyIcon = null;

        Icon defaultIcon = null;
        ContextMenu menu = null;
        #endregion Variables

        #region Functions
        /// <summary>
        /// Initializes a new instance of the <see cref="TrayIcon"/> class.
        /// </summary>
        public TrayIcon()
        {
            InitTrayIcon();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="TrayIcon"/> class.
        /// </summary>
        /// <param name="icon">The icon.</param>
        public TrayIcon ( Icon icon )
        {
            defaultIcon = icon;
            InitTrayIcon();
        }
        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="TrayIcon"/> is reclaimed by garbage collection.
        /// </summary>
        ~TrayIcon()
        {
            notifyIcon.Dispose();
        }
        /// <summary>
        /// Initialise the tray icon.
        /// </summary>
        private void InitTrayIcon()
        {
            try
            {
                notifyIcon = new NotifyIcon();
                if ( defaultIcon == null )
                {
                    defaultIcon = Properties.Resources.DefaultICO;
                }                
                notifyIcon.Icon = defaultIcon;
                notifyIcon.Visible = true;
                notifyIcon.BalloonTipClicked += new EventHandler(notifyIcon_BalloonTipClicked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the BalloonTipClicked event of the notifyIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            if (BalloonTipClicked != null)
            {
                BalloonTipClicked(sender, e);
            }
        }
        #endregion Functions

        #region Properties
        /// <summary>
        /// Sets the baloon tool tip message.
        /// </summary>
        /// <value>The baloon tool tip message.</value>
        public string BaloonToolTip
        {
            set
            {
                notifyIcon.ShowBalloonTip(0, "Information", value, ToolTipIcon.Info);
            }
        }
        /// <summary>
        /// Sets the notify icon text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            set
            {
                notifyIcon.Text = value;
            }
        }
        /// <summary>
        /// Sets the menu.
        /// </summary>
        /// <value>The menu.</value>
        public ContextMenu Menu
        {
            set
            {
                menu = value;
                //notifyIcon.ContextMenuStrip = menu.Menu;
                //menu.ValueUpdated += new SSW.Watcher.ValueUpdatedHandler(WatcherValueUpdated);
            }
        }
        #endregion Properties
    }
}
