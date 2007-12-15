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
    partial class FrmEditEnvVar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmEditEnvVar ) );
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVariableName = new System.Windows.Forms.TextBox();
            this.dgvValuesList = new System.Windows.Forms.DataGridView();
            this.ValueType = new System.Windows.Forms.DataGridViewImageColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnMoveTop = new System.Windows.Forms.Button();
            this.btnMoveBottom = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ( ( System.ComponentModel.ISupportInitialize ) ( this.dgvValuesList ) ).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 0 ) ) );
            this.label1.Location = new System.Drawing.Point( 12, 9 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 91, 13 );
            this.label1.TabIndex = 1;
            this.label1.Text = "Variable &name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 0 ) ) );
            this.label2.Location = new System.Drawing.Point( 12, 31 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 92, 13 );
            this.label2.TabIndex = 2;
            this.label2.Text = "Variable &value:";
            // 
            // txtVariableName
            // 
            this.txtVariableName.Location = new System.Drawing.Point( 103, 6 );
            this.txtVariableName.Name = "txtVariableName";
            this.txtVariableName.Size = new System.Drawing.Size( 177, 20 );
            this.txtVariableName.TabIndex = 3;
            // 
            // dgvValuesList
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb( ( ( int ) ( ( ( byte ) ( 216 ) ) ) ), ( ( int ) ( ( ( byte ) ( 253 ) ) ) ), ( ( int ) ( ( ( byte ) ( 254 ) ) ) ) );
            this.dgvValuesList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvValuesList.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.dgvValuesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValuesList.ColumnHeadersVisible = false;
            this.dgvValuesList.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[ ] {
            this.ValueType,
            this.Value} );
            this.dgvValuesList.Location = new System.Drawing.Point( 12, 47 );
            this.dgvValuesList.Name = "dgvValuesList";
            this.dgvValuesList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvValuesList.Size = new System.Drawing.Size( 271, 202 );
            this.dgvValuesList.TabIndex = 10;
            this.dgvValuesList.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler( this.dgvValuesList_UserAddedRow );
            this.dgvValuesList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler( this.dgvValuesList_CellEndEdit );
            this.dgvValuesList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler( this.dgvValuesList_CellMouseClick );
            // 
            // ValueType
            // 
            this.ValueType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ValueType.Frozen = true;
            this.ValueType.HeaderText = "";
            this.ValueType.Name = "ValueType";
            this.ValueType.ReadOnly = true;
            this.ValueType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ValueType.Width = 21;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnBrowse.Image = global::EnvManager.Properties.Resources.FolderExplore;
            this.btnBrowse.Location = new System.Drawing.Point( 289, 168 );
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size( 24, 23 );
            this.btnBrowse.TabIndex = 11;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler( this.BtnClick );
            // 
            // btnMoveTop
            // 
            this.btnMoveTop.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnMoveTop.Image = global::EnvManager.Properties.Resources.MoveTop;
            this.btnMoveTop.Location = new System.Drawing.Point( 289, 53 );
            this.btnMoveTop.Name = "btnMoveTop";
            this.btnMoveTop.Size = new System.Drawing.Size( 24, 23 );
            this.btnMoveTop.TabIndex = 9;
            this.btnMoveTop.UseVisualStyleBackColor = true;
            this.btnMoveTop.Click += new System.EventHandler( this.BtnClick );
            // 
            // btnMoveBottom
            // 
            this.btnMoveBottom.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnMoveBottom.Image = global::EnvManager.Properties.Resources.MoveBottom;
            this.btnMoveBottom.Location = new System.Drawing.Point( 289, 139 );
            this.btnMoveBottom.Name = "btnMoveBottom";
            this.btnMoveBottom.Size = new System.Drawing.Size( 24, 23 );
            this.btnMoveBottom.TabIndex = 8;
            this.btnMoveBottom.UseVisualStyleBackColor = true;
            this.btnMoveBottom.Click += new System.EventHandler( this.BtnClick );
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnMoveDown.Image = global::EnvManager.Properties.Resources.MoveDown;
            this.btnMoveDown.Location = new System.Drawing.Point( 289, 111 );
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size( 24, 23 );
            this.btnMoveDown.TabIndex = 7;
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler( this.BtnClick );
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnMoveUp.Image = global::EnvManager.Properties.Resources.MoveUp;
            this.btnMoveUp.Location = new System.Drawing.Point( 289, 82 );
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size( 24, 23 );
            this.btnMoveUp.TabIndex = 6;
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler( this.BtnClick );
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnCancel.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 0 ) ) );
            this.btnCancel.Image = global::EnvManager.Properties.Resources.Cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point( 230, 255 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 83, 23 );
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler( this.BtnClick );
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnSave.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 0 ) ) );
            this.btnSave.Image = global::EnvManager.Properties.Resources.Save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point( 144, 255 );
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size( 83, 23 );
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler( this.BtnClick );
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnDelete.Image = global::EnvManager.Properties.Resources.delete;
            this.btnDelete.Location = new System.Drawing.Point( 287, 197 );
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size( 24, 23 );
            this.btnDelete.TabIndex = 12;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler( this.BtnClick );
            // 
            // FrmEditEnvVar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 323, 285 );
            this.Controls.Add( this.btnDelete );
            this.Controls.Add( this.btnBrowse );
            this.Controls.Add( this.dgvValuesList );
            this.Controls.Add( this.btnMoveTop );
            this.Controls.Add( this.btnMoveBottom );
            this.Controls.Add( this.btnMoveDown );
            this.Controls.Add( this.btnMoveUp );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.btnSave );
            this.Controls.Add( this.txtVariableName );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Icon = ( ( System.Drawing.Icon ) ( resources.GetObject( "$this.Icon" ) ) );
            this.Location = new System.Drawing.Point( 10, 10 );
            this.Name = "FrmEditEnvVar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Edit System Variable";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler( this.FrmEditEnvVar_FormClosed );
            ( ( System.ComponentModel.ISupportInitialize ) ( this.dgvValuesList ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVariableName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveBottom;
        private System.Windows.Forms.Button btnMoveTop;
        private System.Windows.Forms.DataGridView dgvValuesList;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.DataGridViewImageColumn ValueType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
    }
}