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

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using EnvManager.ImportExport;

namespace EnvManager.Commands
{
    /// <summary>
    /// Variable Import Command class
    /// Responsible for performing import of Environment Variables from file
    /// and undoing this action to previous state.
    /// </summary>
    public class VarImportCommand : ICommand
    {
        private int currentLastRow = 0;
        private TextBox txtVarName = null;
        private bool isNewVariable = false;
        private string currentVarValues = "";
        private string newVarValues = "";
        bool isAbleToImport = false;
        private DgvHandler dgvHandler = null;
        private ImportExportManager importExportManager = null;
        private string commandName = "Import";

        public VarImportCommand ( TextBox txtVarName, string currentVarValues, 
            string fileName, DgvHandler dgvHandler )
        {
            this.txtVarName = txtVarName;
            this.currentVarValues = currentVarValues;
            importExportManager = new ImportExportManager();
            importExportManager.EnvVariable = new EnvironmentVariable();
            importExportManager.Load( fileName );
            this.dgvHandler = dgvHandler;

            GetValuesToImport();
        }
        private void GetValuesToImport()
        {
            // Compare Variable Names in Uppercase
            if ( this.txtVarName.Text.Length == 0
                || this.txtVarName.Text.ToUpper().CompareTo( importExportManager.EnvVariable.VarName.ToUpper() ) == 0 )
            {   // Do prepare for import
                foreach ( string varValue in importExportManager.EnvVariable.VarValuesList )
                {
                    if ( currentVarValues.IndexOf( varValue ) == -1 )
                    {
                        newVarValues += ( newVarValues.Length != 0 ? ";" : "" ) + varValue;
                    }
                }

                if ( newVarValues.Length != 0 )
                {
                    isAbleToImport = true;
                }
                else
                {
                    MessageBox.Show( "There are no values to import.", "Nothing to import",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning );
                }
            }
            else
            {   // Variable names are not the same
                MessageBox.Show( "Cannot import values from different variable.",
                    "Variable names are not the same", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }
        public bool IsAbleToImport
        {
            get
            {
                return this.isAbleToImport;
            }
        }
        public string CommandName
        {
            get
            {
                return commandName;
            }
        }
        /// <summary>
        /// Performs Execute action. Remembers a current state 
        /// and calls Redo function.
        /// </summary>
        public void Execute()
        {
            currentLastRow = dgvHandler.BottomRowIndex;
            if(isAbleToImport)
            {
                Redo();
                MessageBox.Show("Import successfully completed!", "Import Success!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Performs Undo action.
        /// </summary>
        public void Undo()
        {
            int maxRows = dgvHandler.BottomRowIndex;
            for(int i = maxRows; i >= currentLastRow + 1; i--)
            {
                dgvHandler.DeleteRow( i );
            }
            if(isNewVariable)
            {
                txtVarName.Text = "";
            }
        }
        /// <summary>
        /// Performs Redo action.
        /// </summary>
        public void Redo ( )
        {
            if ( txtVarName.Text.Length == 0 )
            {
                isNewVariable = true;
                txtVarName.Text = importExportManager.EnvVariable.VarName;
            }
            dgvHandler.AddRows( newVarValues, true );
        }
    }
}
