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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using EnvManager;
using EnvMan.VersionManager;
using EnvMan.VersionManager.VersionInformation;

namespace EnvMan
{
    public partial class FrmMain : Form
    {
        private BackgroundWorker worker = null;
        private VersionChecker versionChecker = null;
        private VersionInfo versionInfo = null;
        private bool showFrmVersionInfo = false;
        private FrmAbout frmAbout = null;
        private VersionInfo currentVersionInfo = new VersionInfo();

        #region Form Functions
        public FrmMain()
        {
            InitializeComponent();

            frmAbout = new FrmAbout();
            this.Text += " " + frmAbout.PackageVersion;
            this.MinimumSize = new Size(472, 504);

            versionChecker = new VersionChecker( Properties.Resources.EnvManICO );
            versionChecker.VersionChecked += new VersionChecker.NewVersionCheckedHandler( versionChecker_NewVersionChecked );

            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            
            LoadSettings();
        }

        /// <summary>
        /// Handles the DoWork event of the worker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            showFrmVersionInfo = sender == null;
            
            currentVersionInfo.AssemblyVersion = frmAbout.AssemblyVersion;
            try
            {
                versionChecker.CheckVersion(currentVersionInfo);
            }
            catch (Exception ex)
            {
                tslblStatus.Text = ex.Message;
            }

            if ( e != null )
            {
                e.Cancel = true; 
            }
        }

        /// <summary>
        /// Version Checker Handler for version checks.
        /// </summary>
        /// <param name="newVersion">if set to <c>true</c> [new version].</param>
        /// <param name="versionInfo">The version info.</param>
        void versionChecker_NewVersionChecked(bool newVersion, VersionInfo versionInfo)
        {
            string msg = string.Empty;

            if ( newVersion )
            {
                msg = "New version " + versionInfo.AssemblyVersion + " released";
                tsmiNewVersionInfo.Text = msg;
                tsmiNewVersionInfo.Visible = true;
                this.versionInfo = versionInfo;

                if ( showFrmVersionInfo )
                {
                    FrmVersionInfo versionInfoForm = new FrmVersionInfo();
                    versionInfoForm.Icon = Properties.Resources.EnvManICO;
                    versionInfoForm.Message = msg;
                    if ( versionInfoForm.ShowDialog() == DialogResult.OK )
                    {
                        TsmiClick( tsmiNewVersionInfo, null );
                    }
                }
            }
            else
            {
                msg = "You have the current version.";
                if ( showFrmVersionInfo )
                {
                    MessageBox.Show( msg, "EnvMan", MessageBoxButtons.OK, MessageBoxIcon.Information );
                }
            }
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
            else if (sender.Equals(tsmiForumWebsite))
            {
                System.Diagnostics.Process.Start( @"http://groups.google.com/group/envman" );
            }
            else if (sender.Equals(tsmiDonate))
            {
                System.Diagnostics.Process.Start( @"http://env-man.blogspot.com/2007/12/donate.html" );
            }
            else if (sender.Equals(tsmiPostFeedbackOrBugReport))
            {
                System.Diagnostics.Process.Start( @"http://sourceforge.net/tracker/?group_id=193626" );
            }
            else if (sender.Equals(tsmiWebsite))
            {
                System.Diagnostics.Process.Start( @"http://env-man.blogspot.com/2007/04/envman-user-guide.html" );
            }
            else if (sender.Equals(tsmiJoinForum))
	        {
                System.Diagnostics.Process.Start( "mailto:envman-subscribe@googlegroups.com" );
	        }
            else if ( sender.Equals( tsmiAskAQuestion ) )
            {
                System.Diagnostics.Process.Start( "mailto:envman-dev@googlegroups.com" );
            }
            else if (sender.Equals(tsmiCheckForUpdates))
            {
                Application.DoEvents();
                worker_DoWork( null, null );
            }
            else if ( sender.Equals( tsmiNewVersionInfo ) )
            {
                System.Diagnostics.Process.Start( versionInfo.DownloadWebPageAddress );
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

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
            Application.DoEvents();
        }
    }
}