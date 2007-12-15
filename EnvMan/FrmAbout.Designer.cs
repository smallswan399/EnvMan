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

namespace EnvManager
{
    partial class FrmAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmAbout ) );
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.lblProjectHomePage = new System.Windows.Forms.LinkLabel();
            this.lblSourceForge = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 204 ) ) );
            this.lblProductName.Location = new System.Drawing.Point( 5, 0 );
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size( 122, 20 );
            this.lblProductName.TabIndex = 39;
            this.lblProductName.Text = "Product Name";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 204 ) ) );
            this.lblVersion.Location = new System.Drawing.Point( 5, 25 );
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size( 49, 13 );
            this.lblVersion.TabIndex = 40;
            this.lblVersion.Text = "Version";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 204 ) ) );
            this.lblCopyright.Location = new System.Drawing.Point( 5, 60 );
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size( 60, 13 );
            this.lblCopyright.TabIndex = 41;
            this.lblCopyright.Text = "Copyright";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 204 ) ) );
            this.txtDescription.Location = new System.Drawing.Point( 5, 96 );
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size( 396, 37 );
            this.txtDescription.TabIndex = 42;
            this.txtDescription.TabStop = false;
            this.txtDescription.Text = "This program is distributed under the terms of the GNU General Public License v2 " +
                "or later.";
            // 
            // okButton
            // 
            this.okButton.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point( 326, 174 );
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size( 75, 23 );
            this.okButton.TabIndex = 43;
            this.okButton.Text = "&OK";
            // 
            // lblProjectHomePage
            // 
            this.lblProjectHomePage.AutoSize = true;
            this.lblProjectHomePage.Location = new System.Drawing.Point( 5, 136 );
            this.lblProjectHomePage.Name = "lblProjectHomePage";
            this.lblProjectHomePage.Size = new System.Drawing.Size( 117, 13 );
            this.lblProjectHomePage.TabIndex = 44;
            this.lblProjectHomePage.TabStop = true;
            this.lblProjectHomePage.Text = "Visit Project Homepage";
            this.lblProjectHomePage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.LblLinkClicked );
            // 
            // lblSourceForge
            // 
            this.lblSourceForge.AutoSize = true;
            this.lblSourceForge.Location = new System.Drawing.Point( 5, 161 );
            this.lblSourceForge.Name = "lblSourceForge";
            this.lblSourceForge.Size = new System.Drawing.Size( 143, 13 );
            this.lblSourceForge.TabIndex = 45;
            this.lblSourceForge.TabStop = true;
            this.lblSourceForge.Text = "Project at SourceForge page";
            this.lblSourceForge.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.LblLinkClicked );
            // 
            // FrmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 413, 209 );
            this.Controls.Add( this.lblSourceForge );
            this.Controls.Add( this.lblProductName );
            this.Controls.Add( this.lblVersion );
            this.Controls.Add( this.lblCopyright );
            this.Controls.Add( this.txtDescription );
            this.Controls.Add( this.okButton );
            this.Controls.Add( this.lblProjectHomePage );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ( ( System.Drawing.Icon ) ( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbout";
            this.Padding = new System.Windows.Forms.Padding( 9 );
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About EnvMan";
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.LinkLabel lblProjectHomePage;
        private System.Windows.Forms.LinkLabel lblSourceForge;


    }
}
