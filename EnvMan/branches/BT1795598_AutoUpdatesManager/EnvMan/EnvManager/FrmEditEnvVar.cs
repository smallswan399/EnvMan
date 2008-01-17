/*
   EnvMan - The Open-Source Windows Environment Variables Manager
   Copyright (C) 2006-2008 Vlad Setchin <Anastasia.Corporation+EnvMan@gmail.com>

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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using EnvManager.Handlers;
using EnvManager.ImportExport;

namespace EnvManager
{
    public partial class FrmEditEnvVar : Form
    {
        #region Form Functions
        private const string DEFAULT_FILTER_EXTENSION = "*.env";
        private const string FILE_FILTER = "Env Files|*.env";
        EnvVarValueValidator validator = null;
        bool isVarNameChanged = false;
        string variableName = "";

        #region DgvHandler Commands
        DgvHandler dgvHandler = null;
        UndoRedoCommandList commandsList = null;

        DgvEditCommand editRowCommand = null;
        EditVarNameCommand editVarNameCommand = null;
        #endregion DgvHandler Commands

        public FrmEditEnvVar(string variableName, EnvironmentVariableTarget variableType)
        {
            InitializeComponent();
            this.MinimumSize = new Size( 327, 439 );
            dgvValuesList.TabIndex = 0;
            LoadSettings();
            txtVariableName.CausesValidation = false;
            dgvHandler = new DgvHandler( ref dgvValuesList );

            // set default icon
            dgvValuesList_UserAddedRow(null, null);

            this.txtVariableName.Text = variableName;
            // remember current name
            this.variableName = variableName;
            this.variableType = variableType;
            validator = new EnvVarValueValidator();

            if (txtVariableName.Text.Length != 0)
            {   // Check if we are editing variable
                LoadEnvironmentVariableValues();
            }

            // Set form title
            this.Text = (txtVariableName.Text.Length != 0
                ? "Edit" : "New") + " "
                + (this.variableType == EnvironmentVariableTarget.Machine
                ? "System" : "User") + " Variable";

            #region Create DgvHandler Commands
            commandsList = new UndoRedoCommandList();
            dgvHandler.SetCurrentCell(0);
            editVarNameCommand = new EditVarNameCommand( txtVariableName );
            #endregion DgvHandler Commands

            // disable buttons
            SetBtnState();
            txtVariableName.CausesValidation = true;
            isVarNameChanged = false;

            // Open/Save File dialogs
            openFileDialog.Filter = FILE_FILTER;
            openFileDialog.DefaultExt = DEFAULT_FILTER_EXTENSION;
            saveFileDialog.Filter = FILE_FILTER;
            saveFileDialog.DefaultExt = DEFAULT_FILTER_EXTENSION;
        }
        private void BtnClick(object sender, EventArgs e)
        {
            ICommand currentCommand = null;

            if (sender.Equals(btnCancel))
            {
                this.Close();
            }
            else if(sender.Equals(btnUndo))
            {
                commandsList.Undo();
            }
            else if (sender.Equals(btnRedo))
            {
                commandsList.Redo();
            }
            else if (sender.Equals(btnSave))
            {
                SaveEnvironmentVariable();
            }
            else if (sender.Equals(btnExport))
            {
                ExportEnvironmentVariable();
            }
            else if (sender.Equals(btnImport))
	        {
                ImportEnvironmentVariable();                        
	        }
            //PRANK!E code changes start here -->
            if ( sender.Equals( tsmiLocateInWindowsExplorer ) )
            {
                LocateInWindowsExplorer();
            }
            //PRANK!E code changes end here -->
            else
            {
                if ( sender.Equals( btnDelete ) )
                {
                    dgvValuesList_UserDeletingRow( null, null );
                }
                else if (sender.Equals(btnBrowse))
                {
                    BrowseFolder();
                }
                #region Move Row
                else if (sender.Equals(btnMoveUp))
                {
                    currentCommand = new DgvMoveUpCommand(dgvHandler);
                }
                else if (sender.Equals(btnMoveTop))
                {
                    currentCommand = new DgvMoveToTopCommand(dgvHandler);
                }
                else if (sender.Equals(btnMoveDown))
                {
                    currentCommand = new DgvMoveDownCommand(dgvHandler);
                }
                else if (sender.Equals(btnMoveBottom))
                {
                    currentCommand = new DgvMoveToBottomCommand(dgvHandler);
                }
                #endregion Move Row
            }

            if (!sender.Equals(btnCancel))
            {
                AddCommand(currentCommand);
            }
        }

        private void AddCommand(ICommand command)
        {
            if (command != null)
            {
                command.Execute();
                commandsList.Add(command);
            }
            SetBtnState();
        }

        private void BrowseFolder()
        {
            bool isBottomRow = (dgvValuesList.CurrentCell.RowIndex == dgvValuesList.Rows.Count - 1);

            if ( !isBottomRow 
                && dgvValuesList.CurrentCell.Value != null )
            {
                string cellValue = dgvValuesList.CurrentCell.Value.ToString();
                if (Directory.Exists(cellValue))
                {
                    folderBrowserDialog.SelectedPath = cellValue;
                }
            }

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                DgvBrowseFolderCommand browseFolderCommand = null;
                int rowIndex = 0;
                string selectedPath = folderBrowserDialog.SelectedPath;

                if (isBottomRow)
                {
                    rowIndex = dgvHandler.AddRow(selectedPath);
                    browseFolderCommand = new DgvBrowseFolderCommand(dgvHandler);
                }
                else
                {
                    rowIndex = dgvValuesList.CurrentCell.RowIndex;
                    object value = dgvValuesList.Rows[ rowIndex ].Cells[ 1 ].Value;
                    if ( value != null )
                    {
                        browseFolderCommand
                            = new DgvBrowseFolderCommand( dgvHandler, dgvValuesList.Rows[ rowIndex ] ); 
                    }
                    else
                    {
                        browseFolderCommand = new DgvBrowseFolderCommand( dgvHandler );
                    }
                    dgvHandler.SetRowValue(rowIndex, selectedPath);
                    dgvHandler.SetRowIcon( rowIndex, selectedPath );
                }
                browseFolderCommand.NewRow = dgvValuesList.Rows[ rowIndex ];
                AddCommand(browseFolderCommand);
            }
        }
        /// <summary>
        /// Sets the state of the Buttons. 
        /// if rowIndex = -1 - disable all buttons
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        private void SetBtnState()
        {
            int rowIndex = 0;
            if (dgvValuesList.CurrentRow != null)
            {
                rowIndex = dgvValuesList.CurrentRow.Index;
            }
            // Enabled if no a bottom row
            btnMoveDown.Enabled
                = btnMoveBottom.Enabled
                = (rowIndex < dgvValuesList.Rows.Count - 2);

            // Enabled if not a top row
            btnMoveTop.Enabled
                = btnMoveUp.Enabled
                = (rowIndex > 0 && rowIndex != dgvValuesList.Rows.Count - 1);

            // disable on new row
            btnDelete.Enabled = rowIndex != dgvValuesList.Rows.Count - 1;

            // Import / Export
            btnExport.Enabled = dgvValuesList.Rows.Count != 1 
                && txtVariableName.Text.Length != 0 ;

            // set Undo/Redo
            btnUndo.Enabled = commandsList.CanUndo;
            btnRedo.Enabled = commandsList.CanRedo;
            toolTip.SetToolTip(btnUndo, commandsList.UndoMsg);
            toolTip.SetToolTip(btnRedo, commandsList.RedoMsg); 
        }
        private void FrmEditEnvVar_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }
        private void FrmEditEnvVar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnUndo.Enabled || txtVariableName.Text != variableName )
            {
                DialogResult result = MessageBox.Show("Would you like to save your changes?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
                switch (result)
                {
                    case DialogResult.Cancel:   // Don't save or close a form
                        {
                            e.Cancel = true;
                        }
                        break;
                    case DialogResult.Yes:  // Save changes and close
                        {
                            SaveEnvironmentVariable();
                        }
                        break;
                    default:    // No - just close a form                        
                        break;
                }
            }
        }
        private void txtVariableName_Validated ( object sender, EventArgs e )
        {
            if ( isVarNameChanged )
            {
                editVarNameCommand.NewVarName = txtVariableName.Text;
                AddCommand(editVarNameCommand);
                // create command with new variable name
                editVarNameCommand = new EditVarNameCommand( txtVariableName );
                isVarNameChanged = false;
            }
        }
        private void txtVariableName_TextChanged(object sender, EventArgs e)
        {
            if (editVarNameCommand != null
                && txtVariableName.Text != editVarNameCommand.CurrentVarName)
            {
                isVarNameChanged = true;
            }
            else
            {
                isVarNameChanged = false;
            }
        }
        #endregion Form Functions

        #region Environment Variables
        EnvVarManager variableManager = new EnvVarManager();
        EnvironmentVariableTarget variableType = EnvironmentVariableTarget.Machine;

        private void ExportEnvironmentVariable()
        {
            try
            {
                saveFileDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    EnvironmentVariable envVar = new EnvironmentVariable();
                    envVar.VarName = txtVariableName.Text;
                    envVar.VarValues = EnvironmentVariableValue().ToString();
                    ImportExportManager importExportManager = new ImportExportManager();
                    importExportManager.EnvVariable = envVar;
                    importExportManager.Save(saveFileDialog.FileName);
                    MessageBox.Show( "'" + txtVariableName.Text
                        + "' successfully exported to " + saveFileDialog.FileName 
                        + " file.", "Export Success!", MessageBoxButtons.OK, MessageBoxIcon.Information );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message, "Error!" );
            }
        }
        private void ImportEnvironmentVariable()
        {
            try
            {
                openFileDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
                if ( openFileDialog.ShowDialog() == DialogResult.OK )
                {
                    VarImportCommand importCommand =  new VarImportCommand( txtVariableName, EnvironmentVariableValue().ToString(), openFileDialog.FileName, this.dgvHandler );
                    if(importCommand.IsAbleToImport)
                    {
                        AddCommand( importCommand );
                    }
                }
            }
            catch ( Exception ex)
            {
                MessageBox.Show( ex.Message, "Error!" );
            }
        }
        private void LoadEnvironmentVariableValues()
        {
            string environmentVariableValue = variableManager.GetEnvVariable(txtVariableName.Text, variableType);

            this.dgvHandler.AddRows( environmentVariableValue );
        }
        private void SaveEnvironmentVariable()
        {
            try
            {
                StringBuilder envVarValue = EnvironmentVariableValue();

                if (variableName.Length != 0
                    && variableName != txtVariableName.Text)
                {   // name of the variable has changed
                    // remove variable with old name
                    variableManager.DeleteEnvironmentVariable(variableName, variableType);
                }
                variableManager.SetEnvironmentVariable(txtVariableName.Text, envVarValue.ToString(), variableType);
                // Set initial program state
                commandsList.Clear();
                variableName = txtVariableName.Text;
                SetBtnState();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #region Open in Windows Explorer
        // TODO: Test Open in Windows Explorer for Multiple Rows Actions
        //PRANK!E code changes start here -->
        private void dgvValuesList_CellMouseDown ( object sender, DataGridViewCellMouseEventArgs e )
        {
            // If row not selected select it and unselect all others
            // TODO: Test it with multiple row actions
            if ( e.Button == MouseButtons.Right 
                && !dgvValuesList.Rows[ e.RowIndex ].Selected )
            {
                dgvValuesList.Rows[ e.RowIndex ].Selected = true;
            }
        }

        private void LocateInWindowsExplorer ( )
        {
            EnvVarValueValidator validator = new EnvVarValueValidator();
            string varValue = string.Empty;

            foreach ( DataGridViewRow row in dgvValuesList.SelectedRows )
            {
                if ( row.Index != dgvValuesList.Rows.Count - 1 )
                {
                    varValue = row.Cells[ 1 ].Value.ToString();
                    switch ( validator.ValueType( varValue ) )
                    {
                        case EnvironmentValueType.Folder:
                            {   // Open Folder in Windows Explorer
                                LocateInWindowsExplorer( varValue );
                            }
                            break;
                        case EnvironmentValueType.File:
                            {   // Select File in Windows Explorer
                                LocateInWindowsExplorer( "/select," + varValue );
                            }
                            break;
                        case EnvironmentValueType.Error:
                            {   // Select existing folder in the path
                                string parentDir = Path.GetDirectoryName( varValue );
                                while ( !Directory.Exists( parentDir ) )
                                {
                                    parentDir = Path.GetDirectoryName( parentDir );
                                }
                                // Open Folder in Explorer
                                LocateInWindowsExplorer( parentDir );
                            }
                            break;
                        default:
                            // TODO: Remove for multiple rows
                            MessageBox.Show( "Nothing to locate in Windows Explorer", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                            break;
                    }
                }
            }
        }

        private void LocateInWindowsExplorer ( string parameters )
        {
            // Open Folder in new Windows Explorer window
            System.Diagnostics.Process.Start( "Explorer", "/n," + parameters );
        }
        //PRANK!E code changes end here --> 
        #endregion Open in Windows Explorer

#if DEBUG   // Testing
        public StringBuilder EnvironmentVariableValue ( )
#else       // Release
        private StringBuilder EnvironmentVariableValue()
#endif
        {
            StringBuilder envVarValue = new StringBuilder();
                        
            foreach ( DataGridViewRow row in dgvValuesList.Rows )
            {
                if ( row.Index != dgvValuesList.Rows.Count - 1 )
                {
                    envVarValue.Append( row.Cells[ 1 ].Value.ToString()
                        + ( row.Index < dgvValuesList.Rows.Count - 2 ? ";" : "" ) );
                    System.Diagnostics.Debug.WriteLine( envVarValue.ToString() );
                }
            }
            
            return envVarValue;
        }
        #endregion Environment Variables

        #region Data Grid View
        private void dgvValuesList_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgvValuesList.Rows[dgvValuesList.Rows.Count - 1].Cells[0].Value = Properties.Resources.ValTypeNull;
        }
        private void dgvValuesList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.FormattedValue.ToString().Contains(";"))
            {
                dgvValuesList.Rows[e.RowIndex].ErrorText = "Value cannot contain ';'";
                //errorProvider.SetError(lblError, dgvValuesList.Rows[e.RowIndex].ErrorText);
                e.Cancel = true;
            }
        }
        private void dgvValuesList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvValuesList.Rows[e.RowIndex].ErrorText = string.Empty;
            object dgvValue = dgvValuesList.Rows[e.RowIndex].Cells[1].Value;
            object editRowCommandValue 
                = (editRowCommand.CurrentRow == null ? null : editRowCommand.CurrentRow.Cells[ 1 ].Value );
            if (dgvValue != null
                && ( editRowCommandValue == null 
                || editRowCommandValue.ToString() != dgvValue.ToString()))
            {
                dgvHandler.SetRowIcon(e.RowIndex, dgvValue.ToString());
                editRowCommand.NewRow = dgvValuesList.Rows[ e.RowIndex ];
                AddCommand(editRowCommand);
            }
            else
            {
                if ( editRowCommandValue != null )
                {   // New Value is null, restore the old value
                    dgvValuesList.Rows[ e.RowIndex ].Cells[ 1 ].Value = editRowCommandValue;
                }
                SetBtnState();
            }
        }
        private void dgvValuesList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvValuesList[e.ColumnIndex, e.RowIndex].Value != null)
            {
                editRowCommand = new DgvEditCommand(dgvHandler, dgvValuesList.Rows[e.RowIndex]);
            }
            else
            {
                editRowCommand = new DgvEditCommand(dgvHandler);
            }
        }
        private void dgvValuesList_SelectionChanged ( object sender, EventArgs e )
        {
            SetBtnState();
        }
        private void dgvValuesList_UserDeletingRow ( object sender, DataGridViewRowCancelEventArgs e )
        {
            DialogResult dialogResult = DialogResult.No;

            if (e == null || !e.Row.IsNewRow)
            {   // Don't show on deletion of new rows
                dialogResult = MessageBox.Show("Are you sure to delete value?", "Delete Confirmation",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (dialogResult == DialogResult.Yes)
            {
                ICommand command = null;
                if (e == null)
                {   // Deleted using delete button on form
                    command = new DgvDeleteCommand(dgvHandler);
                }
                else
                {   // Deleted using keyboard Delete key
                    command = new DgvDeleteCommand(dgvHandler, e.Row);
                }

                AddCommand(command); 
            }
        }
        #endregion Data Grid View

        #region Settings
        Properties.FrmEditEnvVarSettings settings = Properties.FrmEditEnvVarSettings.Default;

        private void LoadSettings()
        {
            if (settings.FrmEditWindowState == FormWindowState.Normal)
            {
                this.Location = settings.FrmEditWindowLocation;
                this.Width = settings.FrmSize.Width;
                this.Height = settings.FrmSize.Height;
            }
            else
            {
                this.WindowState = settings.FrmEditWindowState;
            }

        }
        private void SaveSettings()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                settings.FrmEditWindowLocation = this.Location;
                settings.FrmSize = this.Size;
            }
            else
            {
                settings.FrmEditWindowState = this.WindowState;
            }

            settings.Save();
        }
        #endregion Settings
#if DEBUG
        #region Testing
        /// <summary>
        /// Gets the DataGridView reference. Use only in DEBUG.
        /// </summary>
        /// <value>The DataGridView reference.</value>
        public DataGridView DgView
        {
            get { return dgvValuesList; }
        }
        /// <summary>
        /// Reloads grid with specified variable. Use only in DEBUG.
        /// </summary>
        /// <param name="varName">Name of the variable.</param>
        /// <param name="varType">Type of the variable.</param>
        public void LoadEnvironmentVariableValues(string varName, EnvironmentVariableTarget varType)
        {
            txtVariableName.Text = varName;
            variableType = varType;
            dgvValuesList.Rows.Clear();
            commandsList.Clear();
            LoadEnvironmentVariableValues();
        }
        #endregion Testing
#endif
    }
}
