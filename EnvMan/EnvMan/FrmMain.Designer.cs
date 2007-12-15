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

namespace EnvMan
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMain = new System.Windows.Forms.StatusStrip();
            this.envManager = new EnvManager.EnvManager();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWebsite = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewsWebsite = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDonate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPostFeedbackOrBugReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCheckForUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.helpToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(369, 24);
            this.msMain.TabIndex = 2;
            this.msMain.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(35, 20);
            this.tsmiFile.Text = "&File";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiWebsite,
            this.tsmiNewsWebsite,
            this.tsmiDonate,
            this.tsmiPostFeedbackOrBugReport,
            this.toolStripMenuItem2,
            this.tsmiLanguage,
            this.tsmiCheckForUpdates,
            this.toolStripMenuItem1,
            this.tsmiAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.TsmiClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(232, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(232, 6);
            this.toolStripMenuItem1.Visible = false;
            // 
            // tsMain
            // 
            this.tsMain.Location = new System.Drawing.Point(0, 392);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(369, 22);
            this.tsMain.TabIndex = 3;
            this.tsMain.Text = "statusStrip1";
            // 
            // envManager
            // 
            this.envManager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.envManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.envManager.Location = new System.Drawing.Point(2, 27);
            this.envManager.Name = "envManager";
            this.envManager.Size = new System.Drawing.Size(364, 362);
            this.envManager.TabIndex = 0;
            // 
            // tsmiExit
            // 
            this.tsmiExit.Image = global::EnvMan.Properties.Resources.ShutDown;
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(103, 22);
            this.tsmiExit.Text = "E&xit";
            this.tsmiExit.ToolTipText = "Close Application";
            this.tsmiExit.Click += new System.EventHandler(this.TsmiClick);
            // 
            // tsmiWebsite
            // 
            this.tsmiWebsite.Image = global::EnvMan.Properties.Resources.Website;
            this.tsmiWebsite.Name = "tsmiWebsite";
            this.tsmiWebsite.Size = new System.Drawing.Size(235, 22);
            this.tsmiWebsite.Text = "EnvMan &Project Website...";
            this.tsmiWebsite.Visible = false;
            this.tsmiWebsite.Click += new System.EventHandler(this.TsmiClick);
            // 
            // tsmiNewsWebsite
            // 
            this.tsmiNewsWebsite.Image = global::EnvMan.Properties.Resources.News;
            this.tsmiNewsWebsite.Name = "tsmiNewsWebsite";
            this.tsmiNewsWebsite.Size = new System.Drawing.Size(235, 22);
            this.tsmiNewsWebsite.Text = "EnvMan &News Website...";
            this.tsmiNewsWebsite.Click += new System.EventHandler(this.TsmiClick);
            // 
            // tsmiDonate
            // 
            this.tsmiDonate.Image = global::EnvMan.Properties.Resources.Donate;
            this.tsmiDonate.Name = "tsmiDonate";
            this.tsmiDonate.Size = new System.Drawing.Size(235, 22);
            this.tsmiDonate.Text = "&Donate...";
            this.tsmiDonate.Click += new System.EventHandler(this.TsmiClick);
            // 
            // tsmiPostFeedbackOrBugReport
            // 
            this.tsmiPostFeedbackOrBugReport.Image = global::EnvMan.Properties.Resources.SendFeedback;
            this.tsmiPostFeedbackOrBugReport.Name = "tsmiPostFeedbackOrBugReport";
            this.tsmiPostFeedbackOrBugReport.Size = new System.Drawing.Size(235, 22);
            this.tsmiPostFeedbackOrBugReport.Text = "Post feedback or bug report ...";
            this.tsmiPostFeedbackOrBugReport.Click += new System.EventHandler(this.TsmiClick);
            // 
            // tsmiLanguage
            // 
            this.tsmiLanguage.Image = global::EnvMan.Properties.Resources.Language;
            this.tsmiLanguage.Name = "tsmiLanguage";
            this.tsmiLanguage.Size = new System.Drawing.Size(235, 22);
            this.tsmiLanguage.Text = "&Language";
            this.tsmiLanguage.Visible = false;
            // 
            // tsmiCheckForUpdates
            // 
            this.tsmiCheckForUpdates.Image = global::EnvMan.Properties.Resources.Updates;
            this.tsmiCheckForUpdates.Name = "tsmiCheckForUpdates";
            this.tsmiCheckForUpdates.Size = new System.Drawing.Size(235, 22);
            this.tsmiCheckForUpdates.Text = "Check for &Updates...";
            this.tsmiCheckForUpdates.Visible = false;
            this.tsmiCheckForUpdates.Click += new System.EventHandler(this.TsmiClick);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Image = global::EnvMan.Properties.Resources.EnvManAbout;
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(235, 22);
            this.tsmiAbout.Text = "&About";
            this.tsmiAbout.Click += new System.EventHandler(this.TsmiClick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 414);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.envManager);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(10, 10);
            this.MainMenuStrip = this.msMain;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Environment Variables";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EnvManager.EnvManager envManager;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.StatusStrip tsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewsWebsite;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmiLanguage;
        private System.Windows.Forms.ToolStripMenuItem tsmiCheckForUpdates;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiPostFeedbackOrBugReport;
        private System.Windows.Forms.ToolStripMenuItem tsmiDonate;
        private System.Windows.Forms.ToolStripMenuItem tsmiWebsite;
    }
}

