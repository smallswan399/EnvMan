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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using EnvManager.Handlers;

namespace EnvManager
{
    public partial class FrmEditEnvVar : Form
    {
        #region Form Functions
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
            dgvHandler = new DgvHandler(ref dgvValuesList);
            dgvHandler.SetCurrentCell(0);
            editVarNameCommand = new EditVarNameCommand( txtVariableName );
            #endregion DgvHandler Commands

            // disable buttons
            SetBtnState();
            txtVariableName.CausesValidation = true;
            isVarNameChanged = false;
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

            if (!isBottomRow)
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
                string value = folderBrowserDialog.SelectedPath;

                if (isBottomRow)
                {
                    rowIndex = AddRow(value);
                    browseFolderCommand = new DgvBrowseFolderCommand(dgvHandler);
                }
                else
                {
                    rowIndex = dgvValuesList.CurrentCell.RowIndex;
                    browseFolderCommand
                        = new DgvBrowseFolderCommand( dgvHandler, dgvValuesList.Rows[ rowIndex ] );
                    SetRowValue(rowIndex, value);
                    SetRowIcon(rowIndex, value);
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
        const char SEPARATOR = ';';
        EnvVarManager variableManager = new EnvVarManager();
        EnvironmentVariableTarget variableType = EnvironmentVariableTarget.Machine;

        private void LoadEnvironmentVariableValues()
        {
            string environmentVariableValue = variableManager.GetEnvVariable(txtVariableName.Text, variableType);

            string[ ] values = environmentVariableValue.Split( SEPARATOR );

            foreach ( string value in values)
            {
                AddRow( value );
            }
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
                BtnClick(btnCancel, new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
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
        /// <summary>
        /// Returns Icon corresponding the type of the variable
        /// Added by Mariusz Ficek
        /// </summary>
        /// <param name="varValue">The variable value.</param>
        /// <returns>Icon Bitmap</returns>
        private Bitmap IconValueType(string varValue, ref string toolTipMsg)
        {
            Bitmap icon;

            switch (validator.ValueType(varValue))
                {
                case EnvironmentValueType.Number:
                    icon = Properties.Resources.ValTypeNumber;
                    toolTipMsg = "Number";
                    break;
                case EnvironmentValueType.String:
                    icon = Properties.Resources.ValTypeString;
                    toolTipMsg = "Word";
                    break;
                case EnvironmentValueType.Folder:
                    icon = Properties.Resources.ValTypeFolder;
                    toolTipMsg = "Folder";
                    break;
                case EnvironmentValueType.File:
                    icon = Properties.Resources.ValTypeFile;
                    toolTipMsg = "File";
                    break;
                default:  // Error 
                    icon = Properties.Resources.ValTypeError;
                    toolTipMsg = "No File or Folder found";
                    break;
                }
            
            return icon;
        }
        /// <summary>
        /// Sets the icon to the row.
        /// Added by Mariusz Ficek
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        private void SetRowIcon(int rowIndex, string varValue)
        {
            string toolTipMsg = "";
            dgvValuesList.Rows[rowIndex].Cells[0].Value 
                = IconValueType(varValue, ref toolTipMsg);
            dgvValuesList.Rows[rowIndex].Cells[0].ToolTipText = toolTipMsg;
        }
        /// <summary>
        /// Sets the string value to row.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="varValue">The variable value.</param>
        private void SetRowValue(int rowIndex, string varValue)
        {
            dgvValuesList.Rows[rowIndex].Cells[1].Value = varValue;
        }
        /// <summary>
        /// Adds a new row to grid.
        /// </summary>
        /// <param name="varValue">The variable value.</param>
        private int AddRow ( string varValue )
        {
            int rowIndex = dgvValuesList.Rows.Add();

            SetRowValue( rowIndex, varValue );
            SetRowIcon( rowIndex, varValue );

            return rowIndex;
        }
        private void dgvValuesList_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgvValuesList.Rows[dgvValuesList.Rows.Count - 1].Cells[0].Value = Properties.Resources.ValTypeNull;
        }
        private void dgvValuesList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            object value = dgvValuesList.Rows[e.RowIndex].Cells[1].Value;
            if (value != null
                && (editRowCommand.CurrentRow == null 
                || editRowCommand.CurrentRow.Cells[1].Value.ToString() != value.ToString()))
            {
                SetRowIcon(e.RowIndex, value.ToString());
                editRowCommand.NewRow = dgvValuesList.Rows[ e.RowIndex ];
                AddCommand(editRowCommand);
            }
            else
            {
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
            if ( MessageBox.Show( "Are you sure to delete value?", "Delete Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes )
            {
                ICommand command = null;
                if(e == null)
                {   // Deleted using delete button on form
                    command = new DgvDeleteCommand( dgvHandler );
                }
                else
                {   // Deleted using keyboard Delete key
                    command = new DgvDeleteCommand( dgvHandler, e.Row );
                }

                AddCommand( command );
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
