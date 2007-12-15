/*
  EnvMan - The Open-Source Windows Environment Variables Manager
  Copyright (C) 2006-2007 Vlad Setchin <v_setchin@yahoo.com.au>

  This program is free software; you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation; either version 2 of the License, or
  (at your option) any later version.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program; if not, write to the Free Software
  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
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
        #region Form Functions
        public FrmMain()
        {
            InitializeComponent();
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
                FrmAbout frmAbout = new FrmAbout();
                frmAbout.ShowDialog();
                frmAbout.Dispose();
            }
        }
        #endregion Form Functions

        #region Settings
        Properties.Settings settings = Properties.Settings.Default;

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
                Properties.Settings.Default.FrmWindowState = this.WindowState;
            }

            settings.Save();
        }
        #endregion Settings
    }
}