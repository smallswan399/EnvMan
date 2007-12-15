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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EnvManager.Commands
{
    public class DgvDeleteCommand : DgvCommand
    {
        public DgvDeleteCommand(DgvHandler dgvHandler) 
            : base(dgvHandler)
        {
            Init();
        }
        public DgvDeleteCommand ( DgvHandler dgvHandler, SortedList<int,DgvRowInfo> rowInfoList )
            : base( dgvHandler )
        {
            Init();
            this.rowInfoList = rowInfoList;
        }
        private void Init()
        {
            this.commandName = "Delete Value(s)";
        }
        public override void Execute()
        {
            // execute only when rowInfoList is not set, i.e. not deleted
            if ( rowInfoList == null )
            {
                rowInfoList = new SortedList<int,DgvRowInfo>();
                foreach (DataGridViewRow row in dgvHandler.SelectedRows)
                {
                    DgvRowInfo rowInfo = new DgvRowInfo();
                    rowInfo.CurrentRowIndex = row.Index;
                    rowInfoList.Add(row.Index, rowInfo);
                    row.Visible = false;  // hide row
                    row.Selected = false; // unselect row
                }
            }
        }
        public override void Undo()
        {   
            // unhide rows listed in the rowInfoList
            SetRowsVisibility(true);
        }
        public override void Redo()
        {
            // hide rows listed in the rowInfoList
            SetRowsVisibility(false);
        }
        private void SetRowsVisibility(bool visible)
        {
            DgvRowInfo rowInfo;
            foreach (KeyValuePair<int,DgvRowInfo> kvp in rowInfoList)
            {
                rowInfo = kvp.Value;
                dgvHandler.SetRowVisibility(rowInfo.CurrentRowIndex, visible);
            }
        }
    }
}
