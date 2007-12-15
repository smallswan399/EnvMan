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

namespace EnvManager
{
    public partial class FrmEditEnvVar : Form
    {
        #region Form Functions
        const int DISABLE_ALL_VALUE = -1;
        string variableName = "";

        public FrmEditEnvVar(string variableName, EnvironmentVariableTarget variableType)
        {
            InitializeComponent();
            this.MinimumSize = new Size( 327, 439 );
            LoadSettings();

            // set default icon
            dgvValuesList_UserAddedRow(null, null);

            this.txtVariableName.Text = variableName;
            // remember current name
            this.variableName = variableName;
            this.variableType = variableType;

            if (txtVariableName.Text.Length != 0)
            {   // Check if we are editing variable
                LoadEnvironmentVariableValues();
            }

            // Set form title
            this.Text = (txtVariableName.Text.Length != 0
                ? "Edit" : "New") + " "
                + (this.variableType == EnvironmentVariableTarget.Machine
                ? "System" : "User") + " Variable";

            // disable buttons
            SetBtnState(DISABLE_ALL_VALUE);
        }
        private void BtnClick(object sender, EventArgs e)
        {
            if (sender.Equals(btnCancel))
            {
                this.Close();
            }
            else if (sender.Equals(btnBrowse))
            {
                BrowseFolder();
            }
            else if (sender.Equals(btnSave))
            {
                SaveEnvironmentVariable();
            }
            else if (sender.Equals(btnDelete))
            {
                if (MessageBox.Show("Are you sure to delete value?", "Delete Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // TODO: Provide an undo functionality based on design pattern
                    DeleteRow(dgvValuesList.CurrentRow.Index);
                }
            }
            else
            {
                #region Move Row
                int currentRowIndex = dgvValuesList.CurrentRow.Index;
                int destinationRowIndex = 0;

                if (sender.Equals(btnMoveUp))
                {
                    destinationRowIndex = currentRowIndex - 1;
                }
                else if (sender.Equals(btnMoveTop))
                {
                    destinationRowIndex = 0;
                }
                else if (sender.Equals(btnMoveDown))
                {
                    destinationRowIndex = currentRowIndex + 1;
                }
                else if (sender.Equals(btnMoveBottom))
                {
                    destinationRowIndex = dgvValuesList.Rows.Count - 2;
                }

                MoveRow(currentRowIndex, destinationRowIndex);
                #endregion Move Row
            }

            if (!sender.Equals(btnCancel)
                && dgvValuesList.CurrentRow != null)
            {
                SetBtnState(dgvValuesList.CurrentRow.Index);
            }
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
                string value = folderBrowserDialog.SelectedPath;
                if (isBottomRow)
                {
                    AddRow(value);
                }
                else
                {
                    SetRowValue(dgvValuesList.CurrentCell.RowIndex, value);
                    SetRowIcon(dgvValuesList.CurrentCell.RowIndex, value);
                }
            }
        }
        /// <summary>
        /// Sets the state of the Buttons. 
        /// if rowIndex = -1 - disable all buttons
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        private void SetBtnState(int rowIndex)
        {
            bool disableAll = rowIndex != DISABLE_ALL_VALUE;

            // Enabled if no a bottom row
            btnMoveDown.Enabled
                = btnMoveBottom.Enabled
                = (rowIndex < dgvValuesList.Rows.Count - 2 && disableAll);

            // Enabled if no a top row
            btnMoveTop.Enabled
                = btnMoveUp.Enabled
                = (rowIndex > 0 && disableAll
                    && rowIndex != dgvValuesList.Rows.Count - 1);

            // disable on new row
            btnDelete.Enabled = rowIndex != dgvValuesList.Rows.Count - 1
                && disableAll;
            btnBrowse.Enabled = disableAll;
        }
        private void FrmEditEnvVar_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }
        #endregion Form Functions

        #region Environment Variables
        const char SEPARATOR = ';';
        EnvVarManager variableManager = new EnvVarManager();
        EnvironmentVariableTarget variableType = EnvironmentVariableTarget.Machine;

        private void LoadEnvironmentVariableValues()
        {
            int startPosition = 0;
            int endPosition = 0;
            string variable = "";
            
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
                StringBuilder envVarValue = new StringBuilder();

                foreach (DataGridViewRow row in dgvValuesList.Rows)
                {
                    if (row.Index != dgvValuesList.Rows.Count - 1)
                    {
                        envVarValue.Append(row.Cells[1].Value.ToString()
                            + (row.Index < dgvValuesList.Rows.Count - 2 ? ";" : ""));
                        System.Diagnostics.Debug.WriteLine(envVarValue.ToString());
                    }
                }

                if(variableName.Length != 0 
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
        #endregion Environment Variables

        #region Data Grid View
        private void MoveRow(int currentRowIndex, int destinationRowIndex)
        {
            DataGridViewRow rowToMove = dgvValuesList.Rows[currentRowIndex];

            DeleteRow( currentRowIndex );
            dgvValuesList.Rows.Insert(destinationRowIndex, rowToMove);

            dgvValuesList.CurrentCell = dgvValuesList[0, destinationRowIndex];
        }
        /// <summary>
        /// Deletes the row in the grid.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        private void DeleteRow(int rowIndex)
        {
            dgvValuesList.Rows.RemoveAt( rowIndex );
        }
        private void dgvValuesList_CellMouseClick ( object sender, DataGridViewCellMouseEventArgs e )
        {
            SetBtnState( e.RowIndex );
        }
        /// <summary>
        /// Returns Icon corresponding the type of the variable
        /// Added by Mariusz Ficek
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>Icon Bitmap</returns>
        private Bitmap IconValueType(string variable)
        {
            // TODO: Implement proper validation for number, folder and file
            try
            {
                // TODO: find a better way to detect a number
                // fails on floating numbers like 1.23
                if (System.Convert.ToInt32(variable).ToString() == variable)
                {
                    return Properties.Resources.ValTypeNumber; // int
                }
            }
            catch { }

            try
            {
                if ((variable.Length >= 3) && (variable[1] == ':') && (variable[2] == '\\'))
                {
                    if (System.IO.File.Exists(variable))
                    {
                        return Properties.Resources.ValTypeFile; // file
                    }
                    else if (System.IO.Directory.Exists(variable))
                    {
                        return Properties.Resources.ValTypeFolder; // dir
                    }
                }
            }
            catch { }

            return Properties.Resources.ValTypeString; // dafault type is string
        }
        /// <summary>
        /// Sets the icon to the row.
        /// Added by Mariusz Ficek
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        private void SetRowIcon(int rowIndex, string variable)
        {
            //if ((rowIndex != -1) && (dgvValuesList.Rows[rowIndex].Cells["Value"].Value != null))
            //{
            //string variable = dgvValuesList.Rows[rowIndex].Cells["Value"].Value.ToString();
            dgvValuesList.Rows[rowIndex].Cells[0].Value = IconValueType(variable);
            //}
        }
        private void SetRowValue(int rowIndex, string variable)
        {
            dgvValuesList.Rows[rowIndex].Cells[1].Value = variable;
        }
        private void AddRow(string variable)
        {
            int rowIndex = dgvValuesList.Rows.Add();

            SetRowValue(rowIndex, variable);
            SetRowIcon(rowIndex, variable);
        }
        private void dgvValuesList_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgvValuesList.Rows[dgvValuesList.Rows.Count - 1].Cells[0].Value = Properties.Resources.ValTypeNull;
        }
        private void dgvValuesList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            object value = dgvValuesList.Rows[e.RowIndex].Cells[1].Value;
            if (value != null)
            {
                SetRowIcon(e.RowIndex, value.ToString());
            }
        }
        #endregion Data Grid View

        #region Settings
        Properties.Settings settings = Properties.Settings.Default;

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
                Properties.Settings.Default.FrmEditWindowState = this.WindowState;
            }

            Properties.Settings.Default.Save();
        }
        #endregion Settings
    }
}