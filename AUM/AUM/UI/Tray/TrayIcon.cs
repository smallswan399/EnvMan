/*
   AUM - Automated Updates Manager Tests
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
using System.Windows.Forms;
using System.Drawing;

namespace AUM.UI.Tray
{
    class TrayIcon
    {
        #region Variables
        NotifyIcon notifyIcon = null;

        Icon defaultIcon = null;
        ContextMenu menu = null;
        #endregion Variables

        #region Functions
        public TrayIcon()
        {
            InitTrayIcon();
        }
        public TrayIcon ( Icon icon )
        {
            defaultIcon = icon;
            InitTrayIcon();
        }
        ~TrayIcon()
        {
            notifyIcon.Dispose();
        }
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion Functions

        #region Properties
        public string BaloonToolTip
        {
            set
            {
                notifyIcon.ShowBalloonTip(0, "Information", value, ToolTipIcon.Info);
            }
        }
        public string Text
        {
            set
            {
                notifyIcon.Text = value;
            }
        }
        public ContextMenu Menu
        {
            set
            {
                menu = value;
                //notifyIcon.ContextMenuStrip = menu.Menu;
                //menu.ValueUpdated += new SSW.Watcher.ValueUpdatedHandler(WatcherValueUpdated);
            }
        }

        void WatcherValueUpdated(string value)
        {
            this.BaloonToolTip = value;
        }
        #endregion Properties
    }
}
