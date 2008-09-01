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
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWebsite = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEnvManForum = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiJoinForum = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAskAQuestion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiForumWebsite = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDonate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPostFeedbackOrBugReport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCheckForUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewVersionInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new System.Windows.Forms.StatusStrip();
            this.tslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.envManager = new EnvManager.EnvManager();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.msMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.helpToolStripMenuItem,
            this.tsmiNewVersionInfo});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(369, 24);
            this.msMain.TabIndex = 2;
            this.msMain.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiSettings,
            this.toolStripMenuItem3,
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(35, 20);
            this.tsmiFile.Text = "&File";
            // 
            // tsmiExit
            // 
            this.tsmiExit.Image = global::EnvMan.Properties.Resources.ShutDown;
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.tsmiExit.Size = new System.Drawing.Size(152, 22);
            this.tsmiExit.Text = "E&xit";
            this.tsmiExit.ToolTipText = "Close Application";
            this.tsmiExit.Click += new System.EventHandler(this.TsmiClick);
            // 
            // TsmiSettings
            // 
            this.TsmiSettings.Name = "TsmiSettings";
            this.TsmiSettings.Size = new System.Drawing.Size(152, 22);
            this.TsmiSettings.Text = "Settings...";
            this.TsmiSettings.Click += new System.EventHandler(this.TsmiClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiWebsite,
            this.tsmiEnvManForum,
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
            // tsmiWebsite
            // 
            this.tsmiWebsite.Image = global::EnvMan.Properties.Resources.Website;
            this.tsmiWebsite.Name = "tsmiWebsite";
            this.tsmiWebsite.Size = new System.Drawing.Size(235, 22);
            this.tsmiWebsite.Text = "EnvMan &Project Website...";
            this.tsmiWebsite.Click += new System.EventHandler(this.TsmiClick);
            // 
            // tsmiEnvManForum
            // 
            this.tsmiEnvManForum.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiJoinForum,
            this.tsmiAskAQuestion,
            this.tsmiForumWebsite});
            this.tsmiEnvManForum.Image = global::EnvMan.Properties.Resources.News;
            this.tsmiEnvManForum.Name = "tsmiEnvManForum";
            this.tsmiEnvManForum.Size = new System.Drawing.Size(235, 22);
            this.tsmiEnvManForum.Text = "EnvMan &Forum...";
            // 
            // tsmiJoinForum
            // 
            this.tsmiJoinForum.Image = global::EnvMan.Properties.Resources.Members;
            this.tsmiJoinForum.Name = "tsmiJoinForum";
            this.tsmiJoinForum.Size = new System.Drawing.Size(169, 22);
            this.tsmiJoinForum.Text = "&Join Forum...";
            this.tsmiJoinForum.Click += new System.EventHandler(this.TsmiClick);
            // 
            // tsmiAskAQuestion
            // 
            this.tsmiAskAQuestion.Image = global::EnvMan.Properties.Resources.Mail;
            this.tsmiAskAQuestion.Name = "tsmiAskAQuestion";
            this.tsmiAskAQuestion.Size = new System.Drawing.Size(169, 22);
            this.tsmiAskAQuestion.Text = "Ask a &Question...";
            this.tsmiAskAQuestion.Click += new System.EventHandler(this.TsmiClick);
            // 
            // tsmiForumWebsite
            // 
            this.tsmiForumWebsite.Image = global::EnvMan.Properties.Resources.Forum;
            this.tsmiForumWebsite.Name = "tsmiForumWebsite";
            this.tsmiForumWebsite.Size = new System.Drawing.Size(169, 22);
            this.tsmiForumWebsite.Text = "Forum Website...";
            this.tsmiForumWebsite.Click += new System.EventHandler(this.TsmiClick);
            // 
            // tsmiDonate
            // 
            this.tsmiDonate.Image = global::EnvMan.Properties.Resources.SupportProject;
            this.tsmiDonate.Name = "tsmiDonate";
            this.tsmiDonate.Size = new System.Drawing.Size(235, 22);
            this.tsmiDonate.Text = "&Support this Project...";
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
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(232, 6);
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
            this.tsmiCheckForUpdates.Click += new System.EventHandler(this.TsmiClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(232, 6);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Image = global::EnvMan.Properties.Resources.EnvManAbout;
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(235, 22);
            this.tsmiAbout.Text = "&About";
            this.tsmiAbout.Click += new System.EventHandler(this.TsmiClick);
            // 
            // tsmiNewVersionInfo
            // 
            this.tsmiNewVersionInfo.Image = global::EnvMan.Properties.Resources.Updates;
            this.tsmiNewVersionInfo.Name = "tsmiNewVersionInfo";
            this.tsmiNewVersionInfo.Size = new System.Drawing.Size(96, 20);
            this.tsmiNewVersionInfo.Text = " Version Info";
            this.tsmiNewVersionInfo.Visible = false;
            this.tsmiNewVersionInfo.Click += new System.EventHandler(this.TsmiClick);
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblStatus});
            this.tsMain.Location = new System.Drawing.Point(0, 392);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(369, 22);
            this.tsMain.TabIndex = 3;
            this.tsMain.Text = "statusStrip1";
            // 
            // tslblStatus
            // 
            this.tslblStatus.Name = "tslblStatus";
            this.tslblStatus.Size = new System.Drawing.Size(0, 17);
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
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
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
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem tsmiEnvManForum;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmiLanguage;
        private System.Windows.Forms.ToolStripMenuItem tsmiCheckForUpdates;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiPostFeedbackOrBugReport;
        private System.Windows.Forms.ToolStripMenuItem tsmiDonate;
        private System.Windows.Forms.ToolStripMenuItem tsmiWebsite;
        private System.Windows.Forms.ToolStripMenuItem tsmiJoinForum;
        private System.Windows.Forms.ToolStripMenuItem tsmiAskAQuestion;
        private System.Windows.Forms.ToolStripMenuItem tsmiForumWebsite;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewVersionInfo;
        private System.Windows.Forms.ToolStripStatusLabel tslblStatus;
        private System.Windows.Forms.ToolStripMenuItem TsmiSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    }
}

