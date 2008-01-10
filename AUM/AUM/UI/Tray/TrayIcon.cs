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
using System.ComponentModel;

namespace AUM.UI.Tray
{
    class TrayIcon
    {
        public event EventHandler BalloonTipClicked;

        #region Variables
        private NotifyIcon notifyIcon = null;

        private Icon defaultIcon = null;
        private ContextMenu menu = null;
        private string message = string.Empty;
        private System.ComponentModel.IContainer components;
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
                this.components = new Container();
                this.notifyIcon = new NotifyIcon(this.components);
                if ( defaultIcon == null )
                {
                    defaultIcon = Properties.Resources.DefaultICO;
                }                
                notifyIcon.Icon = defaultIcon;
                notifyIcon.Visible = true;
                // ????
                notifyIcon.BalloonTipClicked += new System.EventHandler(notifyIcon_BalloonTipClicked);
                notifyIcon.Click += new EventHandler(notifyIcon_Click);
                notifyIcon.BalloonTipClosed += new EventHandler(notifyIcon_BalloonTipClosed);
                notifyIcon.MouseClick += new MouseEventHandler(notifyIcon_MouseClick);
                notifyIcon.MouseMove += new MouseEventHandler(notifyIcon_MouseMove);
                // ????
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void notifyIcon_BalloonTipClosed(object sender, EventArgs e)
        {
            Console.WriteLine("Baloon closed");
        }

        void notifyIcon_Click(object sender, EventArgs e)
        {
            if (BalloonTipClicked != null)
            {
                BalloonTipClicked(sender, e);
            }
        }

        void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            ShowBaloonTip();
        }

        void notifyIcon_MouseMove(object sender, MouseEventArgs e)
        {
            ShowBaloonTip();
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
        private void ShowBaloonTip()
        {
            notifyIcon.ShowBalloonTip(0, "Information", this.message, ToolTipIcon.Info);
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
                this.message = value;
                ShowBaloonTip();
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
