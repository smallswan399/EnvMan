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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace EnvManager
{
    public partial class EnvManager : UserControl
    {
        FrmEditEnvVar frmEditVariable = null;
        EnvVarManager variableManger = null;

        public EnvManager ( )
        {
            InitializeComponent();

            variableManger = new EnvVarManager();
            LoadEnvironmentVariables();
        }

        #region Load Environment Variables
        private void LoadEnvironmentVariables ( )
        {
            LoadEnvironmentVariables( dgvSystemVariables, EnvironmentVariableTarget.Machine );
            LoadEnvironmentVariables( dgvUserVariables, EnvironmentVariableTarget.User );
        }
        private void LoadEnvironmentVariables ( DataGridView dgv, EnvironmentVariableTarget target )
        {
            dgv.Rows.Clear();
            IDictionary environmentVariables = variableManger.GetEnvVariables( target );
            foreach ( DictionaryEntry de in environmentVariables )
            {
                string[ ] row = { de.Key.ToString(), de.Value.ToString() };

                dgv.Rows.Add( row );
            }

            dgv.Sort( dgv.Columns[ 0 ], ListSortDirection.Ascending );
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
        private void dgvCellMouseDoubleClick ( object sender, DataGridViewCellMouseEventArgs e )
        {
            DataGridView dgv = ( DataGridView ) sender;
            if ( e.RowIndex > -1 )
            {
                EditEnvVar( dgv,
                    ( sender.Equals( dgvUserVariables )
                        ? EnvironmentVariableTarget.User
                        : EnvironmentVariableTarget.Machine ) );
            }
        }
        #endregion Controls Events

        #region Edit Environment Variables
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
    }
}