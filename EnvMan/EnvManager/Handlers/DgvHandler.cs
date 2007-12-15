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
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;

namespace EnvManager.Handlers
{
    public class DgvHandler
    {
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
            get { return dgv.Rows.Count - 2; }
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
            dgv.Rows.RemoveAt(rowIndex);
        }
    }
}
