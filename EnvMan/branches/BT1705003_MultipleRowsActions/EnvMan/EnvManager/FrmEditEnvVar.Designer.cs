/*
   EnvMan - The Open-Source Windows Environment Variables Manager
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmEditEnvVar ) );
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVariableName = new System.Windows.Forms.TextBox();
            this.dgvValuesList = new System.Windows.Forms.DataGridView();
            this.ValueType = new System.Windows.Forms.DataGridViewImageColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsValuesDGV = new System.Windows.Forms.ContextMenuStrip( this.components );
            this.tsmiLocateInWindowsExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnMoveTop = new System.Windows.Forms.Button();
            this.btnMoveBottom = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip( this.components );
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ( ( System.ComponentModel.ISupportInitialize ) ( this.dgvValuesList ) ).BeginInit();
            this.cmsValuesDGV.SuspendLayout();
            this.statusStrip.SuspendLayout();
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
            this.txtVariableName.Validated += new System.EventHandler( this.txtVariableName_Validated );
            this.txtVariableName.TextChanged += new System.EventHandler( this.txtVariableName_TextChanged );
            // 
            // dgvValuesList
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb( ( ( int ) ( ( ( byte ) ( 216 ) ) ) ), ( ( int ) ( ( ( byte ) ( 253 ) ) ) ), ( ( int ) ( ( ( byte ) ( 254 ) ) ) ) );
            this.dgvValuesList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvValuesList.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 0 ) ) );
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvValuesList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvValuesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValuesList.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[ ] {
            this.ValueType,
            this.Value} );
            this.dgvValuesList.ContextMenuStrip = this.cmsValuesDGV;
            this.dgvValuesList.Location = new System.Drawing.Point( 12, 32 );
            this.dgvValuesList.Name = "dgvValuesList";
            this.dgvValuesList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvValuesList.Size = new System.Drawing.Size( 273, 312 );
            this.dgvValuesList.TabIndex = 0;
            this.dgvValuesList.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler( this.dgvValuesList_UserAddedRow );
            this.dgvValuesList.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler( this.dgvValuesList_UserDeletingRow );
            this.dgvValuesList.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler( this.dgvValuesList_CellBeginEdit );
            this.dgvValuesList.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler( this.dgvValuesList_CellMouseDown );
            this.dgvValuesList.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler( this.dgvValuesList_CellValidating );
            this.dgvValuesList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler( this.dgvValuesList_CellEndEdit );
            this.dgvValuesList.SelectionChanged += new System.EventHandler( this.dgvValuesList_SelectionChanged );
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
            this.Value.HeaderText = "Variable value";
            this.Value.Name = "Value";
            // 
            // cmsValuesDGV
            // 
            this.cmsValuesDGV.Items.AddRange( new System.Windows.Forms.ToolStripItem[ ] {
            this.tsmiLocateInWindowsExplorer} );
            this.cmsValuesDGV.Name = "cmsValuesDGV";
            this.cmsValuesDGV.Size = new System.Drawing.Size( 218, 26 );
            // 
            // tsmiLocateInWindowsExplorer
            // 
            this.tsmiLocateInWindowsExplorer.Image = global::EnvManager.Properties.Resources.FolderExplore;
            this.tsmiLocateInWindowsExplorer.Name = "tsmiLocateInWindowsExplorer";
            this.tsmiLocateInWindowsExplorer.Size = new System.Drawing.Size( 217, 22 );
            this.tsmiLocateInWindowsExplorer.Text = "Locate in Windows Explorer";
            this.tsmiLocateInWindowsExplorer.Click += new System.EventHandler( this.BtnClick );
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnBrowse.Image = global::EnvManager.Properties.Resources.ValTypeFolder;
            this.btnBrowse.Location = new System.Drawing.Point( 291, 225 );
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size( 24, 23 );
            this.btnBrowse.TabIndex = 11;
            this.toolTip.SetToolTip( this.btnBrowse, "Browse Folder" );
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler( this.BtnClick );
            // 
            // btnMoveTop
            // 
            this.btnMoveTop.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnMoveTop.Image = global::EnvManager.Properties.Resources.MoveTop;
            this.btnMoveTop.Location = new System.Drawing.Point( 291, 110 );
            this.btnMoveTop.Name = "btnMoveTop";
            this.btnMoveTop.Size = new System.Drawing.Size( 24, 23 );
            this.btnMoveTop.TabIndex = 9;
            this.toolTip.SetToolTip( this.btnMoveTop, "Move to the top" );
            this.btnMoveTop.UseVisualStyleBackColor = true;
            this.btnMoveTop.Click += new System.EventHandler( this.BtnClick );
            // 
            // btnMoveBottom
            // 
            this.btnMoveBottom.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnMoveBottom.Image = global::EnvManager.Properties.Resources.MoveBottom;
            this.btnMoveBottom.Location = new System.Drawing.Point( 291, 196 );
            this.btnMoveBottom.Name = "btnMoveBottom";
            this.btnMoveBottom.Size = new System.Drawing.Size( 24, 23 );
            this.btnMoveBottom.TabIndex = 8;
            this.toolTip.SetToolTip( this.btnMoveBottom, "Move to bottom" );
            this.btnMoveBottom.UseVisualStyleBackColor = true;
            this.btnMoveBottom.Click += new System.EventHandler( this.BtnClick );
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnMoveDown.Image = global::EnvManager.Properties.Resources.MoveDown;
            this.btnMoveDown.Location = new System.Drawing.Point( 291, 168 );
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size( 24, 23 );
            this.btnMoveDown.TabIndex = 7;
            this.btnMoveDown.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip( this.btnMoveDown, "Move down" );
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler( this.BtnClick );
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnMoveUp.Image = global::EnvManager.Properties.Resources.MoveUp;
            this.btnMoveUp.Location = new System.Drawing.Point( 291, 139 );
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size( 24, 23 );
            this.btnMoveUp.TabIndex = 6;
            this.toolTip.SetToolTip( this.btnMoveUp, "Move up" );
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler( this.BtnClick );
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnCancel.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 0 ) ) );
            this.btnCancel.Image = global::EnvManager.Properties.Resources.Cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point( 232, 353 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 83, 23 );
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.toolTip.SetToolTip( this.btnCancel, "Cancel Changes (Alt+F4)" );
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler( this.BtnClick );
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnSave.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 0 ) ) );
            this.btnSave.Image = global::EnvManager.Properties.Resources.Save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point( 146, 353 );
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size( 83, 23 );
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.toolTip.SetToolTip( this.btnSave, "Save Changes" );
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler( this.BtnClick );
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnDelete.Image = global::EnvManager.Properties.Resources.delete;
            this.btnDelete.Location = new System.Drawing.Point( 291, 254 );
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size( 24, 23 );
            this.btnDelete.TabIndex = 12;
            this.toolTip.SetToolTip( this.btnDelete, "Delete Value" );
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler( this.BtnClick );
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnImport.Image = global::EnvManager.Properties.Resources.Import;
            this.btnImport.Location = new System.Drawing.Point( 291, 39 );
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size( 24, 23 );
            this.btnImport.TabIndex = 14;
            this.toolTip.SetToolTip( this.btnImport, "Import" );
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler( this.BtnClick );
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnExport.Image = global::EnvManager.Properties.Resources.Export;
            this.btnExport.Location = new System.Drawing.Point( 291, 68 );
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size( 24, 23 );
            this.btnExport.TabIndex = 13;
            this.toolTip.SetToolTip( this.btnExport, "Export" );
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler( this.BtnClick );
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnUndo.Image = global::EnvManager.Properties.Resources.Undo;
            this.btnUndo.Location = new System.Drawing.Point( 291, 297 );
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size( 24, 23 );
            this.btnUndo.TabIndex = 16;
            this.toolTip.SetToolTip( this.btnUndo, "Undo" );
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler( this.BtnClick );
            // 
            // btnRedo
            // 
            this.btnRedo.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnRedo.Image = global::EnvManager.Properties.Resources.Redo;
            this.btnRedo.Location = new System.Drawing.Point( 291, 326 );
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size( 24, 23 );
            this.btnRedo.TabIndex = 15;
            this.toolTip.SetToolTip( this.btnRedo, "Redo" );
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler( this.BtnClick );
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.env";
            this.openFileDialog.Filter = "Env Files|*.env";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "*.env";
            this.saveFileDialog.Filter = "Env Files|*.env";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[ ] {
            this.tslblStatus} );
            this.statusStrip.Location = new System.Drawing.Point( 0, 383 );
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size( 325, 22 );
            this.statusStrip.TabIndex = 17;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tslblStatus
            // 
            this.tslblStatus.Image = global::EnvManager.Properties.Resources.ValTypeError;
            this.tslblStatus.Name = "tslblStatus";
            this.tslblStatus.Size = new System.Drawing.Size( 115, 17 );
            this.tslblStatus.Text = "Exception Message";
            // 
            // FrmEditEnvVar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 325, 405 );
            this.Controls.Add( this.statusStrip );
            this.Controls.Add( this.btnUndo );
            this.Controls.Add( this.btnRedo );
            this.Controls.Add( this.btnImport );
            this.Controls.Add( this.btnExport );
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEditEnvVar_FormClosing);
            ( ( System.ComponentModel.ISupportInitialize ) ( this.dgvValuesList ) ).EndInit();
            this.cmsValuesDGV.ResumeLayout( false );
            this.statusStrip.ResumeLayout( false );
            this.statusStrip.PerformLayout();
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
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ContextMenuStrip cmsValuesDGV;
        private System.Windows.Forms.ToolStripMenuItem tsmiLocateInWindowsExplorer;


        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tslblStatus;
        private System.Windows.Forms.DataGridViewImageColumn ValueType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
    }
}