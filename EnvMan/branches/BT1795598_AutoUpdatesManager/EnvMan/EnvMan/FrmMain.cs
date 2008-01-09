/*
   EnvMan - The Open-Source Windows Environment Variables Manager
   Copyright (C) 2006-2008 Vlad Setchin <envmng@gmail.com>

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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using EnvManager;

namespace EnvMan
{
    public partial class FrmMain : Form
    {
        FrmAbout frmAbout = null;
        #region Form Functions
        public FrmMain()
        {
            InitializeComponent();
            frmAbout = new FrmAbout();
            this.Text += " v" + frmAbout.AssemblyFileVersion;
            this.MinimumSize = new Size(472, 504);
            LoadSettings();
        }
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }
        private void TsmiClick(object sender, EventArgs e)
        {
            if (sender.Equals(tsmiExit))
            {
                Application.Exit();
            }
            else if (sender.Equals(tsmiAbout))
            {
                frmAbout.ShowDialog();
            }
            else if (sender.Equals(tsmiNewsWebsite))
            {
                System.Diagnostics.Process.Start(@"http://env-man.blogspot.com/");
            }
            else if (sender.Equals(tsmiDonate))
            {
                System.Diagnostics.Process.Start(@"http://sourceforge.net/donate/index.php?group_id=193626");
            }
            else if (sender.Equals(tsmiPostFeedbackOrBugReport))
            {
                System.Diagnostics.Process.Start(@"http://sourceforge.net/forum/?group_id=193626");
            }
            else if (sender.Equals(tsmiWebsite))
            {
                MessageBox.Show("Not Implemented!");
                //System.Diagnostics.Process.Start(@"http://sourceforge.net/forum/?group_id=193626");
            }
            else if (sender.Equals(tsmiCheckForUpdates))
            {
                MessageBox.Show("Not Implemented!");
            }
        }
        #endregion Form Functions

        #region Settings
        Properties.FrmMainSettings settings = Properties.FrmMainSettings.Default;

        private void LoadSettings()
        {
            if (settings.FrmWindowState == FormWindowState.Normal)
            {
                this.Location = settings.FrmWindowLocation;
                this.Width = settings.FrmSize.Width;
                this.Height = settings.FrmSize.Height;
            }
            else
            {
                this.WindowState = settings.FrmWindowState;
            }
        }
        private void SaveSettings()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                settings.FrmWindowLocation = this.Location;
                settings.FrmSize = this.Size;
            }
            else
            {
                settings.FrmWindowState = this.WindowState;
            }

            settings.Save();
        }
        #endregion Settings
    }
}