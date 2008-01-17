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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace EnvManager
{
    public partial class EnvManager : UserControl
    {
        public EnvManager ( )
        {
            InitializeComponent();

            gbUserVariables.Text += Environment.UserName;
            LoadEnvironmentVariables();

            this.HandleDestroyed += new EventHandler(EnvManager_HandleDestroyed);
        }

        void EnvManager_HandleDestroyed(object sender, EventArgs e)
        {
            SaveSettings();
        }

        #region Load Environment Variables
        EnvVarManager variableManger = new EnvVarManager();

        private void LoadEnvironmentVariables ( )
        {
            LoadEnvironmentVariables( dgvSystemVariables, EnvironmentVariableTarget.Machine );
            LoadEnvironmentVariables( dgvUserVariables, EnvironmentVariableTarget.User );
        }
        private void LoadEnvironmentVariables ( DataGridView dgv, EnvironmentVariableTarget target )
        {
            EnvVarValueValidator validator = new EnvVarValueValidator();
            int currentRowIndex = (dgv.CurrentRow != null ? dgv.CurrentRow.Index : 0);
            dgv.Rows.Clear();
            int rowIndex = 0;

            IDictionary environmentVariables = variableManger.GetEnvVariables( target );
            foreach ( DictionaryEntry de in environmentVariables )
            {
                string[ ] row = { de.Key.ToString(), de.Value.ToString() };

                rowIndex = dgv.Rows.Add( row );

                // validate variable value and show row in red if invalid
                if (!validator.Validate(de.Value.ToString()))
                {
                    dgv.Rows[rowIndex].Cells[0].Style.ForeColor = Color.Red;
                    dgv.Rows[rowIndex].Cells[1].Style.ForeColor = Color.Red;
                }
            }

            dgv.Sort( dgv.Columns[ 0 ], ListSortDirection.Ascending );
            try
            {   
                dgv.CurrentCell = dgv[ 0, currentRowIndex ];
                dgv.FirstDisplayedScrollingRowIndex = currentRowIndex;
            }
            catch
            {   // if row was deleted this will set it to first one
                // TODO: Implement this by searching for var name in the grid. 
                // Catching Exceptions makes program slow
                dgv.CurrentCell = dgv[ 0, 0 ];
                dgv.FirstDisplayedScrollingRowIndex = 0;
            }
        }
        #endregion Load Environment Variables

        #region Controls Events
        private void BtnClick ( object sender, EventArgs e )
        {
            if ( sender.Equals(btnEditUserVariable) )
            {
                EditEnvVar(dgvUserVariables, EnvironmentVariableTarget.User);
            }
            else if ( sender.Equals(btnEditSystemVariable) )
            {
                EditEnvVar(dgvSystemVariables, EnvironmentVariableTarget.Machine);
            }
            else if ( sender.Equals(btnNewUserVariable))
            {
                EditEnvVar("", EnvironmentVariableTarget.User);
            }
            else if (sender.Equals(btnNewSystemVariable))
            {
                EditEnvVar("", EnvironmentVariableTarget.Machine);
            }
            else if (sender.Equals(btnDeleteSystemVariable))
            {
                DeleteEnvVar( dgvSystemVariables, EnvironmentVariableTarget.Machine );
            }
            else if(sender.Equals(btnDeleteUserVariable))
            {
                DeleteEnvVar( dgvUserVariables, EnvironmentVariableTarget.User );
            }

            LoadEnvironmentVariables();
        }
        private string DgvVariableName(DataGridView dgv)
        {
            string varName = "";

            if ( dgv.CurrentRow.Index != -1 )
            {
                varName = dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value.ToString();
            }

            return varName;
        }
        private void DgvCellMouseDoubleClick ( object sender, DataGridViewCellMouseEventArgs e )
        {
            DataGridView dgv = ( DataGridView ) sender;
            if ( e.RowIndex > -1 )
            {
                EditEnvVar( dgv,
                    ( sender.Equals( dgvUserVariables )
                        ? EnvironmentVariableTarget.User
                        : EnvironmentVariableTarget.Machine ) );
                LoadEnvironmentVariables();
            }
        }
        private void splitContainer_MouseDoubleClick ( object sender, MouseEventArgs e )
        {
            splitContainer.SplitterDistance = splitContainer.Size.Height / 2;
        }
        #endregion Controls Events

        #region Edit Environment Variables
        FrmEditEnvVar frmEditVariable = null;

        private void DeleteEnvVar ( DataGridView dgv, EnvironmentVariableTarget variableType )
        {
            string varName = DgvVariableName( dgv );

            if ( !String.IsNullOrEmpty( varName ) )
            {
                if ( MessageBox.Show( "Are you sure to remove variable \"" + varName + "\"?",
                        "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes )
                {
                    try
                    {
                        variableManger.DeleteEnvironmentVariable(varName, variableType);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void EditEnvVar ( DataGridView dgv, EnvironmentVariableTarget variableType )
        {
            string varName = DgvVariableName( dgv );

            if ( !String.IsNullOrEmpty( varName ) )
            {
                EditEnvVar( varName, variableType );
            }
        }
        private void EditEnvVar ( string varName, EnvironmentVariableTarget varType )
        {
            frmEditVariable = new FrmEditEnvVar( varName, varType );
            frmEditVariable.ShowDialog();
            frmEditVariable.Dispose();
        }
        #endregion Edit Environment Variables

        #region Settings
        Properties.EnvManagerSettings settings = Properties.EnvManagerSettings.Default;

        private void LoadSettings()
        {
            splitContainer.SplitterDistance = settings.SpliterPosition;
        }

        private void SaveSettings()
        {
            settings.SpliterPosition = splitContainer.SplitterDistance;
            settings.Save();
        }
        private void EnvManager_Load ( object sender, EventArgs e )
        {
            LoadSettings();
        }
        #endregion Settings
    }
}