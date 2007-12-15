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

namespace EnvMananager
{
    public partial class FrmEditEnvVar : Form
    {
        const string SEPARATOR = ";";
        const int DISABLE_ALL_VALUE = -1;

        EnvVarManager variableManager = new EnvVarManager();
        EnvironmentVariableTarget variableType = EnvironmentVariableTarget.Machine;

        public FrmEditEnvVar ( string variableName, EnvironmentVariableTarget variableType )
        {
            InitializeComponent();

            this.txtVariableName.Text = variableName;
            this.variableType = variableType;

            if (txtVariableName.Text.Length != 0)
            {   // Check if we are editing variable
                LoadEnvironmentVariableValues();
            }
            else
            {
                // TODO: Set column width
            }

            // Set form title
            this.Text = (txtVariableName.Text.Length != 0
                ? "Edit" : "New") + " "
                + (this.variableType == EnvironmentVariableTarget.Machine
                ? "System" : "User") + " Variable";

            // disable buttons
            SetBtnState( DISABLE_ALL_VALUE );
        }

        private void LoadEnvironmentVariableValues()
        {
            int startPosition = 0;
            int endPosition = 0;
            string variable = "";

            string environmentVariableValue = variableManager.GetEnvVariable(txtVariableName.Text, variableType);

            while (endPosition != -1)
            {
                variable = Parse( environmentVariableValue, ref startPosition, ref endPosition );
                string[ ] row = { variable };

                dgvValuesList.Rows.Add( row );
            }
        }

        private string Parse ( string input, ref int startPosition, ref int endPosition )
        {
            string value = "";

            endPosition = input.IndexOf( SEPARATOR, startPosition );
            if ( endPosition != -1 )
            {
                value = input.Substring( startPosition, endPosition - startPosition );
                startPosition = endPosition + 1;
            }
            else
            {   // load string after last separator
                value = input.Substring( startPosition, input.Length - startPosition );
            }

            return value;
        }

        private void BtnClick ( object sender, EventArgs e )
        {
            if(sender.Equals(btnCancel))
            {
                this.Close();
            }
            else if (sender.Equals(btnBrowse))
            {
                BrowseFolder();
            }
            else if(sender.Equals(btnSave))
            {
                SaveEnvironmentVariable();
            }
            else if ( sender.Equals( btnDelete ) )
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

                if ( sender.Equals( btnMoveUp ) )
                {
                    destinationRowIndex = currentRowIndex - 1;
                }
                else if ( sender.Equals( btnMoveTop ) )
                {
                    destinationRowIndex = 0;
                }
                else if ( sender.Equals( btnMoveDown ) )
                {
                    destinationRowIndex = currentRowIndex + 1;
                }
                else if ( sender.Equals( btnMoveBottom ) )
                {
                    destinationRowIndex = dgvValuesList.Rows.Count - 2;
                }

                MoveRow( currentRowIndex, destinationRowIndex ); 
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
                if (isBottomRow)
                {
                    string[] row = { folderBrowserDialog.SelectedPath };
                    dgvValuesList.Rows.Add(row);
                }
                else
                {
                    dgvValuesList.CurrentCell.Value = folderBrowserDialog.SelectedPath;
                }
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
                        envVarValue.Append(row.Cells[0].Value.ToString()
                            + (row.Index < dgvValuesList.Rows.Count - 2 ? ";" : ""));
                        System.Diagnostics.Debug.WriteLine(envVarValue.ToString());
                    }
                }

                variableManager.SetEnvironmentVariable(txtVariableName.Text, envVarValue.ToString(), variableType);
                BtnClick(btnCancel, new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

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
            Console.WriteLine( "" + e.RowIndex );
            SetBtnState( e.RowIndex );
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
                = ( rowIndex > 0 && disableAll
                    && rowIndex != dgvValuesList.Rows.Count - 1 );

            // disable on new row
            btnDelete.Enabled = rowIndex != dgvValuesList.Rows.Count - 1
                && disableAll;
            btnBrowse.Enabled = disableAll;
        }
    }
}