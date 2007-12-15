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
using System.Drawing;

using System.Windows.Forms;

namespace EnvManager.Commands
{
    public class DgvHandler
    {
        bool markAsAdded = false;
        private const char SEPARATOR = ';';
        private EnvVarValueValidator validator = new EnvVarValueValidator();
        private DataGridView dgv = null;
        
        public DgvHandler(ref DataGridView dgv)
        {
            this.dgv = dgv;
        }
        public int CurrentRowIndex
        {
            get { return dgv.CurrentRow.Index; }
        }
        public int BottomRowIndex
        {
            get 
            {
                return dgv.Rows.Count - 2; //(dgv.Rows.Count == 1 ? 0 : dgv.Rows.Count - 2); 
            }
        }
        public DataGridViewRow CurrentRow(int rowIndex)
        {
            return dgv.Rows[ rowIndex ];
        }
        public void MoveRow(int currentRowIndex, int destinationRowIndex)
        {
            DataGridViewRow rowToMove = CurrentRow(currentRowIndex);

            DeleteRow(currentRowIndex);
            InsertRow( destinationRowIndex, rowToMove );
        }
        public void InsertRow(int rowIndex, DataGridViewRow row)
        {
            dgv.Rows.Insert( rowIndex, row );
            SetCurrentCell(rowIndex);
        }
        public void SetCurrentCell(int rowIndex)
        {
            dgv.CurrentCell = dgv[0, rowIndex];
        }
        public void DeleteRow(int rowIndex)
        {
            try
            {
                dgv.Rows.RemoveAt( rowIndex );
            }
            catch ( Exception ex)
            {
                MessageBox.Show( ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }
        /// <summary>
        /// Returns Icon corresponding the type of the variable
        /// Added by Mariusz Ficek
        /// </summary>
        /// <param name="varValue">The variable value.</param>
        /// <returns>Icon Bitmap</returns>
        private Bitmap IconValueType ( string varValue, ref string toolTipMsg )
        {
            Bitmap icon;

            switch ( validator.ValueType( varValue ) )
            {
                case EnvironmentValueType.Number:
                    icon = (this.markAsAdded ? Properties.Resources.ValTypeNumberAdd 
                        :  Properties.Resources.ValTypeNumber);
                    toolTipMsg = "Number";
                    break;
                case EnvironmentValueType.String:
                    icon = (this.markAsAdded ? Properties.Resources.ValTypeStringAdd 
                        : Properties.Resources.ValTypeString);
                    toolTipMsg = "Word";
                    break;
                case EnvironmentValueType.Folder:
                    icon = (this.markAsAdded ? Properties.Resources.ValTypeFolderAdd 
                        : Properties.Resources.ValTypeFolder);
                    toolTipMsg = "Folder";
                    break;
                case EnvironmentValueType.File:
                    icon = (this.markAsAdded ? Properties.Resources.ValTypeFileAdd 
                        : Properties.Resources.ValTypeFile);
                    toolTipMsg = "File";
                    break;
                default:  // Error 
                    icon = (this.markAsAdded ? Properties.Resources.ValTypeErrorAdd 
                        : Properties.Resources.ValTypeError);
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
        public void SetRowIcon ( int rowIndex, string varValue )
        {
            string toolTipMsg = "";
            dgv.Rows[ rowIndex ].Cells[ 0 ].Value
                = IconValueType( varValue, ref toolTipMsg );
            dgv.Rows[ rowIndex ].Cells[ 0 ].ToolTipText = toolTipMsg;
        }
        /// <summary>
        /// Sets the string value to row.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="varValue">The variable value.</param>
        public void SetRowValue ( int rowIndex, string varValue )
        {
            dgv.Rows[ rowIndex ].Cells[ 1 ].Value = varValue;
        }
        /// <summary>
        /// Adds a new row to grid.
        /// </summary>
        /// <param name="varValue">The variable value.</param>
        public int AddRow ( string varValue )
        {
            int rowIndex = dgv.Rows.Add();

            SetRowValue( rowIndex, varValue );
            SetRowIcon( rowIndex, varValue );

            return rowIndex;
        }
        public void AddRows ( string varValues )
        {
            string[ ] values = varValues.Split( SEPARATOR );

            foreach ( string value in values )
            {
                this.AddRow( value );
            }
        }
        public void AddRows( string varValues, bool markAsAdded)
        {
            this.markAsAdded = markAsAdded;
            this.AddRows( varValues );
        }
        public DataGridViewSelectedRowCollection SelectedRows
        {
            get
            {
                return dgv.SelectedRows;
            }
        }
        public void SetRowVisibility(int rowIndex, bool visible)
        {
            dgv.Rows[rowIndex].Visible = visible;
        }
    }
}
